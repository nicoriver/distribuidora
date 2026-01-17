using CapaEntidad;
using CapaNegocio;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.IO;
using System.Linq;

namespace CapaPresentacion.Reportes
{
    public class GeneradorComprobantes
    {
        public GeneradorComprobantes()
        {
            // Configurar licencia Community (gratuita)
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] GenerarPDF(Venta venta)
        {
            // Obtener datos de la empresa
            Negocio empresa = new CN_Negocio().ObtenerDatos();

            var documento = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(c => ComposeEncabezado(c, venta, empresa));
                    page.Content().Element(c => ComposeContenido(c, venta));
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            });

            return documento.GeneratePdf();
        }

        private void ComposeEncabezado(IContainer container, Venta venta, Negocio empresa)
        {
            container.Column(column =>
            {
                // Fila superior: Logo, Datos Empresa, Tipo Comprobante
                column.Item().Row(row =>
                {
                    // Logo (placeholder por ahora)
                    row.ConstantItem(100).Height(80).Border(1).Padding(5)
                        .AlignCenter().AlignMiddle().Text("LOGO").FontSize(12);

                    // Datos de la empresa
                    row.RelativeItem().PaddingLeft(10).Column(col =>
                    {
                        col.Item().Text(empresa.Nombre ?? "NOMBRE EMPRESA").FontSize(14).Bold();
                        col.Item().Text(empresa.Direccion ?? "Dirección").FontSize(9);
                        col.Item().Text($"CUIT: {empresa.RUC ?? "XX-XXXXXXXX-X"}").FontSize(9);
                        col.Item().Text("IVA: Responsable Inscripto").FontSize(9);
                    });

                    // Tipo de comprobante
                    row.ConstantItem(120).Border(2).Padding(5).Column(col =>
                    {
                        col.Item().AlignCenter().Text(venta.oTipoComprobante?.Codigo ?? "X").FontSize(28).Bold();
                        col.Item().AlignCenter().Text($"COD. {venta.oTipoComprobante?.IdTipoComprobante:00}").FontSize(8);
                    });
                });

                column.Item().PaddingTop(10);

                // Título del comprobante
                column.Item().AlignCenter().Text(venta.oTipoComprobante?.Descripcion ?? "COMPROBANTE")
                    .FontSize(16).Bold();

                column.Item().PaddingTop(5);

                // Número y fecha
                column.Item().Row(row =>
                {
                    row.RelativeItem().Text($"Punto de Venta: {venta.PuntoVenta:0000}").FontSize(10);
                    row.RelativeItem().Text($"Número: {venta.NumeroDocumento}").FontSize(10);
                    row.RelativeItem().AlignRight().Text($"Fecha: {venta.FechaRegistro}").FontSize(10);
                });

                column.Item().PaddingTop(10);

                // Datos del cliente
                column.Item().Border(1).Padding(10).Column(col =>
                {
                    col.Item().Text("DATOS DEL CLIENTE").FontSize(11).Bold();
                    col.Item().PaddingTop(5);
                    col.Item().Row(r =>
                    {
                        r.RelativeItem().Text($"Cliente: {venta.NombreCliente}").FontSize(9);
                        r.RelativeItem().Text($"CUIT/DNI: {venta.DocumentoCliente}").FontSize(9);
                    });
                });

                column.Item().PaddingTop(10);
            });
        }

        private IContainer CellStyle(IContainer container)
        {
            return container.Background(Colors.Grey.Lighten2).Padding(5);
        }

        private void ComposeContenido(IContainer container, Venta venta)
        {
            container.Column(column =>
            {
                // Tabla de productos
                column.Item().Table(table =>
                {
                    // Definir columnas
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(60);   // Código
                        columns.ConstantColumn(50);   // Cantidad
                        columns.RelativeColumn();     // Descripción
                        columns.ConstantColumn(80);   // Unitario
                        columns.ConstantColumn(80);   // IVA
                        columns.ConstantColumn(90);   // Total
                    });

                    // Encabezado de la tabla
                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Código").Bold();
                        header.Cell().Element(CellStyle).Text("Cant.").Bold();
                        header.Cell().Element(CellStyle).Text("Descripción").Bold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Unitario").Bold();
                        header.Cell().Element(CellStyle).AlignRight().Text("IVA %").Bold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Total").Bold();
                    });

                    // Filas de productos
                    if (venta.oDetalle_Venta != null && venta.oDetalle_Venta.Count > 0)
                    {
                        foreach (var detalle in venta.oDetalle_Venta)
                        {
                            table.Cell().Padding(5).Text(detalle.oProducto?.Codigo ?? "");
                            table.Cell().Padding(5).AlignCenter().Text(detalle.Cantidad.ToString());
                            table.Cell().Padding(5).Text(detalle.oProducto?.Nombre ?? "");
                            table.Cell().Padding(5).AlignRight().Text($"${detalle.PrecioVenta:N2}");
                            table.Cell().Padding(5).AlignRight().Text($"{detalle.PorcentajeIVA:N1}%");
                            table.Cell().Padding(5).AlignRight().Text($"${detalle.SubTotal:N2}");
                        }
                    }
                });

                column.Item().PaddingTop(20);

                // Totales
                column.Item().AlignRight().Column(col =>
                {
                    col.Item().Row(r =>
                    {
                        r.ConstantItem(150).Text("Subtotal:").FontSize(11);
                        r.ConstantItem(100).AlignRight().Text($"${venta.SubTotal:N2}").FontSize(11);
                    });

                    if (venta.TotalIVA > 0)
                    {
                        col.Item().Row(r =>
                        {
                            r.ConstantItem(150).Text("IVA:").FontSize(11);
                            r.ConstantItem(100).AlignRight().Text($"${venta.TotalIVA:N2}").FontSize(11);
                        });
                    }

                    if (venta.TotalDescuento > 0)
                    {
                        col.Item().Row(r =>
                        {
                            r.ConstantItem(150).Text("Descuento:").FontSize(11);
                            r.ConstantItem(100).AlignRight().Text($"-${venta.TotalDescuento:N2}").FontSize(11);
                        });
                    }

                    col.Item().PaddingTop(5).Border(1).BorderColor(Colors.Black)
                        .Padding(5).Row(r =>
                        {
                            r.ConstantItem(150).Text("TOTAL:").FontSize(13).Bold();
                            r.ConstantItem(100).AlignRight().Text($"${venta.MontoTotal:N2}").FontSize(13).Bold();
                        });
                });

                // Observaciones si existen
                if (!string.IsNullOrEmpty(venta.Observaciones))
                {
                    column.Item().PaddingTop(20).Column(col =>
                    {
                        col.Item().Text("Observaciones:").FontSize(10).Bold();
                        col.Item().Border(1).Padding(5).Text(venta.Observaciones).FontSize(9);
                    });
                }
            });
        }

        public void GenerarYMostrarVistaPrevia(Venta venta)
        {
            try
            {
                byte[] pdfBytes = GenerarPDF(venta);

                // Guardar en carpeta temporal
                string tempPath = Path.Combine(Path.GetTempPath(), $"Comprobante_{venta.NumeroDocumento}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                File.WriteAllBytes(tempPath, pdfBytes);

                // Abrir con el visor predeterminado
                System.Diagnostics.Process.Start(tempPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar vista previa: {ex.Message}", ex);
            }
        }

        public void GenerarYGuardar(Venta venta, string rutaArchivo)
        {
            try
            {
                byte[] pdfBytes = GenerarPDF(venta);
                File.WriteAllBytes(rutaArchivo, pdfBytes);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar PDF: {ex.Message}", ex);
            }
        }

        public byte[] GenerarPDFMultiple(System.Collections.Generic.List<Venta> ventas)
        {
            Negocio empresa = new CN_Negocio().ObtenerDatos();

            var documento = Document.Create(container =>
            {
                foreach (var venta in ventas)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(1.5f, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(10));

                        page.Header().Element(c => ComposeEncabezado(c, venta, empresa));
                        page.Content().Element(c => ComposeContenido(c, venta));
                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                    });
                }
            });

            return documento.GeneratePdf();
        }
    }
}
