using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Net8.Utilidades;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Net8.Reportes;

namespace CapaPresentacion.Net8
{
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                
                // Configurar Fechas (Primer día del mes actual hasta hoy)
                var fechaActual = DateTime.Now;
                dtpFechaInicio.Value = new DateTime(fechaActual.Year, fechaActual.Month, 1);
                dtpFechaFin.Value = fechaActual;

                // Estilo de Grilla
                dgvData.Columns["Total"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            // Cargar Tipos de Comprobante
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().ListarParaVentas(); // Asumimos que existe o usar Listar()
            listaTipos.Insert(0, new TipoComprobante { IdTipoComprobante = 0, Descripcion = "Todos" });
            cboTipoComprobante.DataSource = listaTipos;
            cboTipoComprobante.DisplayMember = "Descripcion";
            cboTipoComprobante.ValueMember = "IdTipoComprobante";
            cboTipoComprobante.SelectedIndex = 0;

            // Cargar Puntos de Venta (Simulado por ahora o desde DB si existe tabla)
            var listaPuntos = new List<OpcionCombo>
            {
                new OpcionCombo { Valor = 0, Texto = "Todos" },
                new OpcionCombo { Valor = 1, Texto = "0001" },
                new OpcionCombo { Valor = 2, Texto = "0002" }
            };
            cboPuntoVenta.DataSource = listaPuntos;
            cboPuntoVenta.DisplayMember = "Texto";
            cboPuntoVenta.ValueMember = "Valor";
            cboPuntoVenta.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
                string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");
                int idTipo = Convert.ToInt32(cboTipoComprobante.SelectedValue);
                int puntoVenta = Convert.ToInt32(cboPuntoVenta.SelectedValue);

                dgvData.Rows.Clear();

                // =========================================================================================
                // BLOQUE A IMPLEMENTAR POR EL USUARIO (Descomentar cuando CN_Reporte exista)
                // =========================================================================================
                
                 List<Venta> lista = new CN_Reporte().ObtenerVentas(fechaInicio, fechaFin, idTipo == 0 ? null : (int?)idTipo, puntoVenta == 0 ? null : (int?)puntoVenta);

                // =========================================================================================
                // MOCK DATA (Solo para mostrar funcionalidad visual - BORRAR LUEGO)
                //List<Venta> lista = GenerarDatosPrueba(); 
                // =========================================================================================

                decimal totalImporte = 0;
                int totalComprobantes = 0;

                foreach (Venta v in lista)
                {
                    // Filtros simulados para el Mock Data
                    if (idTipo != 0 && v.oTipoComprobante.IdTipoComprobante != idTipo) continue;

                    dgvData.Rows.Add(
                        false, // Checkbox no seleccionado
                        v.IdVenta,
                        v.FechaRegistro,
                        v.oTipoComprobante.Descripcion,
                        v.NumeroDocumento,
                        v.NombreCliente,
                        1,
                      //  v.oDetalle_Venta.Count,
                        v.MontoTotal
                    );

                    totalImporte += v.MontoTotal;
                    totalComprobantes++;
                }

                lblTotalComprobantes.Text = $"Total Comprobantes: {totalComprobantes}";
                lblTotalImporte.Text = $"Importe Total: {totalImporte:C2}";

                if (totalComprobantes == 0)
                {
                    MessageBox.Show("No se encontraron ventas con los filtros seleccionados.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Venta> GenerarDatosPrueba()
        {
            // Genera datos falsos para probar la UI
            var lista = new List<Venta>();
            var random = new Random();
            
            for (int i = 1; i <= 5; i++)
            {
                lista.Add(new Venta
                {
                    IdVenta = i,
                    FechaRegistro = DateTime.Now.AddDays(-random.Next(1, 10)).ToString("dd/MM/yyyy"),
                    oTipoComprobante = new TipoComprobante { IdTipoComprobante = 1, Descripcion = "Factura A" },
                    NumeroDocumento = $"0001-000000{i:00}",
                    NombreCliente = $"Cliente Prueba {i}",
                    DocumentoCliente = "20123456789",
                    MontoTotal = random.Next(1000, 50000),
                    oDetalle_Venta = new List<Detalle_Venta> { new Detalle_Venta(), new Detalle_Venta() } // Simular 2 prod
                });
            }
            return lista;
        }

        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Cells["Seleccionar"].Value = chkSeleccionarTodo.Checked;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                List<Venta> ventasAImprimir = new List<Venta>();
                List<int> idsVentas = new List<int>();

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                    {
                        idsVentas.Add(Convert.ToInt32(row.Cells["IdVenta"].Value));
                    }
                }

                if (idsVentas.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos un comprobante para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"¿Desea generar el PDF para {idsVentas.Count} comprobantes seleccionados?", "Confirmar Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                // Recuperar datos completos de cada venta seleccionada
                var cnVenta = new CN_Venta();
                foreach (int id in idsVentas)
                {
                    // Necesitamos obtener la venta completa con detalle para poder imprimirla
                    Venta ventaCompleta = cnVenta.ObtenerVentaxid(id);
                    if (ventaCompleta != null)
                    {
                        ventasAImprimir.Add(ventaCompleta);
                    }
                }

                // Generar PDF Múltiple
                if (ventasAImprimir.Count > 0)
                {
                    var generador = new GeneradorComprobantesFiscales();
                    string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                    
                    byte[] pdfBytes = generador.GenerarPDFMultiple(ventasAImprimir);
                    File.WriteAllBytes(ruta, pdfBytes);
                    
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(ruta) { UseShellExecute = true });
                    MessageBox.Show($"Reporte generado exitosamente:\n{ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
