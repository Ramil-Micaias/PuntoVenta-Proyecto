USE GU_Tercero;
GO

-----------------------------------------------
-- CARGA DE PRODUCTOS DE PRUEBA              --
-----------------------------------------------

INSERT INTO Producto (
    Codigo_Barras,
    Nombre_Producto,
    Descripcion,
    Id_Categoria,
    Precio_Costo,
    Precio_Venta,
    Stock_Actual,
    Stock_Minimo,
    Es_Repuesto,
    Activo
)
SELECT 
    V.Codigo_Barras,
    V.Nombre_Producto,
    V.Descripcion,
    c.Id_Categoria,
    V.Precio_Costo,
    V.Precio_Venta,
    V.Stock_Actual,
    V.Stock_Minimo,
    V.Es_Repuesto,
    1
FROM (VALUES 
    ('7799876543211', 'Cargador Rápido USB-C 20W', 'Fuente de carga rápida compatible con iPhone y Android', 'Cargadores y Cables', 3500.00, 8500.00, 15, 3, 0),
    ('MOD-SAM-A12-HQ', 'Módulo Display Samsung A12', 'Pantalla completa con marco y táctil', 'Módulos y Pantallas', 18000.00, 32000.00, 5, 2, 1)
) AS V(Codigo_Barras, Nombre_Producto, Descripcion, Nombre_Categoria, Precio_Costo, Precio_Venta, Stock_Actual, Stock_Minimo, Es_Repuesto)
INNER JOIN CategoriaProducto c ON c.Nombre_Categoria = V.Nombre_Categoria
WHERE NOT EXISTS (
    SELECT 1 
    FROM Producto p 
    WHERE p.Nombre_Producto = V.Nombre_Producto 
       OR p.Codigo_Barras = V.Codigo_Barras
);
GO

-----------------------------------------------
-- CONSULTA DEL CATÁLOGO ACTUAL              --
-----------------------------------------------

SELECT 
    p.Id_Producto, 
    p.Codigo_Barras,
    p.Nombre_Producto, 
    c.Nombre_Categoria, 
    p.Precio_Venta, 
    p.Stock_Actual
FROM Producto p
INNER JOIN CategoriaProducto c ON p.Id_Categoria = c.Id_Categoria
WHERE p.Activo = 1
ORDER BY p.Nombre_Producto ASC;
GO