-- 1. Crear tabla IVA si no existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVA]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[IVA](
        [id_IVA] [int] IDENTITY(1,1) NOT NULL,
        [Valor] [decimal](10, 2) NOT NULL,
        CONSTRAINT [PK_IVA] PRIMARY KEY CLUSTERED ([id_IVA] ASC)
    )
    -- Insertar valores por defecto
    INSERT INTO [dbo].[IVA] VALUES (10.50)
    INSERT INTO [dbo].[IVA] VALUES (21.00)
    INSERT INTO [dbo].[IVA] VALUES (27.00)
END
GO

-- 2. Agregar columnas a tabla PRODUCTO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRODUCTO' AND COLUMN_NAME = 'Codigo_de_barra')
BEGIN
    ALTER TABLE PRODUCTO ADD Codigo_de_barra varchar(25) NOT NULL DEFAULT '';
END
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRODUCTO' AND COLUMN_NAME = 'Punto_reposicion')
BEGIN
    ALTER TABLE PRODUCTO ADD Punto_reposicion int NOT NULL DEFAULT 0;
END
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRODUCTO' AND COLUMN_NAME = 'Descuento_Distri')
BEGIN
    ALTER TABLE PRODUCTO ADD Descuento_Distri decimal(10, 2) NULL DEFAULT 0;
END
GO

-- 3. Actualizar procedimientos almacenados
-- NOTA: Estos scripts asumen la estructura existente baseda en el código C# leído.
-- Si los SPs tienen más lógica, por favor revíselos antes de ejecutar.

-- SP Registrar Producto
CREATE OR ALTER PROCEDURE [dbo].[sp_RegistrarProducto]
    @Codigo varchar(50),
    @Nombre varchar(50),
    @Descripcion varchar(50),
    @IdCategoria int,
    @Estado bit,
    @Codigo_de_barra varchar(25),
    @Punto_reposicion int,
    @Descuento_Distri decimal(10,2) = 0,
    @PrecioCompra decimal(10,2) = 0,
    @Resultado int output,
    @Mensaje varchar(500) output
AS
BEGIN
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo)
    BEGIN
        INSERT INTO PRODUCTO(Codigo, Nombre, Descripcion, IdCategoria, Estado, Codigo_de_barra, Punto_reposicion, Descuento_Distri, Stock, PrecioCompra, PrecioVenta, FechaRegistro)
        VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @Estado, @Codigo_de_barra, @Punto_reposicion, @Descuento_Distri, 0, @PrecioCompra, 0, GETDATE())
        
        SET @Resultado = SCOPE_IDENTITY()
    END
    ELSE
        SET @Mensaje = 'No se puede repetir el codigo'
END
GO

-- SP Modificar Producto
CREATE OR ALTER PROCEDURE [dbo].[sp_ModificarProducto]
    @IdProducto int,
    @Codigo varchar(50),
    @Nombre varchar(50),
    @Descripcion varchar(50),
    @IdCategoria int,
    @Estado bit,
    @Codigo_de_barra varchar(25),
    @Punto_reposicion int,
    @Descuento_Distri decimal(10,2) = 0,
    @PrecioCompra decimal(10,2) = 0,
    @Resultado bit output,
    @Mensaje varchar(500) output
AS
BEGIN
    SET @Resultado = 1
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo AND IdProducto != @IdProducto)
    BEGIN
        UPDATE PRODUCTO SET
        Codigo = @Codigo,
        Nombre = @Nombre,
        Descripcion = @Descripcion,
        IdCategoria = @IdCategoria,
        Estado = @Estado,
        Codigo_de_barra = @Codigo_de_barra,
        Punto_reposicion = @Punto_reposicion,
        Descuento_Distri = @Descuento_Distri,
        PrecioCompra = @PrecioCompra
        WHERE IdProducto = @IdProducto
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'No se puede repetir el codigo'
    END
END
GO
