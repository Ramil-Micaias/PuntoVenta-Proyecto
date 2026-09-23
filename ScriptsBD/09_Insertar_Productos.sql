USE GU_Tercero;
GO

-----------------------------------------------
-- CARGA DE PRODUCTOS DE PRUEBA
-----------------------------------------------

INSERT INTO Producto (
    Nombre_Producto,
    Descripcion,
    Id_Categoria,
    Precio_Venta,
    Stock_Actual,
    Stock_Minimo,
    Es_Repuesto,
    Activo
)
SELECT
    V.Nombre_Producto,
    V.Descripcion,
    c.Id_Categoria,
    V.Precio_Venta,
    V.Stock_Actual,
    V.Stock_Minimo,
    V.Es_Repuesto,
    1
FROM
(
    VALUES
    (
        'Cargador Rápido USB-C 20W',
        'Fuente de carga rápida compatible con iPhone y Android',
        'Cargadores y Cables',
        8500.00,
        15,
        3,
        0
    ),
    (
        'Módulo Display Samsung A12',
        'Pantalla completa con marco y táctil',
        'Módulos y Pantallas',
        32000.00,
        5,
        2,
        1
    )
) AS V (
    Nombre_Producto,
    Descripcion,
    Nombre_Categoria,
    Precio_Venta,
    Stock_Actual,
    Stock_Minimo,
    Es_Repuesto
)
INNER JOIN CategoriaProducto c
    ON c.Nombre_Categoria = V.Nombre_Categoria
WHERE NOT EXISTS
(
    SELECT 1
    FROM Producto p
    WHERE p.Nombre_Producto = V.Nombre_Producto
);
GO


-----------------------------------------------
-- CONSULTA DEL CATÁLOGO ACTUAL
-----------------------------------------------

SELECT
    p.Id_Producto,
    p.Nombre_Producto,
    p.Descripcion,
    c.Nombre_Categoria,
    p.Precio_Venta,
    p.Stock_Actual,
    p.Stock_Minimo,
    p.Es_Repuesto,
    p.Activo
FROM Producto p
INNER JOIN CategoriaProducto c
    ON p.Id_Categoria = c.Id_Categoria
WHERE p.Activo = 1
ORDER BY p.Nombre_Producto ASC;
GO