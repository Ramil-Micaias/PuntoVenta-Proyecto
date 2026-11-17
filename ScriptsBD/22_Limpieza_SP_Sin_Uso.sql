USE GU_Tercero;
GO

-- borra los procedimientos que el programa no usa (se sacaron de los scripts el 16/11/2026)
DROP PROCEDURE IF EXISTS sp_AsignarPermisoRol;
DROP PROCEDURE IF EXISTS sp_AsignarProveedorProducto;
DROP PROCEDURE IF EXISTS sp_AsignarRolUsuario;
DROP PROCEDURE IF EXISTS sp_BuscarCliente;
DROP PROCEDURE IF EXISTS sp_BuscarClientes;
DROP PROCEDURE IF EXISTS sp_BuscarProveedores;
DROP PROCEDURE IF EXISTS sp_DesasignarProveedorProducto;
DROP PROCEDURE IF EXISTS sp_ExisteDni;
DROP PROCEDURE IF EXISTS sp_ExpirarCodigo2FA;
DROP PROCEDURE IF EXISTS sp_MercadoPago;
DROP PROCEDURE IF EXISTS sp_ObtenerCantidadUsuarios;
DROP PROCEDURE IF EXISTS sp_ObtenerHistorialUsuario;
DROP PROCEDURE IF EXISTS sp_ObtenerPreguntasSeguridad;
DROP PROCEDURE IF EXISTS sp_ObtenerProductosPorProveedor;
DROP PROCEDURE IF EXISTS sp_ObtenerProveedoresProducto;
DROP PROCEDURE IF EXISTS sp_ObtenerProveedorPorId;
DROP PROCEDURE IF EXISTS sp_ObtenerUltimosLogins;
DROP PROCEDURE IF EXISTS sp_ObtenerUsuariosActivos;
DROP PROCEDURE IF EXISTS sp_ObtenerUsuariosBloqueados;
DROP PROCEDURE IF EXISTS sp_ObtenerUsuariosPorRol;
DROP PROCEDURE IF EXISTS sp_RegistrarHistorialUsuario;
DROP PROCEDURE IF EXISTS sp_Test1;
DROP PROCEDURE IF EXISTS sp_ValidarPreguntaSeguridad;
GO
