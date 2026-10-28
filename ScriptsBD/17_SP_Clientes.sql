USE GU_Tercero;
GO

-- ============================================================
-- MODULO: CLIENTES (consulta para el administrador)
-- Lista todos los clientes del taller, activos o no, con sus datos
-- de contacto, si además son usuarios del sistema y cuántas órdenes tienen.
-- ============================================================

CREATE OR ALTER PROCEDURE sp_ListarClientes
    @Filtro NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    SET @Filtro = LTRIM(RTRIM(ISNULL(@Filtro, '')));

    SELECT
        c.Id_Cliente,
        p.Apellido,
        p.Nombre,
        p.DNI,
        (SELECT TOP 1 t.Numero
         FROM PersonaTelefono pt
         INNER JOIN Telefono t ON t.Id_Telefono = pt.Id_Telefono
         WHERE pt.Id_Persona = p.Id_Persona AND t.Activo = 1) AS Telefono,
        (SELECT TOP 1 co.Direccion_Correo
         FROM Correo co
         WHERE co.Id_Persona = p.Id_Persona AND co.Activo = 1) AS Correo,
        c.Fecha_Alta,
        CASE WHEN u.Id_Usuario IS NULL THEN 'No' ELSE 'Sí (' + u.Nombre_Usuario + ')' END AS Es_Usuario,
        (SELECT COUNT(*)
         FROM OrdenReparacion o
         INNER JOIN Equipo e ON e.Id_Equipo = o.Id_Equipo
         WHERE e.Id_Cliente = c.Id_Cliente) AS Ordenes,
        c.Activo
    FROM Cliente c
    INNER JOIN Persona p ON p.Id_Persona = c.Id_Persona
    LEFT JOIN Usuario u ON u.Id_Persona = p.Id_Persona
    WHERE @Filtro = ''
       OR p.Apellido LIKE '%' + @Filtro + '%'
       OR p.Nombre LIKE '%' + @Filtro + '%'
       OR p.DNI LIKE '%' + @Filtro + '%'
    ORDER BY p.Apellido, p.Nombre;
END
GO
