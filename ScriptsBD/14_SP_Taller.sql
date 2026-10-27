USE GU_Tercero;
GO

-- ============================================================
-- MODULO: TALLER (CU05, CU08 y CU09)
-- Órdenes de reparación: alta, consulta y actualización de estado.
-- Lo usan FormTaller, FormOrdenReparacion, GestorTaller y TallerDAO.
-- ============================================================

-- ------------------------------------------------------------
-- 1. TABLA: historial de estados de cada orden (CU09)
--    Guarda qué estado se puso, quién y cuándo.
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HistorialEstadoOrden')
BEGIN
    CREATE TABLE HistorialEstadoOrden (
        Id_Historial INT IDENTITY(1,1) PRIMARY KEY,
        Id_Orden INT NOT NULL,
        Id_Estado INT NOT NULL,
        Id_Usuario INT NOT NULL,
        Fecha DATETIME DEFAULT GETDATE() NOT NULL,
        Observacion NVARCHAR(255) NULL,
        FOREIGN KEY (Id_Orden) REFERENCES OrdenReparacion(Id_Orden),
        FOREIGN KEY (Id_Estado) REFERENCES EstadoOrden(Id_Estado),
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
    );
END
GO

-- Tipo de teléfono que se usa al dar de alta clientes desde el taller
IF NOT EXISTS (SELECT 1 FROM TipoTelefono WHERE Descripcion = 'Celular')
    INSERT INTO TipoTelefono (Descripcion, Activo) VALUES ('Celular', 1);
GO


-- ------------------------------------------------------------
-- 2. SP: Clientes del taller (para el combo de la orden)
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerClientesTaller
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.Id_Cliente,
        p.Apellido + ', ' + p.Nombre + ' (DNI ' + p.DNI + ')' AS Cliente,
        (SELECT TOP 1 t.Numero
         FROM PersonaTelefono pt
         INNER JOIN Telefono t ON t.Id_Telefono = pt.Id_Telefono
         WHERE pt.Id_Persona = p.Id_Persona AND t.Activo = 1) AS Telefono
    FROM Cliente c
    INNER JOIN Persona p ON p.Id_Persona = c.Id_Persona
    WHERE c.Activo = 1
    ORDER BY p.Apellido, p.Nombre;
END
GO


-- ------------------------------------------------------------
-- 3. SP: Alta de cliente
--    Si la persona ya existe (por ejemplo un empleado) solo se la marca como cliente.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_InsertarClienteTaller
    @Apellido NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @DNI NVARCHAR(20),
    @Telefono NVARCHAR(15) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Id_Persona INT = (SELECT Id_Persona FROM Persona WHERE DNI = @DNI);

        IF @Id_Persona IS NOT NULL
           AND EXISTS (SELECT 1 FROM Cliente WHERE Id_Persona = @Id_Persona)
        BEGIN
            RAISERROR('Ya existe un cliente con ese DNI.', 16, 1);
        END

        IF @Id_Persona IS NULL
        BEGIN
            INSERT INTO Persona (Apellido, Nombre, DNI, Fecha_Alta, Activo)
            VALUES (@Apellido, @Nombre, @DNI, GETDATE(), 1);

            SET @Id_Persona = SCOPE_IDENTITY();
        END

        INSERT INTO Cliente (Id_Persona, Fecha_Alta, Activo)
        VALUES (@Id_Persona, GETDATE(), 1);

        DECLARE @Id_Cliente INT = SCOPE_IDENTITY();

        -- El teléfono es opcional
        IF @Telefono IS NOT NULL AND LTRIM(RTRIM(@Telefono)) <> ''
        BEGIN
            DECLARE @Id_Telefono INT = (SELECT Id_Telefono FROM Telefono WHERE Numero = @Telefono);

            IF @Id_Telefono IS NULL
            BEGIN
                INSERT INTO Telefono (Id_TipoTelefono, Numero, Activo)
                VALUES ((SELECT TOP 1 Id_TipoTelefono FROM TipoTelefono WHERE Descripcion = 'Celular'), @Telefono, 1);

                SET @Id_Telefono = SCOPE_IDENTITY();
            END

            IF NOT EXISTS (SELECT 1 FROM PersonaTelefono WHERE Id_Persona = @Id_Persona AND Id_Telefono = @Id_Telefono)
                INSERT INTO PersonaTelefono (Id_Persona, Id_Telefono) VALUES (@Id_Persona, @Id_Telefono);
        END

        COMMIT TRANSACTION;

        SELECT @Id_Cliente AS Id_Cliente;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


-- ------------------------------------------------------------
-- 4. SP: Equipos de un cliente
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerEquiposCliente
    @Id_Cliente INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_Equipo,
        Marca + ' ' + Modelo
            + CASE WHEN Color IS NULL OR Color = '' THEN '' ELSE ' - ' + Color END
            + CASE WHEN IMEI IS NULL OR IMEI = '' THEN '' ELSE ' (IMEI ' + IMEI + ')' END AS Equipo
    FROM Equipo
    WHERE Id_Cliente = @Id_Cliente
      AND Activo = 1
    ORDER BY Marca, Modelo;
END
GO


-- ------------------------------------------------------------
-- 5. SP: Alta de equipo
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_InsertarEquipo
    @Id_Cliente INT,
    @Tipo_Dispositivo NVARCHAR(50),
    @Marca NVARCHAR(50),
    @Modelo NVARCHAR(80),
    @Numero_Serie NVARCHAR(50) = NULL,
    @IMEI NVARCHAR(20) = NULL,
    @Color NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE Id_Cliente = @Id_Cliente AND Activo = 1)
    BEGIN
        RAISERROR('El cliente seleccionado no existe o está inactivo.', 16, 1);
        RETURN;
    END

    IF @IMEI IS NOT NULL AND @IMEI <> ''
       AND EXISTS (SELECT 1 FROM Equipo WHERE IMEI = @IMEI AND Activo = 1)
    BEGIN
        RAISERROR('Ya hay un equipo registrado con ese IMEI.', 16, 1);
        RETURN;
    END

    INSERT INTO Equipo (Id_Cliente, Tipo_Dispositivo, Marca, Modelo, Numero_Serie, IMEI, Color, Activo)
    VALUES (@Id_Cliente, @Tipo_Dispositivo, @Marca, @Modelo, @Numero_Serie, @IMEI, @Color, 1);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id_Equipo;
END
GO


-- ------------------------------------------------------------
-- 6. SP: Técnicos activos
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerTecnicos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.Id_Usuario,
        p.Apellido + ', ' + p.Nombre + ' (' + u.Nombre_Usuario + ')' AS Tecnico
    FROM Usuario u
    INNER JOIN Persona p ON p.Id_Persona = u.Id_Persona
    INNER JOIN UsuarioRol ur ON ur.Id_Usuario = u.Id_Usuario
    INNER JOIN Rol r ON r.Id_Rol = ur.Id_Rol
    WHERE r.Nombre_Rol = 'Tecnico'
      AND u.Activo = 1
    ORDER BY p.Apellido, p.Nombre;
END
GO


-- ------------------------------------------------------------
-- 7. SP: Estados de una orden
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerEstadosOrden
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id_Estado, Nombre_Estado
    FROM EstadoOrden
    ORDER BY Id_Estado;
END
GO


-- ------------------------------------------------------------
-- 8. SP: Productos que se pueden usar como repuesto
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerRepuestos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id_Producto,
        Nombre_Producto + ' (stock ' + CAST(Stock_Actual AS NVARCHAR(10)) + ')' AS Producto,
        Precio_Venta,
        Stock_Actual
    FROM Producto
    WHERE Activo = 1
    ORDER BY Nombre_Producto;
END
GO


-- ------------------------------------------------------------
-- 9. SP: Guardar orden (alta CU05 y actualización CU09)
--    @Id_Orden = 0 da de alta una orden nueva.
--    Los repuestos vienen en JSON: [{"Id_Producto":1,"Cantidad":2,"Precio":5000}]
--    El stock se ajusta según la diferencia con lo que la orden ya tenía.
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_GuardarOrdenReparacion
    @Id_Orden INT = 0,
    @Id_Equipo INT,
    @Id_Tecnico INT = NULL,
    @Id_Usuario INT,
    @Id_Estado INT,
    @Falla_Declarada NVARCHAR(500),
    @Patron_Clave NVARCHAR(50) = NULL,
    @Diagnostico NVARCHAR(500) = NULL,
    @Costo_Mano_Obra DECIMAL(12,2) = 0,
    @Fecha_Prometida DATE = NULL,
    @Observacion NVARCHAR(255) = NULL,
    @Repuestos NVARCHAR(MAX) = '[]'
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM Equipo WHERE Id_Equipo = @Id_Equipo AND Activo = 1)
            RAISERROR('El equipo seleccionado no existe.', 16, 1);

        IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Id_Estado = @Id_Estado)
            RAISERROR('El estado seleccionado no es válido.', 16, 1);

        IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Id_Usuario = @Id_Usuario AND Activo = 1)
            RAISERROR('El usuario no es válido. Inicie sesión nuevamente.', 16, 1);

        IF @Costo_Mano_Obra < 0
            RAISERROR('La mano de obra no puede ser negativa.', 16, 1);

        DECLARE @Nombre_Estado NVARCHAR(40) = (SELECT Nombre_Estado FROM EstadoOrden WHERE Id_Estado = @Id_Estado);
        DECLARE @Estado_Anterior INT = NULL;

        IF @Id_Orden > 0
        BEGIN
            SET @Estado_Anterior = (SELECT Id_Estado FROM OrdenReparacion WHERE Id_Orden = @Id_Orden);

            IF @Estado_Anterior IS NULL
                RAISERROR('La orden no existe.', 16, 1);

            -- Una orden entregada o cancelada ya está cerrada
            IF EXISTS (
                SELECT 1 FROM EstadoOrden
                WHERE Id_Estado = @Estado_Anterior AND Nombre_Estado IN ('Entregado', 'Cancelado')
            )
                RAISERROR('La orden ya está entregada o cancelada y no se puede modificar.', 16, 1);
        END

        -- Repuestos nuevos
        DECLARE @Nuevos TABLE (Id_Producto INT, Cantidad INT, Precio DECIMAL(12,2));

        INSERT INTO @Nuevos (Id_Producto, Cantidad, Precio)
        SELECT Id_Producto, SUM(Cantidad), MAX(Precio)
        FROM OPENJSON(ISNULL(@Repuestos, '[]'))
        WITH (
            Id_Producto INT '$.Id_Producto',
            Cantidad INT '$.Cantidad',
            Precio DECIMAL(12,2) '$.Precio'
        )
        GROUP BY Id_Producto;

        -- Si la orden se cancela, los repuestos vuelven al stock
        IF @Nombre_Estado = 'Cancelado'
            DELETE FROM @Nuevos;

        IF EXISTS (SELECT 1 FROM @Nuevos WHERE Id_Producto IS NULL OR Cantidad <= 0 OR Precio < 0)
            RAISERROR('Los repuestos tienen datos inválidos.', 16, 1);

        -- Repuestos que la orden ya tenía (para devolverlos al stock antes de descontar los nuevos)
        DECLARE @Anteriores TABLE (Id_Producto INT, Cantidad INT);

        INSERT INTO @Anteriores (Id_Producto, Cantidad)
        SELECT Id_Producto, SUM(Cantidad)
        FROM DetalleOrdenRepuesto
        WHERE Id_Orden = @Id_Orden
        GROUP BY Id_Producto;

        -- Control de stock: lo disponible + lo que ya estaba reservado en esta orden
        IF EXISTS (
            SELECT 1
            FROM @Nuevos n
            INNER JOIN Producto p ON p.Id_Producto = n.Id_Producto
            LEFT JOIN @Anteriores a ON a.Id_Producto = n.Id_Producto
            WHERE n.Cantidad > p.Stock_Actual + ISNULL(a.Cantidad, 0)
        )
        BEGIN
            DECLARE @SinStock NVARCHAR(100) = (
                SELECT TOP 1 p.Nombre_Producto
                FROM @Nuevos n
                INNER JOIN Producto p ON p.Id_Producto = n.Id_Producto
                LEFT JOIN @Anteriores a ON a.Id_Producto = n.Id_Producto
                WHERE n.Cantidad > p.Stock_Actual + ISNULL(a.Cantidad, 0)
            );
            DECLARE @MensajeStock NVARCHAR(200) = 'Stock insuficiente del repuesto "' + @SinStock + '".';
            RAISERROR(@MensajeStock, 16, 1);
        END

        IF EXISTS (
            SELECT 1 FROM @Nuevos n
            LEFT JOIN Producto p ON p.Id_Producto = n.Id_Producto AND p.Activo = 1
            WHERE p.Id_Producto IS NULL
        )
            RAISERROR('Uno de los repuestos no existe o está inactivo.', 16, 1);

        DECLARE @Total DECIMAL(12,2) = @Costo_Mano_Obra + ISNULL((SELECT SUM(Cantidad * Precio) FROM @Nuevos), 0);

        IF @Id_Orden = 0
        BEGIN
            INSERT INTO OrdenReparacion (
                Id_Equipo, Id_Tecnico, Id_Usuario_Recepcion, Id_Estado, Falla_Declarada,
                Patron_Clave_Desbloqueo, Diagnostico_Tecnico, Costo_Mano_Obra, Total_Presupuesto,
                Fecha_Ingreso, Fecha_Prometida
            )
            VALUES (
                @Id_Equipo, @Id_Tecnico, @Id_Usuario, @Id_Estado, @Falla_Declarada,
                @Patron_Clave, @Diagnostico, @Costo_Mano_Obra, @Total,
                GETDATE(), @Fecha_Prometida
            );

            SET @Id_Orden = SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            UPDATE OrdenReparacion
            SET Id_Equipo = @Id_Equipo,
                Id_Tecnico = @Id_Tecnico,
                Id_Estado = @Id_Estado,
                Falla_Declarada = @Falla_Declarada,
                Patron_Clave_Desbloqueo = @Patron_Clave,
                Diagnostico_Tecnico = @Diagnostico,
                Costo_Mano_Obra = @Costo_Mano_Obra,
                Total_Presupuesto = @Total,
                Fecha_Prometida = @Fecha_Prometida
            WHERE Id_Orden = @Id_Orden;
        END

        -- Devuelve al stock los repuestos anteriores y descuenta los nuevos
        UPDATE p
        SET p.Stock_Actual = p.Stock_Actual + a.Cantidad
        FROM Producto p
        INNER JOIN @Anteriores a ON a.Id_Producto = p.Id_Producto;

        DELETE FROM DetalleOrdenRepuesto WHERE Id_Orden = @Id_Orden;

        INSERT INTO DetalleOrdenRepuesto (Id_Orden, Id_Producto, Cantidad, Precio_Unitario)
        SELECT @Id_Orden, Id_Producto, Cantidad, Precio
        FROM @Nuevos;

        UPDATE p
        SET p.Stock_Actual = p.Stock_Actual - n.Cantidad
        FROM Producto p
        INNER JOIN @Nuevos n ON n.Id_Producto = p.Id_Producto;

        -- Fechas según el estado
        IF @Nombre_Estado = 'Reparado'
            UPDATE OrdenReparacion SET Fecha_Finalizado = ISNULL(Fecha_Finalizado, GETDATE()) WHERE Id_Orden = @Id_Orden;

        IF @Nombre_Estado = 'Entregado'
            UPDATE OrdenReparacion
            SET Fecha_Finalizado = ISNULL(Fecha_Finalizado, GETDATE()),
                Fecha_Entrega = GETDATE()
            WHERE Id_Orden = @Id_Orden;

        -- Historial: se registra al crear la orden y cada vez que cambia el estado
        IF @Estado_Anterior IS NULL OR @Estado_Anterior <> @Id_Estado
            INSERT INTO HistorialEstadoOrden (Id_Orden, Id_Estado, Id_Usuario, Fecha, Observacion)
            VALUES (@Id_Orden, @Id_Estado, @Id_Usuario, GETDATE(), @Observacion);

        COMMIT TRANSACTION;

        SELECT
            @Id_Orden AS Id_Orden,
            'OR-' + RIGHT('00000000' + CAST(@Id_Orden AS NVARCHAR(8)), 8) AS Numero_Orden,
            @Total AS Total;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


-- ------------------------------------------------------------
-- 10. SP: Consulta de órdenes (CU08)
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ConsultarOrdenes
    @Filtro NVARCHAR(100) = '',
    @Id_Estado INT = NULL,
    @Id_Tecnico INT = NULL,
    @Solo_Pendientes BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SET @Filtro = LTRIM(RTRIM(ISNULL(@Filtro, '')));

    SELECT
        o.Id_Orden,
        'OR-' + RIGHT('00000000' + CAST(o.Id_Orden AS NVARCHAR(8)), 8) AS Orden,
        o.Fecha_Ingreso AS Ingreso,
        pc.Apellido + ', ' + pc.Nombre AS Cliente,
        eq.Marca + ' ' + eq.Modelo AS Equipo,
        ISNULL(pt.Apellido + ', ' + pt.Nombre, 'Sin asignar') AS Tecnico,
        e.Nombre_Estado AS Estado,
        o.Fecha_Prometida AS Prometida,
        o.Total_Presupuesto AS Total
    FROM OrdenReparacion o
    INNER JOIN Equipo eq ON eq.Id_Equipo = o.Id_Equipo
    INNER JOIN Cliente c ON c.Id_Cliente = eq.Id_Cliente
    INNER JOIN Persona pc ON pc.Id_Persona = c.Id_Persona
    INNER JOIN EstadoOrden e ON e.Id_Estado = o.Id_Estado
    LEFT JOIN Usuario ut ON ut.Id_Usuario = o.Id_Tecnico
    LEFT JOIN Persona pt ON pt.Id_Persona = ut.Id_Persona
    WHERE (@Id_Estado IS NULL OR o.Id_Estado = @Id_Estado)
      AND (@Id_Tecnico IS NULL OR o.Id_Tecnico = @Id_Tecnico)
      AND (@Solo_Pendientes = 0 OR e.Nombre_Estado NOT IN ('Entregado', 'Cancelado'))
      AND (
            @Filtro = ''
         OR pc.Apellido LIKE '%' + @Filtro + '%'
         OR pc.Nombre LIKE '%' + @Filtro + '%'
         OR pc.DNI LIKE '%' + @Filtro + '%'
         OR eq.Marca LIKE '%' + @Filtro + '%'
         OR eq.Modelo LIKE '%' + @Filtro + '%'
         OR ISNULL(eq.IMEI, '') LIKE '%' + @Filtro + '%'
         OR CAST(o.Id_Orden AS NVARCHAR(10)) = @Filtro
      )
    ORDER BY o.Fecha_Ingreso DESC;
END
GO


-- ------------------------------------------------------------
-- 11. SP: Datos de una orden (para abrirla y actualizarla)
-- ------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerOrden
    @Id_Orden INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        o.Id_Orden,
        o.Id_Equipo,
        eq.Id_Cliente,
        o.Id_Tecnico,
        o.Id_Estado,
        e.Nombre_Estado,
        o.Falla_Declarada,
        o.Patron_Clave_Desbloqueo,
        o.Diagnostico_Tecnico,
        o.Costo_Mano_Obra,
        o.Total_Presupuesto,
        o.Fecha_Ingreso,
        o.Fecha_Prometida,
        pr.Apellido + ', ' + pr.Nombre AS Recepcion,
        pt.Apellido + ', ' + pt.Nombre AS Tecnico
    FROM OrdenReparacion o
    INNER JOIN Equipo eq ON eq.Id_Equipo = o.Id_Equipo
    INNER JOIN EstadoOrden e ON e.Id_Estado = o.Id_Estado
    INNER JOIN Usuario ur ON ur.Id_Usuario = o.Id_Usuario_Recepcion
    INNER JOIN Persona pr ON pr.Id_Persona = ur.Id_Persona
    LEFT JOIN Usuario ut ON ut.Id_Usuario = o.Id_Tecnico
    LEFT JOIN Persona pt ON pt.Id_Persona = ut.Id_Persona
    WHERE o.Id_Orden = @Id_Orden;
END
GO

CREATE OR ALTER PROCEDURE sp_ObtenerRepuestosOrden
    @Id_Orden INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        d.Id_Producto,
        p.Nombre_Producto AS Repuesto,
        d.Cantidad,
        d.Precio_Unitario,
        d.Cantidad * d.Precio_Unitario AS Subtotal
    FROM DetalleOrdenRepuesto d
    INNER JOIN Producto p ON p.Id_Producto = d.Id_Producto
    WHERE d.Id_Orden = @Id_Orden;
END
GO

CREATE OR ALTER PROCEDURE sp_ObtenerHistorialOrden
    @Id_Orden INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        h.Fecha,
        e.Nombre_Estado AS Estado,
        p.Apellido + ', ' + p.Nombre AS Usuario,
        ISNULL(h.Observacion, '') AS [Observación]
    FROM HistorialEstadoOrden h
    INNER JOIN EstadoOrden e ON e.Id_Estado = h.Id_Estado
    INNER JOIN Usuario u ON u.Id_Usuario = h.Id_Usuario
    INNER JOIN Persona p ON p.Id_Persona = u.Id_Persona
    WHERE h.Id_Orden = @Id_Orden
    ORDER BY h.Fecha DESC, h.Id_Historial DESC;
END
GO
