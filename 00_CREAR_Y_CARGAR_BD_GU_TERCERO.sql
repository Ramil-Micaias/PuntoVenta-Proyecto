USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'GU_Tercero')
BEGIN
    ALTER DATABASE GU_Tercero SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GU_Tercero;
END
GO

CREATE DATABASE GU_Tercero;
GO

USE GU_Tercero;
GO

----------------------------------------
-- 1. CONFIGURACION
----------------------------------------
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
GO

----------------------------------------
-- 2. DATOS PERSONA
----------------------------------------
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
GO

CREATE TABLE TipoTelefono (
    Id_TipoTelefono INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(50) NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE Telefono (
    Id_Telefono INT IDENTITY(1,1) PRIMARY KEY,
    Id_TipoTelefono INT NOT NULL,
    Numero NVARCHAR(15) NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    Fecha_Baja DATETIME NULL,
    FOREIGN KEY (Id_TipoTelefono) REFERENCES TipoTelefono(Id_TipoTelefono),
    UNIQUE (Numero)
);
GO

CREATE TABLE PersonaTelefono (
    Id_PersonaTelefono INT IDENTITY(1,1) PRIMARY KEY,
    Id_Persona INT NOT NULL,
    Id_Telefono INT NOT NULL,
    FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona),
    FOREIGN KEY (Id_Telefono) REFERENCES Telefono(Id_Telefono),
    UNIQUE (Id_Persona, Id_Telefono)
);
GO

CREATE TABLE TipoCorreo (
    Id_TipoCorreo INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(100) NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

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
GO

CREATE TABLE Provincia (
    Id_Provincia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Provincia NVARCHAR(40) NOT NULL UNIQUE,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE Partido (
    Id_Partido INT IDENTITY(1,1) PRIMARY KEY,
    Id_Provincia INT NOT NULL,
    Nombre_Partido NVARCHAR(40) NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Provincia) REFERENCES Provincia(Id_Provincia),
    UNIQUE (Id_Provincia, Nombre_Partido)
);
GO

CREATE TABLE Localidad (
    Id_Localidad INT IDENTITY(1,1) PRIMARY KEY,
    Id_Partido INT NOT NULL,
    Nombre_Localidad NVARCHAR(40) NOT NULL,
    Codigo_Postal NVARCHAR(10) NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Partido) REFERENCES Partido(Id_Partido),
    UNIQUE (Id_Partido, Nombre_Localidad)
);
GO

CREATE TABLE Direccion (
    Id_Direccion INT IDENTITY(1,1) PRIMARY KEY,
    Id_Persona INT NOT NULL,
    Id_Localidad INT NOT NULL,
    Calle NVARCHAR(100) NOT NULL,
    Numero_Calle NVARCHAR(10) NOT NULL,
    Entre_Calles NVARCHAR(100) NULL,
    Departamento NVARCHAR(10) NULL,
    Piso NVARCHAR(5) NULL,
    Referencia NVARCHAR(255) NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona),
    FOREIGN KEY (Id_Localidad) REFERENCES Localidad(Id_Localidad)
);
GO

----------------------------------------
-- 3. GESTION DE USUARIOS
----------------------------------------
CREATE TABLE Rol (
    Id_Rol INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Rol NVARCHAR(30) NOT NULL UNIQUE,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE Permisos (
    Id_Permiso INT PRIMARY KEY IDENTITY(1,1),
    Codigo NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(100) NOT NULL,
    Modulo NVARCHAR(50) NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE RolPermiso (
    Id_Rol INT NOT NULL,
    Id_Permiso INT NOT NULL,
    PRIMARY KEY (Id_Rol, Id_Permiso),
    FOREIGN KEY (Id_Rol) REFERENCES Rol(Id_Rol),
    FOREIGN KEY (Id_Permiso) REFERENCES Permisos(Id_Permiso)
);
GO

CREATE TABLE Usuario (
    Id_Usuario INT PRIMARY KEY IDENTITY(1,1),
    Id_Persona INT NOT NULL,
    Nombre_Usuario NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Es_Primer_Ingreso BIT DEFAULT 1 NOT NULL,
    Debe_Cambiar_Password BIT DEFAULT 0 NOT NULL,
    Intentos_Fallidos INT DEFAULT 0 NOT NULL,
    Bloqueado BIT DEFAULT 0 NOT NULL,
    Fecha_Alta DATETIME DEFAULT GETDATE() NOT NULL,
    Fecha_Creacion DATETIME DEFAULT GETDATE() NOT NULL,
    Fecha_Bloqueo DATETIME NULL,
    Ultimo_Login DATETIME NULL,
    Fecha_UltimoIngreso DATETIME NULL,
    Fecha_Ultimo_Cambio DATETIME NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona)
);
GO

CREATE TABLE UsuarioRol (
    Id_Usuario INT NOT NULL,
    Id_Rol INT NOT NULL,
    Fecha_Asignacion DATETIME DEFAULT GETDATE() NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    PRIMARY KEY (Id_Usuario, Id_Rol),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Rol) REFERENCES Rol(Id_Rol)
);
GO

CREATE TABLE UsuarioPermiso (
    Id_UsuarioPermiso INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Permiso INT NOT NULL,
    Concedido BIT NOT NULL,
    Fecha_Asignacion DATETIME DEFAULT GETDATE() NOT NULL,
    AsignadoPor_Usuario INT NULL,
    Motivo NVARCHAR(255) NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Permiso) REFERENCES Permisos(Id_Permiso),
    FOREIGN KEY (AsignadoPor_Usuario) REFERENCES Usuario(Id_Usuario),
    UNIQUE (Id_Usuario, Id_Permiso)
);
GO

CREATE TABLE PreguntasSeguridad (
    Id_Pregunta INT PRIMARY KEY IDENTITY(1,1),
    Pregunta NVARCHAR(255) NOT NULL UNIQUE,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE UsuarioPreguntaSeguridad (
    Id_Usuario INT NOT NULL,
    Id_Pregunta INT NOT NULL,
    RespuestaHash NVARCHAR(256) NOT NULL,
    PRIMARY KEY (Id_Usuario, Id_Pregunta),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Pregunta) REFERENCES PreguntasSeguridad(Id_Pregunta)
);
GO

CREATE TABLE Codigo2FA (
    Id_Codigo INT PRIMARY KEY IDENTITY(1,1),
    Id_Usuario INT NOT NULL,
    Codigo NVARCHAR(10) NOT NULL,
    Fecha_Creacion DATETIME DEFAULT GETDATE() NOT NULL,
    Fecha_Expiracion DATETIME NOT NULL,
    Usado BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
);
GO

CREATE TABLE HistorialPassword (
    Id_Historial INT PRIMARY KEY IDENTITY(1,1),
    Id_Usuario INT NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Fecha_Cambio DATETIME DEFAULT GETDATE() NOT NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario)
);
GO

CREATE TABLE HistorialUsuario (
    Id_HistorialUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Fecha_Movimiento DATETIME DEFAULT GETDATE() NOT NULL,
    Tipo_Movimiento NVARCHAR(50) NOT NULL,
    RealizadoPor_Usuario INT NULL,
    Motivo NVARCHAR(255) NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (RealizadoPor_Usuario) REFERENCES Usuario(Id_Usuario)
);
GO

----------------------------------------
-- 4. PRODUCTOS Y PROVEEDORES
----------------------------------------
CREATE TABLE CategoriaProducto (
    Id_Categoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Categoria NVARCHAR(50) NOT NULL UNIQUE,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE Proveedor (
    Id_Proveedor INT PRIMARY KEY IDENTITY(1,1),
    Razon_Social NVARCHAR(100) NOT NULL,
    CUIT NVARCHAR(20) NOT NULL UNIQUE,
    Id_Persona INT NULL,
    Direccion NVARCHAR(150) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona)
);
GO

CREATE TABLE Producto (
    Id_Producto INT PRIMARY KEY IDENTITY(1,1),
    Id_Categoria INT NOT NULL,
    Id_Proveedor INT NULL,
    Codigo_Barras NVARCHAR(50) NULL,
    Nombre_Producto NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(120) NULL,
    Precio_Costo DECIMAL(12,2) NOT NULL,
    Precio_Venta DECIMAL(12,2) NOT NULL,
    Stock_Actual INT DEFAULT 0 NOT NULL,
    Stock_Minimo INT DEFAULT 2 NOT NULL,
    Es_Repuesto BIT DEFAULT 1 NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Categoria) REFERENCES CategoriaProducto(Id_Categoria),
    FOREIGN KEY (Id_Proveedor) REFERENCES Proveedor(Id_Proveedor)
);
GO

----------------------------------------
-- STORED PROCEDURES USUARIO & LOGIN
----------------------------------------
CREATE PROCEDURE sp_LoginUsuario
    @NombreUsuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        U.Id_Usuario,
        U.Nombre_Usuario,
        U.PasswordHash,
        U.Activo,
        U.Bloqueado,
        U.Intentos_Fallidos,
        U.Debe_Cambiar_Password,
        U.Es_Primer_Ingreso,
        R.Id_Rol,
        R.Nombre_Rol
    FROM Usuario U
    INNER JOIN UsuarioRol UR ON U.Id_Usuario = UR.Id_Usuario
    INNER JOIN Rol R ON UR.Id_Rol = R.Id_Rol
    WHERE U.Nombre_Usuario = @NombreUsuario;
END;
GO

CREATE PROCEDURE sp_AumentarIntentos
    @IdUsuario INT 
AS
BEGIN 
    SET NOCOUNT ON;
    UPDATE Usuario
    SET Intentos_Fallidos = Intentos_Fallidos + 1
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE PROCEDURE sp_ReiniciarIntentos
    @IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;
    UPDATE Usuario 
    SET Intentos_Fallidos = 0
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE PROCEDURE sp_BloquearUsuario
    @IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;
    UPDATE Usuario
    SET 
        Bloqueado = 0,
        Fecha_Bloqueo = NULL,
        Intentos_Fallidos = 0
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE PROCEDURE sp_ActualizarUltimoLogin
    @IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;
    UPDATE Usuario
    SET Ultimo_Login = GETDATE()
    WHERE Id_Usuario = @IdUsuario;
END;
GO

CREATE PROCEDURE sp_ObtenerConfiguracion
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1
        Id_Configuracion, Nombre_Empresa, Email_Emisor, Min_Caracteres,
        Requiere_Mayusculas, Requiere_Numeros, Requiere_Especial,
        Habilitar_2fa, Validar_DatosPersonales, No_repetirPasswords,
        Cantidad_HistorialPasswords, Cantidad_Preguntas
    FROM ConfiguracionSistema;
END;
GO

----------------------------------------
-- STORED PROCEDURES PRODUCTO
----------------------------------------
CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        p.Id_Producto,
        p.Codigo_Barras,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Costo,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Id_Categoria,
        c.Nombre_Categoria,
        p.Id_Proveedor,
        p.Activo
    FROM Producto p
    INNER JOIN CategoriaProducto c ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Activo = 1
    ORDER BY p.Nombre_Producto ASC;
END
GO

CREATE PROCEDURE sp_ObtenerCategorias
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id_Categoria, Nombre_Categoria
    FROM CategoriaProducto
    WHERE Activo = 1
    ORDER BY Nombre_Categoria ASC;
END
GO

CREATE PROCEDURE sp_BuscarProductos
    @Filtro NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        p.Id_Producto,
        p.Codigo_Barras,
        p.Nombre_Producto,
        p.Descripcion,
        p.Precio_Costo,
        p.Precio_Venta,
        p.Stock_Actual,
        p.Stock_Minimo,
        p.Id_Categoria,
        c.Nombre_Categoria,
        p.Id_Proveedor,
        p.Activo
    FROM Producto p
    INNER JOIN CategoriaProducto c ON p.Id_Categoria = c.Id_Categoria
    WHERE p.Activo = 1 
      AND (p.Nombre_Producto LIKE '%' + @Filtro + '%' 
           OR p.Codigo_Barras LIKE '%' + @Filtro + '%'
           OR c.Nombre_Categoria LIKE '%' + @Filtro + '%')
    ORDER BY p.Nombre_Producto ASC;
END
GO

CREATE PROCEDURE sp_InsertarProducto
    @Id_Categoria INT,
    @Id_Proveedor INT = NULL,
    @Codigo_Barras NVARCHAR(50) = NULL,
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Costo DECIMAL(12,2),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT = 0,
    @Stock_Minimo INT = 2,
    @Es_Repuesto BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Producto (
        Id_Categoria, Id_Proveedor, Codigo_Barras, Nombre_Producto,
        Descripcion, Precio_Costo, Precio_Venta, Stock_Actual,
        Stock_Minimo, Es_Repuesto, Activo
    )
    VALUES (
        @Id_Categoria, @Id_Proveedor, @Codigo_Barras, @Nombre_Producto,
        @Descripcion, @Precio_Costo, @Precio_Venta, @Stock_Actual,
        @Stock_Minimo, @Es_Repuesto, 1
    );
END
GO

CREATE PROCEDURE sp_ModificarProducto
    @Id_Producto INT,
    @Id_Categoria INT,
    @Id_Proveedor INT = NULL,
    @Codigo_Barras NVARCHAR(50) = NULL,
    @Nombre_Producto NVARCHAR(50),
    @Descripcion NVARCHAR(120),
    @Precio_Costo DECIMAL(12,2),
    @Precio_Venta DECIMAL(12,2),
    @Stock_Actual INT,
    @Stock_Minimo INT,
    @Es_Repuesto BIT = 1,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Producto
    SET 
        Id_Categoria = @Id_Categoria,
        Id_Proveedor = @Id_Proveedor,
        Codigo_Barras = @Codigo_Barras,
        Nombre_Producto = @Nombre_Producto,
        Descripcion = @Descripcion,
        Precio_Costo = @Precio_Costo,
        Precio_Venta = @Precio_Venta,
        Stock_Actual = @Stock_Actual,
        Stock_Minimo = @Stock_Minimo,
        Es_Repuesto = @Es_Repuesto,
        Activo = @Activo
    WHERE Id_Producto = @Id_Producto;
END
GO

----------------------------------------
-- DATOS INICIALES
----------------------------------------
INSERT INTO ConfiguracionSistema (Nombre_Empresa, Email_Emisor) VALUES ('ApIBigStore', 'soporte@apibigstore.com');

INSERT INTO Persona (Apellido, Nombre, DNI) VALUES ('Administrador', 'Sistema', '11111111');
DECLARE @idPersona INT = SCOPE_IDENTITY();

INSERT INTO TipoCorreo (Descripcion) VALUES ('Principal');
DECLARE @idTipoCorreo INT = SCOPE_IDENTITY();
INSERT INTO Correo (Id_Persona, Id_TipoCorreo, Direccion_Correo, Verificado, Activo) VALUES (@idPersona, @idTipoCorreo, 'admin@apibigstore.com', 1, 1);

INSERT INTO Rol (Nombre_Rol) VALUES ('Administrador'), ('Usuario');
DECLARE @idRolAdmin INT = (SELECT Id_Rol FROM Rol WHERE Nombre_Rol = 'Administrador');

-- Hash exacto de "admin" + "Esty123" = "adminEsty123" en SHA256: 032af98435e4af8ea959c0242b1427191d9c1aeeb485b9db7d99de8c58997e24
INSERT INTO Usuario (Id_Persona, Nombre_Usuario, PasswordHash, Es_Primer_Ingreso, Debe_Cambiar_Password, Bloqueado, Intentos_Fallidos, Activo)
VALUES (@idPersona, 'admin', '032af98435e4af8ea959c0242b1427191d9c1aeeb485b9db7d99de8c58997e24', 0, 0, 0, 0, 1);
DECLARE @idUsuario INT = SCOPE_IDENTITY();

INSERT INTO UsuarioRol (Id_Usuario, Id_Rol) VALUES (@idUsuario, @idRolAdmin);

INSERT INTO CategoriaProducto (Nombre_Categoria) VALUES ('General'), ('Electrónica'), ('Accesorios'), ('Insumos');
DECLARE @idCat INT = (SELECT TOP 1 Id_Categoria FROM CategoriaProducto);

INSERT INTO Producto (Id_Categoria, Codigo_Barras, Nombre_Producto, Descripcion, Precio_Costo, Precio_Venta, Stock_Actual, Stock_Minimo)
VALUES 
(@idCat, '779000111', 'Teclado USB', 'Teclado estándar USB', 1500.00, 3000.00, 20, 5),
(@idCat, '779000222', 'Mouse Óptico', 'Mouse USB ergonómico', 800.00, 1800.00, 15, 3),
(@idCat, 'SIN-CODIGO', 'Cable HDMI 2m', 'Cable HDMI alta velocidad', 1200.00, 2500.00, 10, 2);
GO
