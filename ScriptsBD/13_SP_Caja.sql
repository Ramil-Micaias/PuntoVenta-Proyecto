USE GU_Tercero;
GO

-- ============================================================
-- MODULO: CAJA DIARIA (CU06 Registrar Movimiento de Caja)
-- Tablas de caja y movimientos + Stored Procedures que usa FormCaja.
-- El saldo de la caja se calcula con:
--   saldo inicial
--   + ingresos manuales + lo pagado en efectivo de las ventas de la caja
--   - egresos manuales - compras en efectivo de la caja
-- Las ventas y compras solo se leen: no se tocan sus SP.
-- ============================================================

-- ------------------------------------------------------------
-- 1. TABLAS (Idempotentes)
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Caja')
BEGIN
    CREATE TABLE Caja (
        Id_Caja INT IDENTITY(1,1) PRIMARY KEY,
        Fecha_Apertura DATETIME DEFAULT GETDATE() NOT NULL,
        Id_Usuario_Apertura INT NOT NULL,
        Saldo_Inicial DECIMAL(12,2) NOT NULL,
        Fecha_Cierre DATETIME NULL,
        Id_Usuario_Cierre INT NULL,
        Saldo_Cierre DECIMAL(12,2) NULL,
        Abierta BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Usuario_Apertura) REFERENCES Usuario(Id_Usuario),
        FOREIGN KEY (Id_Usuario_Cierre) REFERENCES Usuario(Id_Usuario),
        CHECK (Saldo_Inicial >= 0)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MovimientoCaja')
BEGIN
    CREATE TABLE MovimientoCaja (
        Id_Movimiento INT IDENTITY(1,1) PRIMARY KEY,
        Id_Caja INT NOT NULL,
        Tipo NVARCHAR(10) NOT NULL,
        Importe DECIMAL(12,2) NOT NULL,
        Motivo NVARCHAR(200) NOT NULL,
        Id_Usuario INT NOT NULL,
        Fecha DATETIME DEFAULT GETDATE() NOT NULL,
        FOREIGN KEY (Id_Caja) REFERENCES Caja(Id_Caja),
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
        CHECK (Tipo IN ('Ingreso', 'Egreso')),
        CHECK (Importe > 0)
    );
END
GO


-- ------------------------------------------------------------
-- 2. FUNCIONES: Período y saldo de una caja
--    Una caja abarca desde su apertura hasta su cierre. Si sigue
--    abierta, hasta el final del día en que se abrió. Así, si en
--    el mismo día se cierra una caja y se abre otra, cada venta o
--    compra en efectivo cuenta en una sola caja.
-- ------------------------------------------------------------
CREATE OR ALTER FUNCTION dbo.fn_FinPeriodoCaja(@Id_Caja INT)
RETURNS DATETIME
AS
BEGIN
    RETURN (
        SELECT ISNULL(
            Fecha_Cierre,
            DATEADD(DAY, 1, CAST(CAST(Fecha_Apertura AS DATE) AS DATETIME))
        )
        FROM Caja
        WHERE Id_Caja = @Id_Caja
    );
END
GO

CREATE OR ALTER FUNCTION dbo.fn_IngresosCaja(@Id_Caja INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @Desde DATETIME = (SELECT Fecha_Apertura FROM Caja WHERE Id_Caja = @Id_Caja);
    DECLARE @Hasta DATETIME = dbo.fn_FinPeriodoCaja(@Id_Caja);
    DECLARE @IdEfectivo INT = (SELECT TOP 1 Id_MetodoPago FROM MetodoPago WHERE Nombre = 'Efectivo');

    -- De las ventas se cuenta solo la parte pagada en efectivo (puede ser un pago mixto).
    RETURN
        ISNULL((SELECT SUM(Importe) FROM MovimientoCaja
                WHERE Id_Caja = @Id_Caja AND Tipo = 'Ingreso'), 0)
      + ISNULL((SELECT SUM(pv.Importe)
                FROM PagoVenta pv
                INNER JOIN Venta v ON v.Id_Venta = pv.Id_Venta
                WHERE v.Anulada = 0 AND pv.Id_MetodoPago = @IdEfectivo
                  AND v.Fecha_Venta >= @Desde AND v.Fecha_Venta < @Hasta), 0);
END
GO

CREATE OR ALTER FUNCTION dbo.fn_EgresosCaja(@Id_Caja INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @Desde DATETIME = (SELECT Fecha_Apertura FROM Caja WHERE Id_Caja = @Id_Caja);
    DECLARE @Hasta DATETIME = dbo.fn_FinPeriodoCaja(@Id_Caja);
    DECLARE @IdEfectivo INT = (SELECT TOP 1 Id_MetodoPago FROM MetodoPago WHERE Nombre = 'Efectivo');

    RETURN
        ISNULL((SELECT SUM(Importe) FROM MovimientoCaja
                WHERE Id_Caja = @Id_Caja AND Tipo = 'Egreso'), 0)
      + ISNULL((SELECT SUM(Total) FROM Compra
                WHERE Estado = 1 AND Id_MetodoPago = @IdEfectivo
                  AND Fecha_Compra >= @Desde AND Fecha_Compra < @Hasta), 0);
END
GO

CREATE OR ALTER FUNCTION dbo.fn_SaldoCaja(@Id_Caja INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @SaldoInicial DECIMAL(12,2) = (SELECT Saldo_Inicial FROM Caja WHERE Id_Caja = @Id_Caja);

    IF @SaldoInicial IS NULL
        RETURN 0;

    RETURN @SaldoInicial + dbo.fn_IngresosCaja(@Id_Caja) - dbo.fn_EgresosCaja(@Id_Caja);
END
GO


-- ------------------------------------------------------------
-- 3. SP: Caja de la jornada actual
--    Devuelve la última caja de hoy (abierta o cerrada) con sus
--    totales. Si no hay caja de hoy no devuelve filas.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerCajaActual
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

    SELECT TOP 1
        c.Id_Caja,
        c.Fecha_Apertura,
        c.Saldo_Inicial,
        c.Abierta,
        c.Fecha_Cierre,
        u.Nombre_Usuario AS Usuario_Apertura,
        dbo.fn_IngresosCaja(c.Id_Caja) AS Ingresos,
        dbo.fn_EgresosCaja(c.Id_Caja) AS Egresos,
        dbo.fn_SaldoCaja(c.Id_Caja) AS Saldo_Disponible
    FROM Caja c
    INNER JOIN Usuario u ON u.Id_Usuario = c.Id_Usuario_Apertura
    WHERE CAST(c.Fecha_Apertura AS DATE) = @Hoy
    ORDER BY c.Id_Caja DESC;
END
GO


-- ------------------------------------------------------------
-- 4. SP: Movimientos de una caja
--    Movimientos manuales + ventas y compras en efectivo del período de la caja.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ListarMovimientosCaja
    @Id_Caja INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Desde DATETIME = (SELECT Fecha_Apertura FROM Caja WHERE Id_Caja = @Id_Caja);
    DECLARE @Hasta DATETIME = dbo.fn_FinPeriodoCaja(@Id_Caja);
    DECLARE @IdEfectivo INT = (SELECT TOP 1 Id_MetodoPago FROM MetodoPago WHERE Nombre = 'Efectivo');

    SELECT Fecha, Tipo, Origen, Motivo, Importe, Usuario
    FROM (
        SELECT
            m.Fecha,
            m.Tipo,
            'Manual' AS Origen,
            m.Motivo,
            m.Importe,
            u.Nombre_Usuario AS Usuario
        FROM MovimientoCaja m
        INNER JOIN Usuario u ON u.Id_Usuario = m.Id_Usuario
        WHERE m.Id_Caja = @Id_Caja

        UNION ALL

        SELECT
            v.Fecha_Venta,
            'Ingreso',
            'Venta',
            'Venta ' + ISNULL(v.Numero_Factura, '') +
                CASE WHEN pv.Importe < v.Total THEN ' (parte en efectivo)' ELSE '' END,
            pv.Importe,
            u.Nombre_Usuario
        FROM PagoVenta pv
        INNER JOIN Venta v ON v.Id_Venta = pv.Id_Venta
        INNER JOIN Usuario u ON u.Id_Usuario = v.Id_Usuario_Vendedor
        WHERE v.Anulada = 0
          AND pv.Id_MetodoPago = @IdEfectivo
          AND v.Fecha_Venta >= @Desde AND v.Fecha_Venta < @Hasta

        UNION ALL

        SELECT
            c.Fecha_Compra,
            'Egreso',
            'Compra',
            'Compra ' + ISNULL(c.Numero_Comprobante, ''),
            c.Total,
            u.Nombre_Usuario
        FROM Compra c
        INNER JOIN Usuario u ON u.Id_Usuario = c.Id_Usuario
        WHERE c.Estado = 1
          AND c.Id_MetodoPago = @IdEfectivo
          AND c.Fecha_Compra >= @Desde AND c.Fecha_Compra < @Hasta
    ) movimientos
    ORDER BY Fecha DESC;
END
GO


-- ------------------------------------------------------------
-- 5. SP: Abrir caja
--    Solo puede haber una caja abierta a la vez. Si ya se cerró la
--    caja de hoy se puede abrir otra. Si quedó abierta una caja de
--    un día anterior, se cierra con su saldo antes de abrir la nueva.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_AbrirCaja
    @Id_Usuario INT,
    @Saldo_Inicial DECIMAL(12,2)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

        IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Id_Usuario = @Id_Usuario AND Activo = 1)
        BEGIN
            RAISERROR('El usuario no es válido. Inicie sesión nuevamente.', 16, 1);
        END

        IF @Saldo_Inicial IS NULL OR @Saldo_Inicial < 0
        BEGIN
            RAISERROR('El saldo inicial debe ser un importe mayor o igual a cero.', 16, 1);
        END

        IF EXISTS (SELECT 1 FROM Caja WITH (UPDLOCK, HOLDLOCK)
                   WHERE Abierta = 1 AND CAST(Fecha_Apertura AS DATE) = @Hoy)
        BEGIN
            RAISERROR('Ya hay una caja abierta para la jornada de hoy. Ciérrela antes de abrir otra.', 16, 1);
        END

        -- Cierra cajas de días anteriores que quedaron abiertas
        UPDATE Caja
        SET Abierta = 0,
            Fecha_Cierre = dbo.fn_FinPeriodoCaja(Id_Caja),
            Id_Usuario_Cierre = @Id_Usuario,
            Saldo_Cierre = dbo.fn_SaldoCaja(Id_Caja)
        WHERE Abierta = 1;

        INSERT INTO Caja (Fecha_Apertura, Id_Usuario_Apertura, Saldo_Inicial, Abierta)
        VALUES (GETDATE(), @Id_Usuario, @Saldo_Inicial, 1);

        COMMIT TRANSACTION;

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id_Caja;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


-- ------------------------------------------------------------
-- 6. SP: Cerrar caja
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_CerrarCaja
    @Id_Caja INT,
    @Id_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM Caja WITH (UPDLOCK, HOLDLOCK)
                       WHERE Id_Caja = @Id_Caja AND Abierta = 1)
        BEGIN
            RAISERROR('La caja ya fue cerrada.', 16, 1);
        END

        DECLARE @SaldoCierre DECIMAL(12,2) = dbo.fn_SaldoCaja(@Id_Caja);

        UPDATE Caja
        SET Abierta = 0,
            Fecha_Cierre = GETDATE(),
            Id_Usuario_Cierre = @Id_Usuario,
            Saldo_Cierre = @SaldoCierre
        WHERE Id_Caja = @Id_Caja;

        COMMIT TRANSACTION;

        SELECT @SaldoCierre AS Saldo_Cierre;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


-- ------------------------------------------------------------
-- 7. SP: Registrar movimiento de caja (CU06)
--    En una única transacción vuelve a verificar que la caja siga
--    abierta y que el saldo alcance para el egreso (flujo 10 / 10.1).
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_RegistrarMovimientoCaja
    @Id_Caja INT,
    @Tipo NVARCHAR(10),
    @Importe DECIMAL(12,2),
    @Motivo NVARCHAR(200),
    @Id_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        SET @Motivo = LTRIM(RTRIM(ISNULL(@Motivo, '')));

        IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Id_Usuario = @Id_Usuario AND Activo = 1)
        BEGIN
            RAISERROR('El usuario no es válido. Inicie sesión nuevamente.', 16, 1);
        END

        IF @Tipo IS NULL OR @Tipo NOT IN ('Ingreso', 'Egreso')
        BEGIN
            RAISERROR('Debe seleccionar el tipo de movimiento (Ingreso o Egreso).', 16, 1);
        END

        IF @Importe IS NULL OR @Importe <= 0
        BEGIN
            RAISERROR('El importe debe ser un número mayor a cero.', 16, 1);
        END

        IF @Motivo = ''
        BEGIN
            RAISERROR('Debe ingresar el motivo del movimiento.', 16, 1);
        END

        -- Bloquea la caja para que dos movimientos no se pisen
        IF NOT EXISTS (SELECT 1 FROM Caja WITH (UPDLOCK, HOLDLOCK)
                       WHERE Id_Caja = @Id_Caja AND Abierta = 1)
        BEGIN
            RAISERROR('La caja fue cerrada. No se registró el movimiento.', 16, 1);
        END

        DECLARE @Saldo DECIMAL(12,2) = dbo.fn_SaldoCaja(@Id_Caja);

        IF @Tipo = 'Egreso' AND @Importe > @Saldo
        BEGIN
            DECLARE @MensajeError NVARCHAR(300) =
                'Saldo insuficiente en caja. Saldo disponible: $' + FORMAT(@Saldo, 'N2', 'es-AR') + '.';
            RAISERROR(@MensajeError, 16, 1);
        END

        INSERT INTO MovimientoCaja (Id_Caja, Tipo, Importe, Motivo, Id_Usuario, Fecha)
        VALUES (@Id_Caja, @Tipo, @Importe, @Motivo, @Id_Usuario, GETDATE());

        DECLARE @IdMovimiento INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        SELECT
            @IdMovimiento AS Id_Movimiento,
            dbo.fn_SaldoCaja(@Id_Caja) AS Saldo_Disponible;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
