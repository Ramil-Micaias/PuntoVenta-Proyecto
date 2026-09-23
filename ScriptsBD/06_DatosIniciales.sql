USE GU_Tercero;
GO

-----------------------------------------------
-- 1. CONFIGURACIÓN INICIAL DEL SISTEMA      --
-----------------------------------------------

IF NOT EXISTS (SELECT 1 FROM ConfiguracionSistema)
BEGIN
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
END;
GO

-----------------------------------------------
-- 2. ROLES, MÉTODOS DE PAGO Y ESTADOS      --
-----------------------------------------------

-- Roles
IF NOT EXISTS (SELECT 1 FROM Rol WHERE Nombre_Rol = 'Administrador')
    INSERT INTO Rol (Nombre_Rol, Activo) VALUES ('Administrador', 1);

IF NOT EXISTS (SELECT 1 FROM Rol WHERE Nombre_Rol = 'Usuario')
    INSERT INTO Rol (Nombre_Rol, Activo) VALUES ('Usuario', 1);

-- Tipos de Correo
IF NOT EXISTS (SELECT 1 FROM TipoCorreo WHERE Descripcion = 'Personal')
    INSERT INTO TipoCorreo (Descripcion, Activo) VALUES ('Personal', 1);

IF NOT EXISTS (SELECT 1 FROM TipoCorreo WHERE Descripcion = 'Laboral')
    INSERT INTO TipoCorreo (Descripcion, Activo) VALUES ('Laboral', 1);

-- Métodos de Pago
IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Nombre = 'Efectivo')
    INSERT INTO MetodoPago (Nombre) VALUES ('Efectivo');

IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Nombre = 'Tarjeta de Débito')
    INSERT INTO MetodoPago (Nombre) VALUES ('Tarjeta de Débito');

IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Nombre = 'Tarjeta de Crédito')
    INSERT INTO MetodoPago (Nombre) VALUES ('Tarjeta de Crédito');

IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Nombre = 'Transferencia Bancaria')
    INSERT INTO MetodoPago (Nombre) VALUES ('Transferencia Bancaria');

IF NOT EXISTS (SELECT 1 FROM MetodoPago WHERE Nombre = 'Mercado Pago')
    INSERT INTO MetodoPago (Nombre) VALUES ('Mercado Pago');

-- Estados de Orden
IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'Ingresado')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('Ingresado');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'En Diagnóstico')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('En Diagnóstico');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'Presupuestado')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('Presupuestado');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'Aprobado')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('Aprobado');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'En Reparación')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('En Reparación');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'Reparado')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('Reparado');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'Entregado')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('Entregado');

IF NOT EXISTS (SELECT 1 FROM EstadoOrden WHERE Nombre_Estado = 'Cancelado')
    INSERT INTO EstadoOrden (Nombre_Estado) VALUES ('Cancelado');

-- Preguntas de Seguridad
IF NOT EXISTS (SELECT 1 FROM PreguntasSeguridad WHERE Pregunta = '¿Nombre de tu primera mascota?')
    INSERT INTO PreguntasSeguridad (Pregunta, Activo) VALUES ('¿Nombre de tu primera mascota?', 1);

IF NOT EXISTS (SELECT 1 FROM PreguntasSeguridad WHERE Pregunta = '¿Ciudad donde naciste?')
    INSERT INTO PreguntasSeguridad (Pregunta, Activo) VALUES ('¿Ciudad donde naciste?', 1);

IF NOT EXISTS (SELECT 1 FROM PreguntasSeguridad WHERE Pregunta = '¿Comida favorita?')
    INSERT INTO PreguntasSeguridad (Pregunta, Activo) VALUES ('¿Comida favorita?', 1);
GO

-----------------------------------------------
-- 3. PERSONA, USUARIO Y ROL ADMIN           --
-----------------------------------------------

IF NOT EXISTS (SELECT 1 FROM Usuario WHERE Nombre_Usuario = 'admin')
BEGIN
    DECLARE @IdPersona INT;
    DECLARE @IdUsuario INT;
    DECLARE @IdRolAdmin INT;
    DECLARE @IdTipoCorreoPersonal INT;

    -- 1. Insertar Persona Admin
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

    SET @IdPersona = SCOPE_IDENTITY();

    -- 2. Insertar Usuario Admin
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

    SET @IdUsuario = SCOPE_IDENTITY();

    -- 3. Obtener IDs auxiliares
    SELECT @IdRolAdmin = Id_Rol FROM Rol WHERE Nombre_Rol = 'Administrador';
    SELECT @IdTipoCorreoPersonal = Id_TipoCorreo FROM TipoCorreo WHERE Descripcion = 'Personal';

    -- 4. Asignación de Rol
    IF @IdRolAdmin IS NOT NULL
    BEGIN
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
    END

    -- 5. Correo del Administrador
    IF @IdTipoCorreoPersonal IS NOT NULL
    BEGIN
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
    END
END;
GO