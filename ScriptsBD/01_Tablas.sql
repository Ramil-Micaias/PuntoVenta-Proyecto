--------------------------------------------------
-- CREACIÓN DE BASE DE DATOS (SI NO EXISTE)     --
--------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'GU_Tercero')
BEGIN
    CREATE DATABASE GU_Tercero;
END
GO

USE GU_Tercero;
GO

----------------------------------------
-- 1. CONFIGURACION                   --
----------------------------------------

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ConfiguracionSistema')
BEGIN
    CREATE TABLE ConfiguracionSistema (
        Id_Configuracion INT PRIMARY KEY IDENTITY(1,1),
        Nombre_Empresa NVARCHAR(100) DEFAULT 'Servicio Técnico' NOT NULL,
        Email_Emisor NVARCHAR(100) DEFAULT 'soporte@empresa.com' NOT NULL,
        Min_Caracteres INT DEFAULT 8 NOT NULL,
        Requiere_Mayusculas BIT DEFAULT 0 NOT NULL,
        Requiere_Numeros BIT DEFAULT 0 NOT NULL,
        Requiere_Especial BIT DEFAULT 0 NOT NULL,
        Habilitar_2fa BIT DEFAULT 1 NOT NULL,
        Validar_DatosPersonales BIT DEFAULT 1 NOT NULL,
        No_repetirPasswords BIT DEFAULT 1 NOT NULL,
        Cantidad_HistorialPasswords INT DEFAULT 5 NOT NULL,
        Cantidad_Preguntas INT DEFAULT 3 NOT NULL
    );
END
GO

----------------------------------------
-- 2. DATOS PERSONA                   --
----------------------------------------

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Persona')
BEGIN
    CREATE TABLE Persona (
        Id_Persona INT PRIMARY KEY IDENTITY(1,1),
        Apellido NVARCHAR(50) NOT NULL,
        Nombre NVARCHAR(50) NOT NULL,
        DNI NVARCHAR(20) NOT NULL UNIQUE,
        Fecha_Alta DATETIME DEFAULT GETDATE() NOT NULL,
        Fecha_Baja DATETIME NULL,
        Fecha_Nacimiento DATE NULL,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TipoTelefono')
BEGIN
    CREATE TABLE TipoTelefono (
        Id_TipoTelefono INT PRIMARY KEY IDENTITY(1,1),
        Descripcion NVARCHAR(50) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Telefono')
BEGIN
    CREATE TABLE Telefono (
        Id_Telefono INT IDENTITY(1,1) PRIMARY KEY,
        Id_TipoTelefono INT NOT NULL,
        Numero NVARCHAR(15) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        Fecha_Baja DATETIME NULL,
        FOREIGN KEY (Id_TipoTelefono) REFERENCES TipoTelefono(Id_TipoTelefono),
        UNIQUE (Numero)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PersonaTelefono')
BEGIN
    CREATE TABLE PersonaTelefono (
        Id_PersonaTelefono INT IDENTITY(1,1) PRIMARY KEY,
        Id_Persona INT NOT NULL,
        Id_Telefono INT NOT NULL,
        FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona),
        FOREIGN KEY (Id_Telefono) REFERENCES Telefono(Id_Telefono),
        UNIQUE (Id_Persona, Id_Telefono)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TipoCorreo')
BEGIN
    CREATE TABLE TipoCorreo (
        Id_TipoCorreo INT PRIMARY KEY IDENTITY(1,1),
        Descripcion NVARCHAR(100) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Correo')
BEGIN
    CREATE TABLE Correo (
        Id_Correo INT IDENTITY(1,1) PRIMARY KEY,
        Id_Persona INT NOT NULL,
        Id_TipoCorreo INT NOT NULL,
        Direccion_Correo NVARCHAR(255) NOT NULL UNIQUE,
        Verificado BIT DEFAULT 0 NOT NULL,
        Fecha_Verificacion DATE NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_TipoCorreo) REFERENCES TipoCorreo(Id_TipoCorreo),
        FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Provincia')
BEGIN
    CREATE TABLE Provincia (
        Id_Provincia INT IDENTITY(1,1) PRIMARY KEY,
        Nombre_Provincia NVARCHAR(40) NOT NULL UNIQUE,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Partido')
BEGIN
    CREATE TABLE Partido (
        Id_Partido INT IDENTITY(1,1) PRIMARY KEY,
        Id_Provincia INT NOT NULL,
        Nombre_Partido NVARCHAR(40) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Provincia) REFERENCES Provincia(Id_Provincia),
        UNIQUE (Id_Provincia, Nombre_Partido)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Localidad')
BEGIN
    CREATE TABLE Localidad (
        Id_Localidad INT IDENTITY(1,1) PRIMARY KEY,
        Id_Partido INT NOT NULL,
        Nombre_Localidad NVARCHAR(40) NOT NULL,
        Codigo_Postal NVARCHAR(10) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Partido) REFERENCES Partido(Id_Partido),
        UNIQUE (Id_Partido, Nombre_Localidad)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Direccion')
BEGIN
    CREATE TABLE Direccion (
        Id_Direccion INT IDENTITY(1,1) PRIMARY KEY,
        Id_Localidad INT NOT NULL,
        Calle NVARCHAR(40) NOT NULL,
        Numero_Calle NVARCHAR(15) NOT NULL,
        Entre_Calles NVARCHAR(80) NULL,
        Departamento NVARCHAR(10) NULL,
        Piso NVARCHAR(10) NULL,
        Referencia NVARCHAR(100) NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Localidad) REFERENCES Localidad(Id_Localidad)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PersonaDireccion')
BEGIN
    CREATE TABLE PersonaDireccion (
        Id_PersonaDireccion INT IDENTITY(1,1) PRIMARY KEY,
        Id_Persona INT NOT NULL,
        Id_Direccion INT NOT NULL,
        FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona),
        FOREIGN KEY (Id_Direccion) REFERENCES Direccion(Id_Direccion),
        UNIQUE (Id_Persona, Id_Direccion)
    );
END
GO

----------------------------------------
-- 3. USUARIO Y SEGURIDAD             --
----------------------------------------

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Usuario')
BEGIN
    CREATE TABLE Usuario (
        Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
        Id_Persona INT NOT NULL UNIQUE,
        Nombre_Usuario NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(255) NOT NULL,
        Fecha_Ultimo_Cambio DATETIME DEFAULT GETDATE() NOT NULL,
        Debe_Cambiar_Password BIT DEFAULT 1 NOT NULL,
        Es_Primer_Ingreso BIT DEFAULT 1 NOT NULL,
        Fecha_Alta DATETIME DEFAULT GETDATE() NOT NULL,
        Fecha_Baja DATETIME NULL,
        Intentos_Fallidos INT DEFAULT 0 NOT NULL,
        Bloqueado BIT DEFAULT 0 NOT NULL,
        Fecha_Bloqueo DATETIME NULL,
        Ultimo_Login DATETIME NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Rol')
BEGIN
    CREATE TABLE Rol (
        Id_Rol INT IDENTITY(1,1) PRIMARY KEY,
        Nombre_Rol NVARCHAR(30) NOT NULL UNIQUE,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Permisos')
BEGIN
    CREATE TABLE Permisos (
        Id_Permiso INT IDENTITY(1,1) PRIMARY KEY,
        Codigo NVARCHAR(100) NOT NULL UNIQUE,
        Descripcion NVARCHAR(200) NOT NULL,
        Modulo NVARCHAR(100) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RolPermiso')
BEGIN
    CREATE TABLE RolPermiso (
        Id_RolPermiso INT IDENTITY(1,1) PRIMARY KEY,
        Id_Rol INT NOT NULL,
        Id_Permiso INT NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Rol) REFERENCES Rol(Id_Rol),
        FOREIGN KEY (Id_Permiso) REFERENCES Permisos(Id_Permiso),
        UNIQUE (Id_Rol, Id_Permiso)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UsuarioRol')
BEGIN
    CREATE TABLE UsuarioRol (
        Id_UsuarioRol INT IDENTITY(1,1) PRIMARY KEY,
        Id_Rol INT NOT NULL,
        Id_Usuario INT NOT NULL,
        Fecha_Asignacion DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (Id_Rol) REFERENCES Rol(Id_Rol),
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
        UNIQUE (Id_Usuario, Id_Rol)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UsuarioPermiso')
BEGIN
    CREATE TABLE UsuarioPermiso (
        Id_UsuarioPermiso INT IDENTITY(1,1) PRIMARY KEY,
        Id_Permiso INT NOT NULL,
        Id_Usuario INT NOT NULL,
        Concedido BIT DEFAULT 1 NOT NULL,
        Motivo NVARCHAR(200) NULL,
        FOREIGN KEY (Id_Permiso) REFERENCES Permisos(Id_Permiso),
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
        UNIQUE (Id_Usuario, Id_Permiso)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Codigo2FA')
BEGIN
    CREATE TABLE Codigo2FA (
        Id_Codigo2FA INT IDENTITY(1,1) PRIMARY KEY,
        Id_Usuario INT NOT NULL,
        Codigo NVARCHAR(10) NOT NULL,
        Fecha_Generacion DATETIME DEFAULT GETDATE() NOT NULL,
        Fecha_Expiracion DATETIME NOT NULL,
        Usado BIT DEFAULT 0 NOT NULL,
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HistorialUsuario')
BEGIN
    CREATE TABLE HistorialUsuario (
        Id_HistorialUsuario INT IDENTITY(1,1) PRIMARY KEY,
        Id_Usuario INT NOT NULL,
        Tipo_Movimiento NVARCHAR(20) NOT NULL,
        Fecha_Movimiento DATETIME DEFAULT GETDATE() NOT NULL,
        Motivo NVARCHAR(255) NULL,
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HistorialPassword')
BEGIN
    CREATE TABLE HistorialPassword (
        Id_HistorialPassword INT IDENTITY(1,1) PRIMARY KEY,
        Id_Usuario INT NOT NULL,
        PasswordHash NVARCHAR(255) NOT NULL,
        Fecha_Cambio DATETIME DEFAULT GETDATE() NOT NULL,
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PreguntasSeguridad')
BEGIN
    CREATE TABLE PreguntasSeguridad (
        Id_Pregunta INT IDENTITY(1,1) PRIMARY KEY,
        Pregunta NVARCHAR(200) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UsuarioPreguntaSeguridad')
BEGIN
    CREATE TABLE UsuarioPreguntaSeguridad (
        Id_UsuarioPregunta INT IDENTITY(1,1) PRIMARY KEY,
        Id_Usuario INT NOT NULL,
        Id_Pregunta INT NOT NULL,
        RespuestaHash NVARCHAR(255) NOT NULL,
        Activo BIT DEFAULT 1 NOT NULL,
        FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
        FOREIGN KEY (Id_Pregunta) REFERENCES PreguntasSeguridad(Id_Pregunta),
        UNIQUE (Id_Usuario, Id_Pregunta)
    );
END
GO