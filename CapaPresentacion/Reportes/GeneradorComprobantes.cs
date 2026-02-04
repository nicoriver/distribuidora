using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
namespace CapaPresentacion.Reportes
{
    public class GeneradorComprobantes
    {
        // Método principal que genera el PDF según el tipo de comprobante
        public byte[] GenerarPDF(Venta venta)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                // Determinar tipo de comprobante y generar layout correspondiente
                if (EsFacturaA(venta.oTipoComprobante.IdTipoComprobante))
                {
                    GenerarFacturaA(document, venta);
                }
                else if (EsFacturaB(venta.oTipoComprobante.IdTipoComprobante) || EsRemito(venta.oTipoComprobante.IdTipoComprobante))
                {
                    GenerarFacturaBORemito(document, venta);
                }
                else if (EsNotaCredito(venta.oTipoComprobante.IdTipoComprobante))
                {
                    GenerarNotaCredito(document, venta);
                }

                document.Close();
                return ms.ToArray();
            }
        }

        private void GenerarFacturaA(Document document, Venta venta)
        {
            // 1. Encabezado con datos de la empresa
            AgregarEncabezadoEmpresa(document);

            // 2. Tipo de comprobante grande en el centro
            AgregarTipoComprobante(document, "A");

            // 3. Número de comprobante con formato FA-0001-00000001
            string numeroFormateado = FormatearNumeroComprobante(venta);
            AgregarNumeroComprobante(document, numeroFormateado);

            // 4. Fecha visible
            AgregarFecha(document, DateTime.Parse(venta.FechaRegistro));

            // 5. Datos del cliente CON DOMICILIO
            AgregarDatosClienteConDomicilio(document, venta);

            // 6. Tabla de productos
            AgregarTablaProductos(document, venta, true); // true = mostrar IVA

            // 7. Totales con IVA
            AgregarTotalesFacturaA(document, venta);
        }

        private void GenerarFacturaBORemito(Document document, Venta venta)
        {
            // Similar a Factura A pero SIN IVA en los totales
            AgregarEncabezadoEmpresa(document);

            string tipoLetra = EsFacturaB(venta.oTipoComprobante.IdTipoComprobante) ? "B" : "R";
            AgregarTipoComprobante(document, tipoLetra);

            string numeroFormateado = FormatearNumeroComprobante(venta);
            AgregarNumeroComprobante(document, numeroFormateado);

            AgregarFecha(document, DateTime.Parse(venta.FechaRegistro));
            AgregarDatosClienteConDomicilio(document, venta);
            AgregarTablaProductos(document, venta, false); // false = sin IVA
            AgregarTotalesFacturaB(document, venta); // Sin IVA
        }

        private void GenerarNotaCredito(Document document, Venta venta)
        {
            // Determinar si es NCA, NCB o NCR según el comprobante original
            bool tieneIVA = venta.oTipoComprobante.IdTipoComprobante == 4; // 4 = NC A

            AgregarEncabezadoEmpresa(document);

            string tipoLetra = ObtenerLetraNotaCredito(venta.oTipoComprobante.IdTipoComprobante);
            AgregarTipoComprobante(document, tipoLetra);

            string numeroFormateado = FormatearNumeroComprobante(venta);
            AgregarNumeroComprobante(document, numeroFormateado);

            // Agregar referencia al comprobante original
            if ( venta.IdVentaOriginal > 0)
            {
               // AgregarReferenciaComprobanteOriginal(document, venta.IdVentaOriginal);
            }

            AgregarFecha(document, DateTime.Parse(venta.FechaRegistro));
            AgregarDatosClienteConDomicilio(document, venta);
            AgregarTablaProductos(document, venta, tieneIVA);

            if (tieneIVA)
                AgregarTotalesFacturaA(document, venta);
            else
                AgregarTotalesFacturaB(document, venta);
        }

        // Métodos auxiliares

        private string FormatearNumeroComprobante(Venta venta)
        {
            string prefijo = "";

            switch (venta.oTipoComprobante.IdTipoComprobante)
            {
                case 1: prefijo = "FA"; break;   // Factura A
                case 2: prefijo = "FB"; break;   // Factura B
                case 3: prefijo = "R"; break;    // Remito
                case 4: prefijo = "NCA"; break;  // Nota Crédito A
                case 5: prefijo = "NCB"; break;  // Nota Crédito B
                case 6: prefijo = "NCR"; break;  // Nota Crédito R
            }

            // Si el número ya tiene el prefijo, no agregarlo de nuevo
            if (venta.NumeroDocumento.StartsWith(prefijo))
                return venta.NumeroDocumento;

            return $"{prefijo}-{venta.NumeroDocumento}";//agregar el pto vta
        }

        private void AgregarEncabezadoEmpresa(Document document)
        {
            // Obtener datos de la empresa desde CN_Negocio
            var negocio = new CN_Negocio().ObtenerDatos();

            Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            Paragraph titulo = new Paragraph(negocio.Nombre, fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            document.Add(titulo);

            Paragraph direccion = new Paragraph(
                $"{negocio.Direccion}\n" +
                $"CUIT: {negocio.RUC}\n" +
                $"Tel: {negocio.Telefono}",
                fontNormal);
            direccion.Alignment = Element.ALIGN_CENTER;
            document.Add(direccion);

            document.Add(new Paragraph("\n"));
        }

        private void AgregarTipoComprobante(Document document, string letra)
        {
            Font fontGrande = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24);

            // Crear tabla para centrar la letra
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 20;
            table.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(new Phrase(letra, fontGrande));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Border = Rectangle.BOX;
            cell.BorderWidth = 2;
            cell.Padding = 10;

            table.AddCell(cell);
            document.Add(table);
            document.Add(new Paragraph("\n"));
        }

        private void AgregarNumeroComprobante(Document document, string numero)
        {
            Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            Paragraph parrafo = new Paragraph($"Comprobante N°: {numero}", fontBold);
            parrafo.Alignment = Element.ALIGN_RIGHT;
            document.Add(parrafo);
        }

        private void AgregarFecha(Document document, DateTime fecha)
        {
            Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            Paragraph parrafo = new Paragraph(
                $"Fecha: {fecha:dd/MM/yyyy}",
                fontNormal);
            parrafo.Alignment = Element.ALIGN_RIGHT;
            document.Add(parrafo);
            document.Add(new Paragraph("\n"));
        }

        private void AgregarDatosClienteConDomicilio(Document document, Venta venta)
        {
            Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            // Obtener datos completos del cliente desde la BD
            Cliente cliente = new CN_Cliente().ObtenerPorId(venta.oCliente.IdCliente);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 30, 70 });

            // Cliente
            table.AddCell(CrearCeldaLabel("Cliente:", fontBold));
            table.AddCell(CrearCeldaDato(venta.NombreCliente, fontNormal));

            // Documento
            table.AddCell(CrearCeldaLabel("CUIT/DNI:", fontBold));
            table.AddCell(CrearCeldaDato(venta.DocumentoCliente, fontNormal));

            // Domicilio
            if (cliente != null)
            {
                table.AddCell(CrearCeldaLabel("Domicilio:", fontBold));
                table.AddCell(CrearCeldaDato(cliente.Domicilio ?? "", fontNormal));

                // Localidad/Provincia
                string ubicacion = "";
                //if (!string.IsNullOrEmpty(cliente.oLocalidad?.Nombre))
                //{
                //    ubicacion = cliente.oLocalidad.Nombre;
                //    if (!string.IsNullOrEmpty(cliente.oLocalidad.oProvincia?.Nombre))
                //    {
                //        ubicacion += ", " + cliente.oLocalidad.oProvincia.Nombre;
                //    }
                //}

                if (!string.IsNullOrEmpty(ubicacion))
                {
                    table.AddCell(CrearCeldaLabel("Localidad:", fontBold));
                    table.AddCell(CrearCeldaDato(ubicacion, fontNormal));
                }
            }

            document.Add(table);
            document.Add(new Paragraph("\n"));
        }

        private void AgregarTablaProductos(Document document, Venta venta, bool mostrarIVA)
        {
            Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 8);

            // Crear tabla con 5 columnas
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 15, 10, 45, 15, 15 });

            // Encabezados
            table.AddCell(CrearCeldaHeader("Código", fontHeader));
            table.AddCell(CrearCeldaHeader("Unidades", fontHeader));
            table.AddCell(CrearCeldaHeader("Descripción", fontHeader));
            table.AddCell(CrearCeldaHeader("Unitario", fontHeader));
            table.AddCell(CrearCeldaHeader("Total", fontHeader));

            // Datos
            foreach (var detalle in venta.oDetalle_Venta)
            {
                table.AddCell(CrearCeldaDato(detalle.oProducto.Codigo, fontData));
                table.AddCell(CrearCeldaDato(detalle.Cantidad.ToString("N2"), fontData));
                table.AddCell(CrearCeldaDato(detalle.oProducto.Nombre, fontData));
                table.AddCell(CrearCeldaDato($"${detalle.PrecioVenta:N2}", fontData));
                table.AddCell(CrearCeldaDato($"${detalle.SubTotal:N2}", fontData));
            }

            document.Add(table);
            document.Add(new Paragraph("\n"));
        }

        private void AgregarTotalesFacturaA(Document document, Venta venta)
        {
            Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 50;
            table.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.SetWidths(new float[] { 60, 40 });

            // Subtotal
            table.AddCell(CrearCeldaLabel("Subtotal:", fontNormal));
            table.AddCell(CrearCeldaDato($"${venta.SubTotal:N2}", fontNormal));

            // Interés (si aplica)
            decimal porcentajeInteres = 0; // Obtener de venta si existe
            table.AddCell(CrearCeldaLabel($"Interés ({porcentajeInteres}%):", fontNormal));
            table.AddCell(CrearCeldaDato("$0.00", fontNormal));

            // Descuento
            decimal porcentajeDescuento = venta.TotalDescuento > 0 ?
                (venta.TotalDescuento / venta.SubTotal * 100) : 0;
            table.AddCell(CrearCeldaLabel($"Descuento ({porcentajeDescuento:N2}%):", fontNormal));
            table.AddCell(CrearCeldaDato($"${venta.TotalDescuento:N2}", fontNormal));

            // IVA
            table.AddCell(CrearCeldaLabel("IVA (21%):", fontNormal));
            table.AddCell(CrearCeldaDato($"${venta.TotalIVA:N2}", fontNormal));

            // Total
            table.AddCell(CrearCeldaLabel("TOTAL:", fontBold));
            table.AddCell(CrearCeldaDato($"${venta.MontoTotal:N2}", fontBold));

            document.Add(table);
        }

        private void AgregarTotalesFacturaB(Document document, Venta venta)
        {
            Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 50;
            table.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.SetWidths(new float[] { 60, 40 });

            // Subtotal
            table.AddCell(CrearCeldaLabel("Subtotal:", fontNormal));
            table.AddCell(CrearCeldaDato($"${venta.SubTotal:N2}", fontNormal));

            // Interés
            decimal porcentajeInteres = 0;
            table.AddCell(CrearCeldaLabel($"Interés ({porcentajeInteres}%):", fontNormal));
            table.AddCell(CrearCeldaDato("$0.00", fontNormal));

            // Descuento
            decimal porcentajeDescuento = venta.TotalDescuento > 0 ?
                (venta.TotalDescuento / venta.SubTotal * 100) : 0;
            table.AddCell(CrearCeldaLabel($"Descuento ({porcentajeDescuento:N2}%):", fontNormal));
            table.AddCell(CrearCeldaDato($"${venta.TotalDescuento:N2}", fontNormal));

            // Total (SIN IVA)
            table.AddCell(CrearCeldaLabel("TOTAL:", fontBold));
            table.AddCell(CrearCeldaDato($"${venta.MontoTotal:N2}", fontBold));

            document.Add(table);
        }

        // Métodos auxiliares para crear celdas

        private PdfPCell CrearCeldaLabel(string texto, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.Border = Rectangle.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Padding = 5;
            return cell;
        }

        private PdfPCell CrearCeldaDato(string texto, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.Border = Rectangle.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Padding = 5;
            return cell;
        }

        private PdfPCell CrearCeldaHeader(string texto, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            return cell;
        }

        // Métodos de verificación de tipo

        private bool EsFacturaA(int idTipoComprobante) => idTipoComprobante == 1;
        private bool EsFacturaB(int idTipoComprobante) => idTipoComprobante == 2;
        private bool EsRemito(int idTipoComprobante) => idTipoComprobante == 3;
        private bool EsNotaCredito(int idTipoComprobante) =>
            idTipoComprobante == 4 || idTipoComprobante == 5;

        private string ObtenerLetraNotaCredito(int idTipoComprobante)
        {
            return idTipoComprobante == 4 ? "NC A" : "NC B";
        }

        // Métodos públicos para uso externo

        public void GenerarYMostrarVistaPrevia(Venta venta)
        {
            byte[] pdfBytes = GenerarPDF(venta);

            string tempPath = Path.Combine(
                Path.GetTempPath(),
                $"Comprobante_{venta.NumeroDocumento}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            File.WriteAllBytes(tempPath, pdfBytes);
            System.Diagnostics.Process.Start(tempPath);
        }

        public void GenerarYGuardar(Venta venta, string rutaArchivo)
        {
            byte[] pdfBytes = GenerarPDF(venta);
            File.WriteAllBytes(rutaArchivo, pdfBytes);
        }

        public byte[] GenerarPDFMultiple(List<Venta> ventas)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                for (int i = 0; i < ventas.Count; i++)
                {
                    if (i > 0)
                        document.NewPage();

                    // Generar cada comprobante
                    byte[] pdfIndividual = GenerarPDF(ventas[i]);
                    // Agregar al documento principal
                }

                document.Close();
                return ms.ToArray();
            }
        }
    }
}