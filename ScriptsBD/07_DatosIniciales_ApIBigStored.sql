USE GU_Tercero;
GO

------------------------------------------
-- 1. TABLAS MAESTRAS SIN DEPENDENCIAS
------------------------------------------

-- Categorías de Productos
IF NOT EXISTS (
    SELECT 1 
    FROM CategoriaProducto 
    WHERE Nombre_Categoria = 'Fundas y Protectores'
)
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
    VALUES ('Fundas y Protectores', 1);

IF NOT EXISTS (
    SELECT 1 
    FROM CategoriaProducto 
    WHERE Nombre_Categoria = 'Cargadores y Cables'
)
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
    VALUES ('Cargadores y Cables', 1);

IF NOT EXISTS (
    SELECT 1 
    FROM CategoriaProducto 
    WHERE Nombre_Categoria = 'Módulos y Pantallas'
)
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
    VALUES ('Módulos y Pantallas', 1);

IF NOT EXISTS (
    SELECT 1 
    FROM CategoriaProducto 
    WHERE Nombre_Categoria = 'Baterías'
)
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
    VALUES ('Baterías', 1);

IF NOT EXISTS (
    SELECT 1 
    FROM CategoriaProducto 
    WHERE Nombre_Categoria = 'Auriculares'
)
    INSERT INTO CategoriaProducto (Nombre_Categoria, Activo)
    VALUES ('Auriculares', 1);
GO


-- Proveedores
IF NOT EXISTS (
    SELECT 1 
    FROM Proveedor 
    WHERE CUIT = '30-71234567-8'
)
    INSERT INTO Proveedor (
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Activo
    )
    VALUES (
        'Distribuidora Mobile S.A.',
        '30-71234567-8',
        '011-4321-8765',
        'ventas@distrimobile.com',
        'Av. Corrientes 1234, CABA',
        1
    );

IF NOT EXISTS (
    SELECT 1 
    FROM Proveedor 
    WHERE CUIT = '30-88765432-1'
)
    INSERT INTO Proveedor (
        Razon_Social,
        CUIT,
        Telefono,
        Email,
        Direccion,
        Activo
    )
    VALUES (
        'Importadora Repuestos Tech',
        '30-88765432-1',
        '011-5555-0199',
        'contacto@repuestostech.com.ar',
        'Calle 14 Nro 850, La Plata',
        1
    );
GO


------------------------------------------
-- 2. CLIENTE Y EQUIPOS
------------------------------------------

DECLARE @IdPersonaAdmin INT =
(
    SELECT TOP 1 Id_Persona
    FROM Persona
    WHERE DNI = '00000000'
);

DECLARE @IdCliente INT;

IF @IdPersonaAdmin IS NOT NULL
BEGIN

    IF NOT EXISTS (
        SELECT 1
        FROM Cliente
        WHERE Id_Persona = @IdPersonaAdmin
    )
    BEGIN
        INSERT INTO Cliente (
            Id_Persona,
            Observaciones,
            Activo
        )
        VALUES (
            @IdPersonaAdmin,
            'Cliente frecuente - Descuento en mano de obra',
            1
        );

        SET @IdCliente = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        SET @IdCliente =
        (
            SELECT Id_Cliente
            FROM Cliente
            WHERE Id_Persona = @IdPersonaAdmin
        );
    END;


    -- Equipos del cliente
    IF NOT EXISTS (
        SELECT 1
        FROM Equipo
        WHERE IMEI = '356789012345678'
    )
        INSERT INTO Equipo (
            Id_Cliente,
            Tipo_Dispositivo,
            Marca,
            Modelo,
            Numero_Serie,
            IMEI,
            Color,
            Activo
        )
        VALUES (
            @IdCliente,
            'Celular',
            'Apple',
            'iPhone 13',
            'DN4F1234567',
            '356789012345678',
            'Negro',
            1
        );


    IF NOT EXISTS (
        SELECT 1
        FROM Equipo
        WHERE IMEI = '864209087654321'
    )
        INSERT INTO Equipo (
            Id_Cliente,
            Tipo_Dispositivo,
            Marca,
            Modelo,
            Numero_Serie,
            IMEI,
            Color,
            Activo
        )
        VALUES (
            @IdCliente,
            'Celular',
            'Samsung',
            'Galaxy A54',
            'R58M901234X',
            '864209087654321',
            'Azul',
            1
        );

END;
GO


------------------------------------------
-- 3. PRODUCTOS Y REPUESTOS
------------------------------------------

DECLARE @IdCatFundas INT =
(
    SELECT Id_Categoria
    FROM CategoriaProducto
    WHERE Nombre_Categoria = 'Fundas y Protectores'
);

DECLARE @IdCatCargadores INT =
(
    SELECT Id_Categoria
    FROM CategoriaProducto
    WHERE Nombre_Categoria = 'Cargadores y Cables'
);

DECLARE @IdCatModulos INT =
(
    SELECT Id_Categoria
    FROM CategoriaProducto
    WHERE Nombre_Categoria = 'Módulos y Pantallas'
);

DECLARE @IdCatBaterias INT =
(
    SELECT Id_Categoria
    FROM CategoriaProducto
    WHERE Nombre_Categoria = 'Baterías'
);


DECLARE @IdProvMobile INT =
(
    SELECT Id_Proveedor
    FROM Proveedor
    WHERE CUIT = '30-71234567-8'
);

DECLARE @IdProvTech INT =
(
    SELECT Id_Proveedor
    FROM Proveedor
    WHERE CUIT = '30-88765432-1'
);


-- Producto 1
IF NOT EXISTS (
    SELECT 1
    FROM Producto
    WHERE Nombre_Producto = 'Funda Silicona'
)
BEGIN
    INSERT INTO Producto (
        Id_Categoria,
        Nombre_Producto,
        Descripcion,
        Precio_Venta,
        Stock_Actual,
        Stock_Minimo,
        Es_Repuesto,
        Activo
    )
    VALUES (
        @IdCatFundas,
        'Funda Silicona',
        'Funda Silicona Antigolpe iPhone 13',
        6500.00,
        15,
        3,
        0,
        1
    );
END;


-- Producto 2
IF NOT EXISTS (
    SELECT 1
    FROM Producto
    WHERE Nombre_Producto = 'Cargador 20W'
)
BEGIN
    INSERT INTO Producto (
        Id_Categoria,
        Nombre_Producto,
        Descripcion,
        Precio_Venta,
        Stock_Actual,
        Stock_Minimo,
        Es_Repuesto,
        Activo
    )
    VALUES (
        @IdCatCargadores,
        'Cargador 20W',
        'Cargador Carga Rápida USB-C 20W',
        9900.00,
        10,
        2,
        0,
        1
    );
END;


-- Producto 3
IF NOT EXISTS (
    SELECT 1
    FROM Producto
    WHERE Nombre_Producto = 'Módulo iPhone 13'
)
BEGIN
    INSERT INTO Producto (
        Id_Categoria,
        Nombre_Producto,
        Descripcion,
        Precio_Venta,
        Stock_Actual,
        Stock_Minimo,
        Es_Repuesto,
        Activo
    )
    VALUES (
        @IdCatModulos,
        'Módulo iPhone 13',
        'Módulo Display Completo iPhone 13',
        68000.00,
        4,
        1,
        1,
        1
    );
END;


-- Producto 4
IF NOT EXISTS (
    SELECT 1
    FROM Producto
    WHERE Nombre_Producto = 'Batería Samsung A54'
)
BEGIN
    INSERT INTO Producto (
        Id_Categoria,
        Nombre_Producto,
        Descripcion,
        Precio_Venta,
        Stock_Actual,
        Stock_Minimo,
        Es_Repuesto,
        Activo
    )
    VALUES (
        @IdCatBaterias,
        'Batería Samsung A54',
        'Batería Homologada Samsung A54',
        24000.00,
        6,
        2,
        1,
        1
    );
END;
GO


------------------------------------------
-- 3.1 RELACIÓN PRODUCTO - PROVEEDOR
------------------------------------------

DECLARE @IdProductoFunda INT =
(
    SELECT Id_Producto
    FROM Producto
    WHERE Nombre_Producto = 'Funda Silicona'
);

DECLARE @IdProductoCargador INT =
(
    SELECT Id_Producto
    FROM Producto
    WHERE Nombre_Producto = 'Cargador 20W'
);

DECLARE @IdProductoModulo INT =
(
    SELECT Id_Producto
    FROM Producto
    WHERE Nombre_Producto = 'Módulo iPhone 13'
);

DECLARE @IdProductoBateria INT =
(
    SELECT Id_Producto
    FROM Producto
    WHERE Nombre_Producto = 'Batería Samsung A54'
);


IF @IdProductoFunda IS NOT NULL
AND @IdProvMobile IS NOT NULL
AND NOT EXISTS (
    SELECT 1
    FROM ProductoProveedor
    WHERE Id_Producto = @IdProductoFunda
      AND Id_Proveedor = @IdProvMobile
)
BEGIN
    INSERT INTO ProductoProveedor (
        Id_Producto,
        Id_Proveedor,
        Activo
    )
    VALUES (
        @IdProductoFunda,
        @IdProvMobile,
        1
    );
END;


IF @IdProductoCargador IS NOT NULL
AND @IdProvMobile IS NOT NULL
AND NOT EXISTS (
    SELECT 1
    FROM ProductoProveedor
    WHERE Id_Producto = @IdProductoCargador
      AND Id_Proveedor = @IdProvMobile
)
BEGIN
    INSERT INTO ProductoProveedor (
        Id_Producto,
        Id_Proveedor,
        Activo
    )
    VALUES (
        @IdProductoCargador,
        @IdProvMobile,
        1
    );
END;


IF @IdProductoModulo IS NOT NULL
AND @IdProvTech IS NOT NULL
AND NOT EXISTS (
    SELECT 1
    FROM ProductoProveedor
    WHERE Id_Producto = @IdProductoModulo
      AND Id_Proveedor = @IdProvTech
)
BEGIN
    INSERT INTO ProductoProveedor (
        Id_Producto,
        Id_Proveedor,
        Activo
    )
    VALUES (
        @IdProductoModulo,
        @IdProvTech,
        1
    );
END;


IF @IdProductoBateria IS NOT NULL
AND @IdProvTech IS NOT NULL
AND NOT EXISTS (
    SELECT 1
    FROM ProductoProveedor
    WHERE Id_Producto = @IdProductoBateria
      AND Id_Proveedor = @IdProvTech
)
BEGIN
    INSERT INTO ProductoProveedor (
        Id_Producto,
        Id_Proveedor,
        Activo
    )
    VALUES (
        @IdProductoBateria,
        @IdProvTech,
        1
    );
END;
GO


------------------------------------------
-- 4. ORDEN DE REPARACIÓN Y DETALLE
------------------------------------------

DECLARE @IdEquipo INT =
(
    SELECT TOP 1
        Id_Equipo
    FROM Equipo
    WHERE Modelo = 'iPhone 13'
);

DECLARE @IdUsuarioAdmin INT =
(
    SELECT TOP 1
        Id_Usuario
    FROM Usuario
    WHERE Nombre_Usuario = 'admin'
);

DECLARE @IdEstadoReparacion INT =
(
    SELECT Id_Estado
    FROM EstadoOrden
    WHERE Nombre_Estado = 'En Reparación'
);

DECLARE @IdProductoModuloOrden INT =
(
    SELECT Id_Producto
    FROM Producto
    WHERE Nombre_Producto = 'Módulo iPhone 13'
);


IF NOT EXISTS (
    SELECT 1
    FROM OrdenReparacion
    WHERE Id_Equipo = @IdEquipo
      AND Falla_Declarada =
          'Pantalla rota por caída y no da imagen.'
)
BEGIN

    INSERT INTO OrdenReparacion (
        Id_Equipo,
        Id_Tecnico,
        Id_Usuario_Recepcion,
        Id_Estado,
        Falla_Declarada,
        Patron_Clave_Desbloqueo,
        Diagnostico_Tecnico,
        Costo_Mano_Obra,
        Total_Presupuesto,
        Fecha_Prometida
    )
    VALUES (
        @IdEquipo,
        @IdUsuarioAdmin,
        @IdUsuarioAdmin,
        @IdEstadoReparacion,
        'Pantalla rota por caída y no da imagen.',
        'Patrón en L',
        'Se requiere cambio completo de módulo OLED.',
        15000.00,
        83000.00,
        '2026-09-10'
    );


    DECLARE @IdOrden INT = SCOPE_IDENTITY();


    INSERT INTO DetalleOrdenRepuesto (
        Id_Orden,
        Id_Producto,
        Cantidad,
        Precio_Unitario
    )
    VALUES (
        @IdOrden,
        @IdProductoModuloOrden,
        1,
        68000.00
    );

END;
GO


------------------------------------------
-- 5. VENTA Y DETALLE DE VENTA
------------------------------------------

IF NOT EXISTS (
    SELECT 1
    FROM Venta
    WHERE Numero_Factura = 'FAC-B-0001-00000001'
)
BEGIN

    DECLARE @IdClienteVenta INT =
    (
        SELECT TOP 1
            Id_Cliente
        FROM Cliente
    );

    DECLARE @IdUsuarioAdminVenta INT =
    (
        SELECT TOP 1
            Id_Usuario
        FROM Usuario
        WHERE Nombre_Usuario = 'admin'
    );

    DECLARE @IdMetodoPagoEfectivo INT =
    (
        SELECT Id_MetodoPago
        FROM MetodoPago
        WHERE Nombre = 'Efectivo'
    );


    DECLARE @IdProd1 INT =
    (
        SELECT Id_Producto
        FROM Producto
        WHERE Nombre_Producto = 'Funda Silicona'
    );

    DECLARE @IdProd2 INT =
    (
        SELECT Id_Producto
        FROM Producto
        WHERE Nombre_Producto = 'Cargador 20W'
    );


    INSERT INTO Venta (
        Numero_Factura,
        Id_Cliente,
        Id_Usuario_Vendedor,
        Id_MetodoPago,
        Id_Orden_Reparacion,
        Total,
        Anulada
    )
    VALUES (
        'FAC-B-0001-00000001',
        @IdClienteVenta,
        @IdUsuarioAdminVenta,
        @IdMetodoPagoEfectivo,
        NULL,
        16400.00,
        0
    );


    DECLARE @IdVenta INT = SCOPE_IDENTITY();


    INSERT INTO DetalleVenta (
        Id_Venta,
        Id_Producto,
        Cantidad,
        Precio_Unitario
    )
    VALUES
    (
        @IdVenta,
        @IdProd1,
        1,
        6500.00
    ),
    (
        @IdVenta,
        @IdProd2,
        1,
        9900.00
    );

END;
GO