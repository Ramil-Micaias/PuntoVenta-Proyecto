USE GU_Tercero;
GO

-----------------------------------------------
-- CARGA DE CATEGORÍAS DE PRODUCTO           --
-----------------------------------------------

INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
SELECT V.Nombre_Categoria, 1
FROM (VALUES 
    ('Módulos y Pantallas'),
    ('Baterías'),
    ('Pin de Carga y Flex'),
    ('Cámaras y Lentes'),
    ('Carcasas y Repuestos Internos'),
    ('Cargadores y Cables'),
    ('Fundas y Protectores'),
    ('Vidrios Templados / Glass'),
    ('Auriculares y Audio'),
    ('Periféricos y Memorias')
) AS V(Nombre_Categoria)
WHERE NOT EXISTS (
    SELECT 1 
    FROM CategoriaProducto c 
    WHERE c.Nombre_Categoria = V.Nombre_Categoria
);
GO