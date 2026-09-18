USE GU_Tercero;
GO

-- Insertar Producto 1 solo si no existe
IF NOT EXISTS (SELECT 1 FROM Producto WHERE Nombre_Producto = 'Cargador Rápido USB-C 20W')
BEGIN
    INSERT INTO Producto (
        Nombre_Producto, Descripcion, Id_Categoria, Precio_Costo, 
        Precio_Venta, Stock_Actual, Stock_Minimo, Es_Repuesto, Activo
    ) 
    VALUES (
        'Cargador Rápido USB-C 20W', 
        'Fuente de carga rápida compatible con iPhone y Android', 
        (SELECT TOP 1 Id_Categoria FROM CategoriaProducto WHERE Nombre_Categoria LIKE '%Cargadores%' OR Activo = 1), 
        3500.00, 8500.00, 15, 3, 0, 1
    );
END

-- Insertar Producto 2 solo si no existe
IF NOT EXISTS (SELECT 1 FROM Producto WHERE Nombre_Producto = 'Módulo Display Samsung A12')
BEGIN
    INSERT INTO Producto (
        Nombre_Producto, Descripcion, Id_Categoria, Precio_Costo, 
        Precio_Venta, Stock_Actual, Stock_Minimo, Es_Repuesto, Activo
    ) 
    VALUES (
        'Módulo Display Samsung A12', 
        'Pantalla completa con marco y táctil', 
        (SELECT TOP 1 Id_Categoria FROM CategoriaProducto WHERE Nombre_Categoria LIKE '%Módulos%' OR Activo = 1), 
        18000.00, 32000.00, 5, 2, 1, 1
    );
END
GO

-- Consultar catálogo actual
SELECT p.Id_Producto, p.Nombre_Producto, c.Nombre_Categoria, p.Precio_Venta, p.Stock_Actual
FROM Producto p
INNER JOIN CategoriaProducto c ON p.Id_Categoria = c.Id_Categoria;
GO