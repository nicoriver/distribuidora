USE [DB_SISTEMA_VENTA] -- Asegúrate de usar tu nombre de base de datos correcto
GO

-- 1. Actualizar Tabla Cliente (Si es necesario, agregar columnas faltantes que no existan)
-- NOTA: Ejecuta esto solo si tu tabla no tiene estas columnas aún.
/*
ALTER TABLE CLIENTE ADD Apellido varchar(50);
ALTER TABLE CLIENTE ADD Nombre varchar(50);
ALTER TABLE CLIENTE ADD Razon_Social varchar(100);
ALTER TABLE CLIENTE ADD Domicilio varchar(100);
ALTER TABLE CLIENTE ADD Dni varchar(50);
ALTER TABLE CLIENTE ADD id_Tipo_dni int;
ALTER TABLE CLIENTE ADD Id_Codigo_Iva int;
ALTER TABLE CLIENTE ADD Cuit varchar(50);
ALTER TABLE CLIENTE ADD Id_Zona int;
ALTER TABLE CLIENTE ADD Id_Localidad int;
ALTER TABLE CLIENTE ADD Id_Provincia int;
ALTER TABLE CLIENTE ADD Id_Pais int;
ALTER TABLE CLIENTE ADD Telefono_Alt varchar(50);
ALTER TABLE CLIENTE ADD Fax varchar(50);
ALTER TABLE CLIENTE ADD Email varchar(100);
ALTER TABLE CLIENTE ADD Web varchar(100);
ALTER TABLE CLIENTE ADD Contacto varchar(50);
ALTER TABLE CLIENTE ADD Id_vendedor int;
ALTER TABLE CLIENTE ADD Latitud decimal(10,8);
ALTER TABLE CLIENTE ADD Longitug decimal(10,8);
*/
GO

-- 2. Procedimiento para Registrar Cliente
CREATE PROCEDURE sp_RegistrarCliente(
    @Apellido varchar(50),
    @Nombre varchar(50),
    @Razon_Social varchar(100),
    @Domicilio varchar(100),
    @Dni varchar(50),
    @id_Tipo_dni int,
    @Id_Codigo_Iva int,
    @Cuit varchar(50),
    @Id_Zona int,
    @Id_Localidad int,
    @Id_Provincia int,
    @Id_Pais int,
    @Telefono varchar(50),
    @Telefono_Alt varchar(50),
    @Fax varchar(50),
    @Email varchar(100),
    @Web varchar(100),
    @Contacto varchar(50),
    @Id_vendedor int,
    @Latitud decimal(10,8),
    @Longitug decimal(10,8),
    @Estado bit,
    @Resultado int output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Dni = @Dni)
    BEGIN
        INSERT INTO CLIENTE(
            Apellido, Nombre, Razon_Social, Domicilio, Dni, id_Tipo_dni, 
            Id_Codigo_Iva, Cuit, Id_Zona, Id_Localidad, Id_Provincia, Id_Pais, 
            Telefono, Telefono_Alt, Fax, Email, Web, Contacto, Id_vendedor, 
            Latitud, Longitug, Estado
        ) VALUES (
            @Apellido, @Nombre, @Razon_Social, @Domicilio, @Dni, @id_Tipo_dni, 
            @Id_Codigo_Iva, @Cuit, @Id_Zona, @Id_Localidad, @Id_Provincia, @Id_Pais, 
            @Telefono, @Telefono_Alt, @Fax, @Email, @Web, @Contacto, @Id_vendedor, 
            @Latitud, @Longitug, @Estado
        )
        SET @Resultado = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        SET @Mensaje = 'El cliente con este DNI ya existe'
    END
END
GO

-- 3. Procedimiento para Modificar Cliente
CREATE PROCEDURE sp_ModificarCliente(
    @IdCliente int,
    @Apellido varchar(50),
    @Nombre varchar(50),
    @Razon_Social varchar(100),
    @Domicilio varchar(100),
    @Dni varchar(50),
    @id_Tipo_dni int,
    @Id_Codigo_Iva int,
    @Cuit varchar(50),
    @Id_Zona int,
    @Id_Localidad int,
    @Id_Provincia int,
    @Id_Pais int,
    @Telefono varchar(50),
    @Telefono_Alt varchar(50),
    @Fax varchar(50),
    @Email varchar(100),
    @Web varchar(100),
    @Contacto varchar(50),
    @Id_vendedor int,
    @Latitud decimal(10,8),
    @Longitug decimal(10,8),
    @Estado bit,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Resultado = 1
    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Dni = @Dni AND IdCliente != @IdCliente)
    BEGIN
        UPDATE CLIENTE SET
            Apellido = @Apellido,
            Nombre = @Nombre,
            Razon_Social = @Razon_Social,
            Domicilio = @Domicilio,
            Dni = @Dni,
            id_Tipo_dni = @id_Tipo_dni,
            Id_Codigo_Iva = @Id_Codigo_Iva,
            Cuit = @Cuit,
            Id_Zona = @Id_Zona,
            Id_Localidad = @Id_Localidad,
            Id_Provincia = @Id_Provincia,
            Id_Pais = @Id_Pais,
            Telefono = @Telefono,
            Telefono_Alt = @Telefono_Alt,
            Fax = @Fax,
            Email = @Email,
            Web = @Web,
            Contacto = @Contacto,
            Id_vendedor = @Id_vendedor,
            Latitud = @Latitud,
            Longitug = @Longitug,
            Estado = @Estado
        WHERE IdCliente = @IdCliente
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'El cliente con este DNI ya existe'
    END
END
GO
