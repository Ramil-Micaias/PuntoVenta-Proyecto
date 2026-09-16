USE GU_Tercero;
GO

----------------------------------------
-- 1. CONFIGURACIÓN DEL SISTEMA        --
----------------------------------------

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
    'soporte@empresa.com',
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

----------------------------------------
-- 2. ESTADOS DE ÓRDENES DE REPARACIÓN --
----------------------------------------

INSERT INTO EstadoOrden (Nombre_Estado) VALUES 
('Ingresado'),
('En Diagnóstico'),
('Presupuestado'),
('Aprobado'),
('En Reparación'),
('Reparado'),
('Entregado'),
('Cancelado');
GO

----------------------------------------
-- 3. MÉTODOS DE PAGO                 --
----------------------------------------

INSERT INTO MetodoPago (Nombre) VALUES 
('Efectivo'),
('Tarjeta de Débito'),
('Tarjeta de Crédito'),
('Transferencia Bancaria'),
('Mercado Pago');
GO

----------------------------------------
-- 4. PERSONA, USUARIO Y ROL ADMIN    --
----------------------------------------

-- Crear Rol Administrador
INSERT INTO Rol (Nombre_Rol) VALUES ('Administrador');

-- Crear Persona Inicial
INSERT INTO Persona (Apellido, Nombre, DNI) 
VALUES ('Administrador', 'Sistema', '00000000');

DECLARE @IdPersonaAdmin INT = SCOPE_IDENTITY();
DECLARE @IdRolAdmin INT = (SELECT Id_Rol FROM Rol WHERE Nombre_Rol = 'Administrador');

-- Crear Usuario Admin (Contraseña inicial por defecto)
INSERT INTO Usuario (
    Id_Persona, 
    Nombre_Usuario, 
    PasswordHash, 
    Debe_Cambiar_Password, 
    Es_Primer_Ingreso
)
VALUES (
    @IdPersonaAdmin, 
    'admin', 
    '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 
    0, 
    0
);

DECLARE @IdUsuarioAdmin INT = SCOPE_IDENTITY();

-- Asignar Rol Admin al Usuario
INSERT INTO UsuarioRol (Id_Rol, Id_Usuario) 
VALUES (@IdRolAdmin, @IdUsuarioAdmin);
GO