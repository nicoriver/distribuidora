-- Script de creación de tabla Lista para gestión de precios
-- Este script debe ejecutarse ANTES de actualizacion_productos.sql

USE DBVENTASDEMO
GO

-- Verificar si la tabla ya existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lista]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Lista](
        [Id_Lista] [int] IDENTITY(1,1) NOT NULL,
        [Id_articulo] [int] NOT NULL,
        [Descripcion] [varchar](100) NULL,
        [id_Tipolistas] [int] NOT NULL,
        [Importe] [decimal](10, 2) NOT NULL DEFAULT 0,
        [Fecha_Modificacion] [datetime] NOT NULL DEFAULT GETDATE(),
        [Iva] [decimal](10, 2) NOT NULL DEFAULT 0,
        [Recargo] [decimal](10, 2) NOT NULL DEFAULT 0,
        [Descuento] [decimal](10, 2) NOT NULL DEFAULT 0,
        
        CONSTRAINT [PK_Lista] PRIMARY KEY CLUSTERED ([Id_Lista] ASC),
        CONSTRAINT [FK_Lista_Producto] FOREIGN KEY([Id_articulo]) 
            REFERENCES [dbo].[PRODUCTO] ([IdProducto])
            ON DELETE CASCADE
    )
    
    PRINT 'Tabla Lista creada exitosamente'
END
ELSE
BEGIN
    PRINT 'La tabla Lista ya existe'
END
GO

-- Crear índice para mejorar rendimiento en consultas por producto
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Lista_IdArticulo' AND object_id = OBJECT_ID('Lista'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Lista_IdArticulo] ON [dbo].[Lista]
    (
        [Id_articulo] ASC
    )
    PRINT 'Índice IX_Lista_IdArticulo creado exitosamente'
END
GO
