USE GU_Tercero;
GO

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Módulos y Pantallas')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Módulos y Pantallas', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Baterías')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Baterías', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Pin de Carga y Flex')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Pin de Carga y Flex', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Cámaras y Lentes')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Cámaras y Lentes', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Carcasas y Repuestos Internos')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Carcasas y Repuestos Internos', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Cargadores y Cables')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Cargadores y Cables', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Fundas y Protectores')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Fundas y Protectores', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Vidrios Templados / Glass')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Vidrios Templados / Glass', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Auriculares y Audio')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Auriculares y Audio', 1);

IF NOT EXISTS (SELECT 1 FROM CategoriaProducto WHERE Nombre_Categoria = 'Periféricos y Memorias')
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo) VALUES ('Periféricos y Memorias', 1);
GO