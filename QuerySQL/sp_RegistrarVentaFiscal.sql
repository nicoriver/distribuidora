-- =============================================
-- Stored Procedure: sp_RegistrarVentaFiscal
-- Descripción: Registra una venta con comprobante fiscal
--              validando stock y actualizándolo automáticamente
-- =============================================

USE DBVENTASDEMO
GO

-- Eliminar el procedimiento si existe
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_RegistrarVentaFiscal')
BEGIN
    DROP PROCEDURE sp_RegistrarVentaFiscal;
    PRINT 'Procedimiento sp_RegistrarVentaFiscal eliminado';
END
GO

-- Crear Type para detalle de venta fiscal si no existe
IF NOT EXISTS (SELECT * FROM sys.types WHERE name = 'EDetalle_VentaFiscal')
BEGIN
    CREATE TYPE [dbo].[EDetalle_VentaFiscal] AS TABLE(
        [IdProducto] INT NULL,
        [PrecioCosto] DECIMAL(18,2) NULL,
        [PrecioVenta] DECIMAL(18,2) NULL,
        [Cantidad] INT NULL,
        [PorcentajeIVA] DECIMAL(5,2) NULL,
        [ImporteIVA] DECIMAL(18,2) NULL,
        [PorcentajeDescuento] DECIMAL(5,2) NULL,
        [ImporteDescuento] DECIMAL(18,2) NULL,
        [SubTotal] DECIMAL(18,2) NULL,
        [IdListaPrecio] INT NULL,
        [Observaciones] VARCHAR(200) NULL
    );
    PRINT 'Type EDetalle_VentaFiscal creado';
END
GO

CREATE PROCEDURE sp_RegistrarVentaFiscal(
    @IdUsuario INT,
    @IdTipoComprobante INT,
    @IdCliente INT = NULL,
    @NumeroDocumento VARCHAR(500),
    @DocumentoCliente VARCHAR(500),
    @NombreCliente VARCHAR(500),
    @MontoPago DECIMAL(18,2),
    @MontoCambio DECIMAL(18,2),
    @SubTotal DECIMAL(18,2),
    @TotalIVA DECIMAL(18,2),
    @TotalDescuento DECIMAL(18,2),
    @MontoTotal DECIMAL(18,2),
    @Observaciones VARCHAR(500) = NULL,
    @DetalleVenta [EDetalle_VentaFiscal] READONLY,
    @IdVentaResultado INT OUTPUT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @idventa INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';
        
        -- Validar que el tipo de comprobante exista y no sea nota de crédito
        IF NOT EXISTS (SELECT 1 FROM TipoComprobante WHERE IdTipoComprobante = @IdTipoComprobante AND EsNotaCredito = 0)
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'El tipo de comprobante no es válido o es una nota de crédito';
            RETURN;
        END
        
        -- Validar stock disponible para productos que controlan stock
        DECLARE @ProductoSinStock VARCHAR(100) = '';
        
        SELECT TOP 1 @ProductoSinStock = p.Nombre
        FROM @DetalleVenta dv
        INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
        WHERE p.ControlaStock = 1 
        AND p.Stock < dv.Cantidad;
        
        IF @ProductoSinStock != ''
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'Stock insuficiente para el producto: ' + @ProductoSinStock;
            RETURN;
        END
        
        -- Iniciar transacción
        BEGIN TRANSACTION registro;
        
        -- Obtener TipoDocumento del comprobante
        DECLARE @TipoDocumento VARCHAR(50);
        SELECT @TipoDocumento = Descripcion 
        FROM TipoComprobante 
        WHERE IdTipoComprobante = @IdTipoComprobante;
        
        -- Insertar venta
        INSERT INTO VENTA(
            IdUsuario, 
            IdTipoComprobante,
            IdCliente,
            TipoDocumento, 
            NumeroDocumento, 
            DocumentoCliente, 
            NombreCliente, 
            MontoPago, 
            MontoCambio,
            SubTotal,
            TotalIVA,
            TotalDescuento,
            MontoTotal,
            Observaciones
        )
        VALUES(
            @IdUsuario, 
            @IdTipoComprobante,
            @IdCliente,
            @TipoDocumento, 
            @NumeroDocumento, 
            @DocumentoCliente, 
            @NombreCliente, 
            @MontoPago, 
            @MontoCambio,
            @SubTotal,
            @TotalIVA,
            @TotalDescuento,
            @MontoTotal,
            @Observaciones
        );
        
        SET @idventa = SCOPE_IDENTITY();
        SET @IdVentaResultado = @idventa;
        
        -- Insertar detalle de venta
        INSERT INTO DETALLE_VENTA(
            IdVenta, 
            IdProducto, 
            PrecioCosto,
            PrecioVenta, 
            Cantidad,
            PorcentajeIVA,
            ImporteIVA,
            PorcentajeDescuento,
            ImporteDescuento,
            SubTotal,
            IdListaPrecio,
            Observaciones
        )
        SELECT 
            @idventa,
            IdProducto,
            PrecioCosto,
            PrecioVenta,
            Cantidad,
            PorcentajeIVA,
            ImporteIVA,
            PorcentajeDescuento,
            ImporteDescuento,
            SubTotal,
            IdListaPrecio,
            Observaciones
        FROM @DetalleVenta;
        
        -- Actualizar stock solo para productos que controlan stock
        UPDATE p 
        SET p.Stock = p.Stock - dv.Cantidad
        FROM PRODUCTO p
        INNER JOIN @DetalleVenta dv ON dv.IdProducto = p.IdProducto
        WHERE p.ControlaStock = 1;
        
        COMMIT TRANSACTION registro;
        
        SET @Mensaje = 'Venta registrada exitosamente';
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION registro;
            
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        SET @IdVentaResultado = 0;
    END CATCH
END
GO

PRINT 'Procedimiento sp_RegistrarVentaFiscal creado exitosamente';
GO
