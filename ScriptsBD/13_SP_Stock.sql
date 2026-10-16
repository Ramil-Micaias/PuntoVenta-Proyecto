USE GU_Tercero;
GO

-- ============================================================
-- MODULO: CONSULTA DE STOCK (CU07)
-- Lista los productos activos con sus existencias.
-- Se puede filtrar por nombre o código, por categoría
-- y mostrar solo los que están en el stock mínimo o por debajo.
-- ============================================================

CREATE OR ALTER PROCEDURE sp_ConsultarStock
    @Filtro NVARCHAR(100) = '',
    @Id_Categoria INT = NULL,
    @SoloBajoMinimo BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SET @Filtro = LTRIM(RTRIM(ISNULL(@Filtro, '')));

    SELECT
        p.Id_Producto,
        ISNULL(NULLIF(p.Codigo_Barras, ''), CONVERT(NVARCHAR(20), p.Id_Producto)) AS Codigo,
        ISNULL(NULLIF(p.Nombre_Producto, ''), p.Descripcion) AS Producto,
        c.Nombre_Categoria AS Categoria,
        p.Precio_Costo,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo
    FROM Producto p
    INNER JOIN CategoriaProducto c ON c.Id_Categoria = p.Id_Categoria
    WHERE p.Activo = 1
      AND (@Id_Categoria IS NULL OR p.Id_Categoria = @Id_Categoria)
      AND (@SoloBajoMinimo = 0 OR p.Stock_Actual <= p.Stock_Minimo)
      AND (
            @Filtro = ''
         OR ISNULL(p.Nombre_Producto, '') LIKE '%' + @Filtro + '%'
         OR ISNULL(p.Descripcion, '') LIKE '%' + @Filtro + '%'
         OR ISNULL(p.Codigo_Barras, '') LIKE '%' + @Filtro + '%'
      )
    ORDER BY p.Nombre_Producto ASC;
END;
GO
