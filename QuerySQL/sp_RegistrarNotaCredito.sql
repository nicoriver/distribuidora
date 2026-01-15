-- =============================================
-- Stored Procedure: sp_RegistrarNotaCredito
-- Descripción: Registra una nota de crédito (devolución)
--              validando la venta original y devolviendo stock
-- =============================================

USE DBVENTASDEMO
GO

-- Eliminar el procedimiento si existe
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_RegistrarNotaCredito')
BEGIN
    DROP PROCEDURE sp_RegistrarNotaCredito;
    PRINT 'Procedimiento sp_RegistrarNotaCredito eliminado';
END
GO

CREATE PROCEDURE sp_RegistrarNotaCredito(
    @IdUsuario INT,
    @IdVentaOriginal INT,
    @NumeroDocumento VARCHAR(500),
    @SubTotal DECIMAL(18,2),
    @TotalIVA DECIMAL(18,2),
    @TotalDescuento DECIMAL(18,2),
    @MontoTotal DECIMAL(18,2),
    @Observaciones VARCHAR(500) = NULL,
    @DetalleVenta [EDetalle_VentaFiscal] READONLY,
    @IdNotaCreditoResultado INT OUTPUT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @idNotaCredito INT = 0;
        DECLARE @IdTipoComprobanteOriginal INT;
        DECLARE @IdTipoComprobanteNC INT;
        DECLARE @TipoDocumento VARCHAR(50);
        DECLARE @DocumentoCliente VARCHAR(500);
        DECLARE @NombreCliente VARCHAR(500);
        DECLARE @IdCliente INT;
        
        SET @Resultado = 1;
        SET @Mensaje = '';
        
        -- Validar que la venta original exista
        IF NOT EXISTS (SELECT 1 FROM VENTA WHERE IdVenta = @IdVentaOriginal)
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'La venta original no existe';
            RETURN;
        END
        
        -- Obtener datos de la venta original
        SELECT 
            @IdTipoComprobanteOriginal = IdTipoComprobante,
            @DocumentoCliente = DocumentoCliente,
            @NombreCliente = NombreCliente,
            @IdCliente = IdCliente
        FROM VENTA 
        WHERE IdVenta = @IdVentaOriginal;
        
        -- Validar que la venta original no sea una nota de crédito
        IF EXISTS (
            SELECT 1 FROM VENTA v
            INNER JOIN TipoComprobante tc ON tc.IdTipoComprobante = v.IdTipoComprobante
            WHERE v.IdVenta = @IdVentaOriginal AND tc.EsNotaCredito = 1
        )
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'No se puede crear una nota de crédito de otra nota de crédito';
            RETURN;
        END
        
        -- Determinar el tipo de nota de crédito según el comprobante original
        -- Si es Factura A (IdTipoComprobante = 1) -> Nota de Crédito A (4)
        -- Si es Factura B (IdTipoComprobante = 2) -> Nota de Crédito B (5)
        -- Si es Recibo (IdTipoComprobante = 3) -> Nota de Crédito B (5)
        IF @IdTipoComprobanteOriginal = 1
            SET @IdTipoComprobanteNC = 4; -- Nota de Crédito A
        ELSE
            SET @IdTipoComprobanteNC = 5; -- Nota de Crédito B
        
        -- Obtener descripción del tipo de documento
        SELECT @TipoDocumento = Descripcion 
        FROM TipoComprobante 
        WHERE IdTipoComprobante = @IdTipoComprobanteNC;
        
        -- Iniciar transacción
        BEGIN TRANSACTION registro;
        
        -- Insertar nota de crédito
        INSERT INTO VENTA(
            IdUsuario, 
            IdTipoComprobante,
            IdCliente,
            IdVentaOriginal,
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
            @IdTipoComprobanteNC,
            @IdCliente,
            @IdVentaOriginal,
            @TipoDocumento, 
            @NumeroDocumento, 
            @DocumentoCliente, 
            @NombreCliente, 
            @MontoTotal, -- En NC el monto pago es igual al total
            0, -- Sin cambio
            @SubTotal,
            @TotalIVA,
            @TotalDescuento,
            @MontoTotal,
            @Observaciones
        );
        
        SET @idNotaCredito = SCOPE_IDENTITY();
        SET @IdNotaCreditoResultado = @idNotaCredito;
        
        -- Insertar detalle de nota de crédito
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
            @idNotaCredito,
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
        
        -- Devolver stock solo para productos que controlan stock
        UPDATE p 
        SET p.Stock = p.Stock + dv.Cantidad
        FROM PRODUCTO p
        INNER JOIN @DetalleVenta dv ON dv.IdProducto = p.IdProducto
        WHERE p.ControlaStock = 1;
        
        COMMIT TRANSACTION registro;
        
        SET @Mensaje = 'Nota de crédito registrada exitosamente';
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION registro;
            
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        SET @IdNotaCreditoResultado = 0;
    END CATCH
END
GO

PRINT 'Procedimiento sp_RegistrarNotaCredito creado exitosamente';
GO
