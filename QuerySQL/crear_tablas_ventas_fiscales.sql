-- =============================================
-- Script: Creación de Tablas para Ventas Fiscales (CORREGIDO)
-- Descripción: Crea la tabla TipoComprobante y modifica
--              las tablas VENTA, DETALLE_VENTA y PRODUCTO
--              para soportar comprobantes fiscales
-- =============================================

USE DBVENTASDEMO
GO

-- =============================================
-- 1. Crear tabla TipoComprobante
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TipoComprobante')
BEGIN
    CREATE TABLE TipoComprobante (
        IdTipoComprobante INT PRIMARY KEY IDENTITY,
        Codigo VARCHAR(10) NOT NULL,
        Descripcion VARCHAR(50) NOT NULL,
        IdListaPrecio INT NOT NULL, -- 1=Mayorista, 2=Minorista, 3=Promoción
        DiscriminaIVA BIT NOT NULL, -- 1=Discrimina (Factura A), 0=Incluido (Factura B, Recibo)
        EsNotaCredito BIT NOT NULL DEFAULT 0,
        Estado BIT NOT NULL DEFAULT 1,
        FechaRegistro DATETIME DEFAULT GETDATE()
    );

    PRINT 'Tabla TipoComprobante creada exitosamente';
END
ELSE
BEGIN
    PRINT 'La tabla TipoComprobante ya existe';
END
GO

-- =============================================
-- 2. Insertar tipos de comprobantes
-- =============================================
IF NOT EXISTS (SELECT * FROM TipoComprobante WHERE Codigo = 'FA')
BEGIN
    INSERT INTO TipoComprobante (Codigo, Descripcion, IdListaPrecio, DiscriminaIVA, EsNotaCredito)
    VALUES 
        ('FA', 'Factura A', 1, 1, 0),
        ('FB', 'Factura B', 2, 0, 0),
        ('REC', 'Recibo', 2, 0, 0),
        ('NCA', 'Nota de Crédito A', 1, 1, 1),
        ('NCB', 'Nota de Crédito B', 2, 0, 1);

    PRINT 'Tipos de comprobantes insertados exitosamente';
END
ELSE
BEGIN
    PRINT 'Los tipos de comprobantes ya existen';
END
GO

-- =============================================
-- 3. Modificar tabla PRODUCTO - Agregar ControlaStock
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('PRODUCTO') AND name = 'ControlaStock')
BEGIN
    ALTER TABLE PRODUCTO
    ADD ControlaStock BIT NOT NULL DEFAULT 1;

    PRINT 'Campo ControlaStock agregado a tabla PRODUCTO';
END
ELSE
BEGIN
    PRINT 'El campo ControlaStock ya existe en PRODUCTO';
END
GO

-- =============================================
-- 4. Modificar tabla VENTA - Agregar campos fiscales
-- =============================================

-- 4.1 Agregar IdTipoComprobante
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('VENTA') AND name = 'IdTipoComprobante')
BEGIN
    ALTER TABLE VENTA ADD IdTipoComprobante INT NULL;
    PRINT 'Campo IdTipoComprobante agregado a tabla VENTA';
END
ELSE
BEGIN
    PRINT 'El campo IdTipoComprobante ya existe en VENTA';
END
GO

-- 4.2 Agregar IdCliente
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('VENTA') AND name = 'IdCliente')
BEGIN
    ALTER TABLE VENTA ADD IdCliente INT NULL;
    PRINT 'Campo IdCliente agregado a tabla VENTA';
END
ELSE
BEGIN
    PRINT 'El campo IdCliente ya existe en VENTA';
END
GO

-- 4.3 Agregar IdVentaOriginal
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('VENTA') AND name = 'IdVentaOriginal')
BEGIN
    ALTER TABLE VENTA ADD IdVentaOriginal INT NULL;
    PRINT 'Campo IdVentaOriginal agregado a tabla VENTA';
END
ELSE
BEGIN
    PRINT 'El campo IdVentaOriginal ya existe en VENTA';
END
GO

-- 4.4 Agregar campos de totales
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('VENTA') AND name = 'SubTotal')
BEGIN
    ALTER TABLE VENTA
    ADD SubTotal DECIMAL(10,2) DEFAULT 0,
        TotalIVA DECIMAL(10,2) DEFAULT 0,
        TotalDescuento DECIMAL(10,2) DEFAULT 0,
        Observaciones VARCHAR(500) NULL;

    PRINT 'Campos SubTotal, TotalIVA, TotalDescuento y Observaciones agregados a VENTA';
END
ELSE
BEGIN
    PRINT 'Los campos fiscales ya existen en VENTA';
END
GO

-- 4.5 Agregar restricciones de clave foránea
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_VENTA_TipoComprobante')
BEGIN
    ALTER TABLE VENTA
    ADD CONSTRAINT FK_VENTA_TipoComprobante 
    FOREIGN KEY (IdTipoComprobante) REFERENCES TipoComprobante(IdTipoComprobante);
    
    PRINT 'Restricción FK_VENTA_TipoComprobante creada';
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_VENTA_Cliente')
BEGIN
    ALTER TABLE VENTA
    ADD CONSTRAINT FK_VENTA_Cliente 
    FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente);
    
    PRINT 'Restricción FK_VENTA_Cliente creada';
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_VENTA_VentaOriginal')
BEGIN
    ALTER TABLE VENTA
    ADD CONSTRAINT FK_VENTA_VentaOriginal 
    FOREIGN KEY (IdVentaOriginal) REFERENCES VENTA(IdVenta);
    
    PRINT 'Restricción FK_VENTA_VentaOriginal creada';
END
GO

-- =============================================
-- 5. Modificar tabla DETALLE_VENTA - Agregar campos de impuestos
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('DETALLE_VENTA') AND name = 'PrecioCosto')
BEGIN
    ALTER TABLE DETALLE_VENTA
    ADD PrecioCosto DECIMAL(10,2) DEFAULT 0,
        PorcentajeIVA DECIMAL(5,2) DEFAULT 0,
        ImporteIVA DECIMAL(10,2) DEFAULT 0,
        PorcentajeDescuento DECIMAL(5,2) DEFAULT 0,
        ImporteDescuento DECIMAL(10,2) DEFAULT 0,
        IdListaPrecio INT NULL,
        Observaciones VARCHAR(200) NULL;

    PRINT 'Campos fiscales agregados a tabla DETALLE_VENTA';
END
ELSE
BEGIN
    PRINT 'Los campos fiscales ya existen en DETALLE_VENTA';
END
GO

-- =============================================
-- 6. Actualizar datos existentes
-- =============================================
-- Actualizar ventas existentes con valores por defecto
UPDATE VENTA 
SET IdTipoComprobante = 2, -- Factura B por defecto
    SubTotal = MontoTotal,
    TotalIVA = 0,
    TotalDescuento = 0
WHERE IdTipoComprobante IS NULL;

PRINT 'Ventas existentes actualizadas con valores por defecto';
GO

-- Actualizar productos para controlar stock por defecto
UPDATE PRODUCTO
SET ControlaStock = 1
WHERE ControlaStock IS NULL OR ControlaStock = 0;

PRINT 'Productos actualizados para controlar stock';
GO

PRINT '========================================';
PRINT 'Script ejecutado exitosamente';
PRINT 'Tablas creadas y modificadas correctamente';
PRINT '========================================';
