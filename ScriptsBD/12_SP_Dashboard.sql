USE GU_Tercero;
GO

-- ============================================================
-- MODULO: MENU PRINCIPAL - RESUMEN DE ACTIVIDAD DIARIA
-- Datos que muestran los paneles del FormMenu.
-- ============================================================

CREATE OR ALTER PROCEDURE sp_ObtenerResumenDiario
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

    SELECT
        -- Ventas del día (sin anuladas)
        (SELECT ISNULL(SUM(Total), 0)
         FROM Venta
         WHERE Anulada = 0
           AND CAST(Fecha_Venta AS DATE) = @Hoy) AS Total_Ventas_Dia,

        (SELECT COUNT(*)
         FROM Venta
         WHERE Anulada = 0
           AND CAST(Fecha_Venta AS DATE) = @Hoy) AS Cantidad_Ventas_Dia,

        -- Órdenes de taller que todavía no se entregaron ni cancelaron
        (SELECT COUNT(*)
         FROM OrdenReparacion o
         INNER JOIN EstadoOrden e ON e.Id_Estado = o.Id_Estado
         WHERE e.Nombre_Estado NOT IN ('Entregado', 'Cancelado')) AS Ordenes_Taller_Activas,

        -- Productos activos con stock en o por debajo del mínimo
        (SELECT COUNT(*)
         FROM Producto
         WHERE Activo = 1
           AND Stock_Actual <= Stock_Minimo) AS Productos_Stock_Bajo,

        -- Compras del día (confirmadas)
        (SELECT ISNULL(SUM(Total), 0)
         FROM Compra
         WHERE Estado = 1
           AND CAST(Fecha_Compra AS DATE) = @Hoy) AS Total_Compras_Dia,

        (SELECT COUNT(*)
         FROM Compra
         WHERE Estado = 1
           AND CAST(Fecha_Compra AS DATE) = @Hoy) AS Cantidad_Compras_Dia;
END;
GO

-- ============================================================
-- Resumen del técnico: su trabajo en el taller.
-- Una reparación cuenta como terminada cuando está Reparada o Entregada.
-- ============================================================

CREATE OR ALTER PROCEDURE sp_ObtenerResumenTecnico
    @Id_Tecnico INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        -- Órdenes asignadas al técnico (sin las canceladas)
        (SELECT COUNT(*)
         FROM OrdenReparacion o
         INNER JOIN EstadoOrden e ON e.Id_Estado = o.Id_Estado
         WHERE o.Id_Tecnico = @Id_Tecnico
           AND e.Nombre_Estado <> 'Cancelado') AS Ordenes_Asignadas,

        -- Órdenes que ya terminó
        (SELECT COUNT(*)
         FROM OrdenReparacion o
         INNER JOIN EstadoOrden e ON e.Id_Estado = o.Id_Estado
         WHERE o.Id_Tecnico = @Id_Tecnico
           AND e.Nombre_Estado IN ('Reparado', 'Entregado')) AS Ordenes_Terminadas,

        -- Total cobrado por las reparaciones terminadas
        (SELECT ISNULL(SUM(o.Total_Presupuesto), 0)
         FROM OrdenReparacion o
         INNER JOIN EstadoOrden e ON e.Id_Estado = o.Id_Estado
         WHERE o.Id_Tecnico = @Id_Tecnico
           AND e.Nombre_Estado IN ('Reparado', 'Entregado')) AS Total_Reparaciones;
END;
GO
