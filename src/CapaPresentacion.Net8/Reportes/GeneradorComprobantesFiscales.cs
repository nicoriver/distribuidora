using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CapaEntidad;

namespace CapaPresentacion.Net8.Reportes
{
    public class GeneradorComprobantesFiscales
    {
        private const float MARGIN = 30f;
        private const int MAX_PRODUCTOS = 32;

        public byte[] GenerarPDF(Venta venta)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, MARGIN, MARGIN, MARGIN, MARGIN);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // Encabezado
                DibujarEncabezado(doc, venta);
                doc.Add(new Paragraph(" "));

                // Datos cliente
                DibujarCliente(doc, venta);
                doc.Add(new Paragraph(" "));

                // Productos
                DibujarProductos(doc, venta.oDetalle_Venta);
                doc.Add(new Paragraph(" "));

                // Totales
                DibujarTotales(doc, venta);

                doc.Close();
                return ms.ToArray();
            }
        }

        private void DibujarEncabezado(Document doc, Venta venta)
        {
            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
            var fontLetra = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24);

            PdfPTable tabla = new PdfPTable(3) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 30f, 40f, 30f });

            // Columna 1: Empresa
            PdfPCell celdaEmpresa = new PdfPCell();
            celdaEmpresa.Border = iTextSharp.text.Rectangle.BOX;
            celdaEmpresa.Padding = 5;
            Paragraph pEmpresa = new Paragraph();
            pEmpresa.Add(new Chunk("JCDISTRIBUCIONES\n", fontTitulo));
            pEmpresa.Add(new Chunk("Paularino 1904 Telf (0379) 4401127\n", fontNormal));
            pEmpresa.Add(new Chunk("Capital-Corrientes-3400-ARGENTINA\n", fontNormal));
            pEmpresa.Add(new Chunk("Responsable Inscripto", fontNormal));
            celdaEmpresa.AddElement(pEmpresa);
            tabla.AddCell(celdaEmpresa);

            // Columna 2: Letra
            PdfPCell celdaLetra = new PdfPCell();
            celdaLetra.Border = iTextSharp.text.Rectangle.BOX;
            celdaLetra.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLetra.VerticalAlignment = Element.ALIGN_MIDDLE;
            string letra = ObtenerLetra(venta.oTipoComprobante.IdTipoComprobante);

            // Crear una fuente más grande para la letra
            iTextSharp.text.Font fontLetraGrande = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24); // Ajusta el tamaño según necesites

            Paragraph parrafoLetra = new Paragraph(letra, fontLetraGrande);
            parrafoLetra.Alignment = Element.ALIGN_CENTER;

            celdaLetra.AddElement(new Paragraph(letra, fontLetra));
            tabla.AddCell(celdaLetra);

            // Columna 3: Número
            PdfPCell celdaNumero = new PdfPCell();
            celdaNumero.Border = iTextSharp.text.Rectangle.BOX;
            celdaNumero.Padding = 5;
            string ptoventa = venta.PuntoVenta.ToString().PadLeft(4, '0');
            string numero = ptoventa + "-" + venta.NumeroDocumento
            ;
            Paragraph pNumero = new Paragraph();
            pNumero.Add(new Chunk($"{venta.oTipoComprobante.Descripcion} Nº\n", fontTitulo));
            pNumero.Add(new Chunk($"{numero}\n", fontNormal));
            pNumero.Add(new Chunk($"Fecha: {venta.FechaRegistro}", fontNormal));
            celdaNumero.AddElement(pNumero);
            tabla.AddCell(celdaNumero);

            doc.Add(tabla);
        }

        private void DibujarCliente(Document doc, Venta venta)
        {
            var font = FontFactory.GetFont(FontFactory.HELVETICA, 9);
            PdfPTable tabla = new PdfPTable(1) { WidthPercentage = 100 };
            
            PdfPCell celda = new PdfPCell();
            celda.Border = iTextSharp.text.Rectangle.BOX;
            celda.Padding = 5;
            celda.BackgroundColor = new BaseColor(240, 240, 240);
            
            Paragraph p = new Paragraph();
            p.Add(new Chunk($"Cliente: {venta.NombreCliente}\n", font));
            p.Add(new Chunk($"Domicilio: {venta.oCliente?.Domicilio ?? "N/A"}\n", font));
            p.Add(new Chunk($"CUIT: {venta.DocumentoCliente}", font));
            celda.AddElement(p);
            tabla.AddCell(celda);
            
            doc.Add(tabla);
        }

        private void DibujarProductos(Document doc, List<Detalle_Venta> productos)
        {
            var fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            var fontBody = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PdfPTable tabla = new PdfPTable(5) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 10f, 10f, 45f, 15f, 20f });

            // Encabezados
            string[] headers = { "Código", "Unidades", "Descripción", "Unitario", "Total" };
            foreach (string h in headers)
            {
                PdfPCell celda = new PdfPCell(new Phrase(h, fontHeader));
                celda.BackgroundColor = new BaseColor(70, 130, 180);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Padding = 5;
                tabla.AddCell(celda);
            }

            // Productos
            int count = 0;
            foreach (var det in productos.Take(MAX_PRODUCTOS))
            {
                tabla.AddCell(new PdfPCell(new Phrase(det.oProducto?.Codigo ?? "", fontBody)) { Padding = 3, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(det.Cantidad.ToString(), fontBody)) { Padding = 3, HorizontalAlignment = Element.ALIGN_CENTER });
                
                string desc = det.oProducto?.Nombre ?? "";
                if (desc.Length > 50) desc = desc.Substring(0, 47) + "...";
                tabla.AddCell(new PdfPCell(new Phrase(desc, fontBody)) { Padding = 3 });
                
                tabla.AddCell(new PdfPCell(new Phrase("$ " + det.PrecioVenta.ToString("N2"), fontBody)) { Padding = 3, HorizontalAlignment = Element.ALIGN_RIGHT });
                
                decimal total = det.PrecioVenta * det.Cantidad;
                tabla.AddCell(new PdfPCell(new Phrase(total.ToString("N2"), fontBody)) { Padding = 3, HorizontalAlignment = Element.ALIGN_RIGHT });
                
                count++;
            }

            // Rellenar filas vacías
            for (int i = count; i < MAX_PRODUCTOS; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(" ", fontBody)) { MinimumHeight = 15f });
                }
            }

            doc.Add(tabla);
        }

        private void DibujarTotales(Document doc, Venta venta)
        {
            var fontBody = FontFactory.GetFont(FontFactory.HELVETICA, 9);
            var fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

            PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT };
            tabla.SetWidths(new float[] { 60f, 40f });

            // Subtotal
            AgregarFila(tabla, "Subtotal:",  venta.SubTotal, fontBody);

            // IVA solo si discrimina
            if (DiscriminaIVA(venta.oTipoComprobante.IdTipoComprobante))
            {
                AgregarFila(tabla, "IVA 21%:", venta.TotalIVA, fontBody);
            }

            // Descuento
            if (venta.TotalDescuento != 0)
            {
                AgregarFila(tabla, "Descuento:", venta.TotalDescuento, fontBody);
            }

            // Total
            PdfPCell celdaLabel = new PdfPCell(new Phrase("TOTAL:", fontBold));
            celdaLabel.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            celdaLabel.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabel.Padding = 5;
            tabla.AddCell(celdaLabel);

            PdfPCell celdaValor = new PdfPCell(new Phrase("$ " + venta.MontoTotal.ToString("N2"), fontBold));
            celdaValor.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            celdaValor.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaValor.Padding = 5;
            tabla.AddCell(celdaValor);

            doc.Add(tabla);
        }

        private void AgregarFila(PdfPTable tabla, string label, decimal valor, iTextSharp.text.Font font)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(label, font));
            c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            c1.HorizontalAlignment = Element.ALIGN_RIGHT;
            c1.Padding = 3;
            tabla.AddCell(c1);

            PdfPCell c2 = new PdfPCell(new Phrase("$ " + valor.ToString("N2"), font));
            c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            c2.HorizontalAlignment = Element.ALIGN_RIGHT;
            c2.Padding = 3;
            tabla.AddCell(c2);
        }

        private string ObtenerLetra(int idTipo)
        {
            return idTipo switch
            {
                1 or 4 => "A",
                2 or 5 => "B",
                3 or 6 => "R",
                _ => "X"
            };
        }

        private bool DiscriminaIVA(int idTipo)
        {
            return idTipo == 1 || idTipo == 4;
        }

        public byte[] GenerarPDFMultiple(List<Venta> ventas)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Unimos múltiples PDFs en uno solo
                Document doc = new Document();
                PdfCopy copy = new PdfCopy(doc, ms);
                doc.Open();

                foreach (var venta in ventas)
                {
                    // Generamos el PDF individual en memoria
                    byte[] pdfBytes = GenerarPDF(venta);
                    PdfReader reader = new PdfReader(pdfBytes);
                    
                    // Copiamos todas las páginas de ese PDF al documento final
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        copy.AddPage(copy.GetImportedPage(reader, i));
                    }
                    reader.Close();
                }

                doc.Close();
                return ms.ToArray();
            }
        }

        public string GuardarYAbrir(Venta venta)
        {
            byte[] pdf = GenerarPDF(venta);
            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Comprobantes");
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);
            
            string ruta = Path.Combine(carpeta, $"Comprobante_{venta.NumeroDocumento}.pdf");
            File.WriteAllBytes(ruta, pdf);
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            return ruta;
        }
    }
}
