USE GU_Tercero;
GO

------------------------------------------
-- 1. CLIENTE Y EQUIPO                  --
------------------------------------------

CREATE TABLE Cliente (
    Id_Cliente INT IDENTITY(1,1) PRIMARY KEY,
    Id_Persona INT NOT NULL UNIQUE,
    Observaciones NVARCHAR(255) NULL,
    Fecha_Alta DATETIME DEFAULT GETDATE() NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Persona) REFERENCES Persona(Id_Persona)
);
GO

CREATE TABLE Equipo (
    Id_Equipo INT IDENTITY(1,1) PRIMARY KEY,
    Id_Cliente INT NOT NULL,
    Tipo_Dispositivo NVARCHAR(50) NOT NULL,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(80) NOT NULL,
    Numero_Serie NVARCHAR(50) NULL,
    IMEI NVARCHAR(20) NULL,
    Color NVARCHAR(30) NULL,
    Fecha_Registro DATETIME DEFAULT GETDATE() NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente)
);
GO

------------------------------------------
-- 2. PROVEEDOR, CATEGORIA Y PRODUCTO    --
------------------------------------------

CREATE TABLE Proveedor (
    Id_Proveedor INT IDENTITY(1,1) PRIMARY KEY,
    Razon_Social NVARCHAR(100) NOT NULL,
    CUIT NVARCHAR(20) NULL UNIQUE,
    Telefono NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL,
    Direccion NVARCHAR(150) NULL,
    Fecha_Alta DATETIME DEFAULT GETDATE() NOT NULL,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE CategoriaProducto (
    Id_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Categoria NVARCHAR(50) NOT NULL UNIQUE,
    Activo BIT DEFAULT 1 NOT NULL
);
GO

CREATE TABLE Producto (
    Id_Producto INT IDENTITY(1,1) PRIMARY KEY,
    Id_Categoria INT NOT NULL,
    Id_Proveedor INT NULL,
    Codigo_Barras NVARCHAR(50) NULL UNIQUE,
    Nombre_Producto NVARCHAR(50) NULL,
    Descripcion NVARCHAR(120) NOT NULL,
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

------------------------------------------
-- 3. ORDENES DE REPARACION             --
------------------------------------------

CREATE TABLE EstadoOrden (
    Id_Estado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Estado NVARCHAR(40) NOT NULL UNIQUE
);
GO

CREATE TABLE OrdenReparacion (
    Id_Orden INT IDENTITY(1,1) PRIMARY KEY,
    Id_Equipo INT NOT NULL,
    Id_Tecnico INT NULL,
    Id_Usuario_Recepcion INT NOT NULL,
    Id_Estado INT DEFAULT 1 NOT NULL,
    Falla_Declarada NVARCHAR(500) NOT NULL,
    Patron_Clave_Desbloqueo NVARCHAR(50) NULL,
    Diagnostico_Tecnico NVARCHAR(500) NULL,
    Costo_Mano_Obra DECIMAL(12,2) DEFAULT 0 NOT NULL,
    Total_Presupuesto DECIMAL(12,2) DEFAULT 0 NOT NULL,
    Fecha_Ingreso DATETIME DEFAULT GETDATE() NOT NULL,
    Fecha_Prometida DATE NULL,
    Fecha_Finalizado DATETIME NULL,
    Fecha_Entrega DATETIME NULL,
    FOREIGN KEY (Id_Equipo) REFERENCES Equipo(Id_Equipo),
    FOREIGN KEY (Id_Tecnico) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Usuario_Recepcion) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Estado) REFERENCES EstadoOrden(Id_Estado)
);
GO

CREATE TABLE DetalleOrdenRepuesto (
    Id_DetalleRepuesto INT IDENTITY(1,1) PRIMARY KEY,
    Id_Orden INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT DEFAULT 1 NOT NULL,
    Precio_Unitario DECIMAL(12,2) NOT NULL,
    Subtotal AS (Cantidad * Precio_Unitario),
    FOREIGN KEY (Id_Orden) REFERENCES OrdenReparacion(Id_Orden),
    FOREIGN KEY (Id_Producto) REFERENCES Producto(Id_Producto)
);
GO

------------------------------------------
-- 4. METODO DE PAGO Y VENTAS           --
------------------------------------------

CREATE TABLE MetodoPago (
    Id_MetodoPago INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Venta (
    Id_Venta INT IDENTITY(1,1) PRIMARY KEY,
    Numero_Factura NVARCHAR(20) NULL,
    Id_Cliente INT NULL,
    Id_Usuario_Vendedor INT NOT NULL,
    Id_MetodoPago INT NOT NULL,
    Id_Orden_Reparacion INT NULL,
    Total DECIMAL(12,2) NOT NULL,
    Fecha_Venta DATETIME DEFAULT GETDATE() NOT NULL,
    Anulada BIT DEFAULT 0 NOT NULL,
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id_Cliente),
    FOREIGN KEY (Id_Usuario_Vendedor) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_MetodoPago) REFERENCES MetodoPago(Id_MetodoPago),
    FOREIGN KEY (Id_Orden_Reparacion) REFERENCES OrdenReparacion(Id_Orden)
);
GO

CREATE TABLE DetalleVenta (
    Id_DetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    Id_Venta INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Unitario DECIMAL(12,2) NOT NULL,
    Subtotal AS (Cantidad * Precio_Unitario),
    FOREIGN KEY (Id_Venta) REFERENCES Venta(Id_Venta),
    FOREIGN KEY (Id_Producto) REFERENCES Producto(Id_Producto)
);
GO

------------------------------------------
-- 5. COMPRAS Y DETALLE DE COMPRA       --
------------------------------------------

CREATE TABLE Compra (
    Id_Compra INT IDENTITY(1,1) PRIMARY KEY,
    Numero_Comprobante NVARCHAR(50) NULL,
    Id_Proveedor INT NOT NULL,
    Id_Usuario INT NOT NULL,
    Id_MetodoPago INT NOT NULL,
    Total DECIMAL(12,2) NOT NULL,
    Fecha_Compra DATETIME DEFAULT GETDATE() NOT NULL,
    Estado BIT DEFAULT 1 NOT NULL,
    FOREIGN KEY (Id_Proveedor) REFERENCES Proveedor(Id_Proveedor),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_MetodoPago) REFERENCES MetodoPago(Id_MetodoPago)
);
GO

CREATE TABLE DetalleCompra (
    Id_DetalleCompra INT IDENTITY(1,1) PRIMARY KEY,
    Id_Compra INT NOT NULL,
    Id_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio_Costo_Unitario DECIMAL(12,2) NOT NULL,
    Subtotal AS (Cantidad * Precio_Costo_Unitario),
    FOREIGN KEY (Id_Compra) REFERENCES Compra(Id_Compra),
    FOREIGN KEY (Id_Producto) REFERENCES Producto(Id_Producto)
);
GO