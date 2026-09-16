USE GU_Tercero;
GO

-----------------------------------------------
-- 1. CONFIGURACIÓN INICIAL DEL SISTEMA      --
-----------------------------------------------

INSERT INTO ConfiguracionSistema (
    Nombre_Empresa,
    Email_Emisor,
    Min_Caracteres,
    Requiere_Mayusculas,
    Requiere_Numeros,
    Requiere_Especial,
    Habilitar_2fa,
    Validar_DatosPersonales,
    No_repetirPasswords,
    Cantidad_HistorialPasswords,
    Cantidad_Preguntas
)
VALUES (
    'Servicio Técnico GU',
    'pinieroesteban01@gmail.com',
    8,
    0,
    0,
    0,
    1,
    1,
    1,
    5,
    3
);
GO

-----------------------------------------------
-- 2. ROLES, MÉTODOS DE PAGO Y ESTADOS      --
-----------------------------------------------

INSERT INTO Rol (Nombre_Rol, Activo) VALUES 
('Administrador', 1),
('Usuario', 1);

INSERT INTO TipoCorreo (Descripcion, Activo) VALUES 
('Personal', 1),
('Laboral', 1);

INSERT INTO MetodoPago (Nombre) VALUES 
('Efectivo'),
('Tarjeta de Débito'),
('Tarjeta de Crédito'),
('Transferencia Bancaria'),
('Mercado Pago');

INSERT INTO EstadoOrden (Nombre_Estado) VALUES 
('Ingresado'),
('En Diagnóstico'),
('Presupuestado'),
('Aprobado'),
('En Reparación'),
('Reparado'),
('Entregado'),
('Cancelado');

INSERT INTO PreguntasSeguridad (Pregunta, Activo) VALUES 
('¿Nombre de tu primera mascota?', 1),
('¿Ciudad donde naciste?', 1),
('¿Comida favorita?', 1);
GO

-----------------------------------------------
-- 3. PERSONA, USUARIO Y ROL ADMIN           --
-----------------------------------------------

INSERT INTO Persona (
    Apellido,
    Nombre,
    DNI,
    Fecha_Alta,
    Fecha_Nacimiento,
    Activo
)
VALUES (
    'Administrador',
    'Sistema',
    '00000000',
    GETDATE(),
    '2000-01-01',
    1
);

DECLARE @IdPersona INT = SCOPE_IDENTITY();

INSERT INTO Usuario (
    Id_Persona,
    Nombre_Usuario,
    PasswordHash,
    Fecha_Ultimo_Cambio,
    Debe_Cambiar_Password,
    Es_Primer_Ingreso,
    Fecha_Alta,
    Intentos_Fallidos,
    Bloqueado,
    Fecha_Bloqueo,
    Ultimo_Login,
    Activo
)
VALUES (
    @IdPersona,
    'admin',
    '032af98435e4af8ea959c0242b1427191d9c1aeeb485b9db7d99de8c58997e24',
    GETDATE(),
    1,
    1,
    GETDATE(),
    0,
    0,
    NULL,
    NULL,
    1
);

DECLARE @IdUsuario INT = SCOPE_IDENTITY();
DECLARE @IdRolAdmin INT = (SELECT Id_Rol FROM Rol WHERE Nombre_Rol = 'Administrador');
DECLARE @IdTipoCorreoPersonal INT = (SELECT Id_TipoCorreo FROM TipoCorreo WHERE Descripcion = 'Personal');

-- Asignación de Rol
INSERT INTO UsuarioRol (
    Id_Rol,
    Id_Usuario,
    Fecha_Asignacion
)
VALUES (
    @IdRolAdmin,
    @IdUsuario,
    GETDATE()
);

-- Correo del Administrador
INSERT INTO Correo (
    Id_Persona,
    Id_TipoCorreo,
    Direccion_Correo,
    Verificado,
    Activo
)
VALUES (
    @IdPersona,
    @IdTipoCorreoPersonal,
    'pinieroesteban01@gmail.com',
    0,
    1
);
GO