using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Reportes;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmComprobantes : Form
    {
        private List<Venta> _ventasFiltradas = new List<Venta>();
        private Cliente _clienteSeleccionado = null;

        public frmComprobantes()
        {
            InitializeComponent();
        }

        private void frmComprobantes_Load(object sender, EventArgs e)
        {
            // Configurar fechas por defecto (último mes)
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Now;

            // Cargar tipos de comprobante
            cboTipoComprobante.Items.Add(new OpcionCombo() { Valor = 0, Texto = "TODOS" });
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().Listar();
            foreach (TipoComprobante tipo in listaTipos)
            {
                cboTipoComprobante.Items.Add(new OpcionCombo() { Valor = tipo.IdTipoComprobante, Texto = tipo.Descripcion });
            }
            cboTipoComprobante.DisplayMember = "Texto";
            cboTipoComprobante.ValueMember = "Valor";
            cboTipoComprobante.SelectedIndex = 0;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar comprobantes iniciales
            CargarComprobantes();
        }

        private void ConfigurarDataGridView()
        {
            dgvComprobantes.AllowUserToAddRows = false;
            dgvComprobantes.ReadOnly = true;
            dgvComprobantes.MultiSelect = true;
            dgvComprobantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComprobantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar columna de checkbox si no existe
            if (!dgvComprobantes.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "Seleccionar";
                checkColumn.HeaderText = "";
                checkColumn.Width = 30;
                checkColumn.ReadOnly = false;
                dgvComprobantes.Columns.Insert(0, checkColumn);
            }
        }

        private void CargarComprobantes()
        {
            try
            {
                dgvComprobantes.Rows.Clear();
                _ventasFiltradas.Clear();

                DateTime fechaDesde = dtpFechaDesde.Value.Date;
                DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);
                int idTipoComprobante = Convert.ToInt32(((OpcionCombo)cboTipoComprobante.SelectedItem).Valor);
                int? idCliente = _clienteSeleccionado?.IdCliente;

                // Aquí necesitarías un método en CN_Venta para obtener ventas con filtros
                // Por ahora, simularé la carga
                // List<Venta> ventas = new CN_Venta().ListarConFiltros(fechaDesde, fechaHasta, idTipoComprobante, idCliente);

                // Temporal: obtener todas y filtrar en memoria
                // TODO: Implementar método en CN_Venta para filtrar en BD
                
                lblTotalRegistros.Text = $"Total de registros: {_ventasFiltradas.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar comprobantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarComprobantes();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Now;
            cboTipoComprobante.SelectedIndex = 0;
            txtCliente.Text = "";
            txtIdCliente.Text = "";
            _clienteSeleccionado = null;
            CargarComprobantes();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _clienteSeleccionado = modal._Cliente;
                    txtIdCliente.Text = _clienteSeleccionado.IdCliente.ToString();
                    txtCliente.Text = _clienteSeleccionado.Nombre;
                }
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowIndex = dgvComprobantes.SelectedRows[0].Index;
                Venta venta = _ventasFiltradas[rowIndex];

                // Obtener venta completa con detalles
                Venta ventaCompleta = new CN_Venta().ObtenerVentaCompleta(venta.NumeroDocumento);

                if (ventaCompleta == null || ventaCompleta.IdVenta == 0)
                {
                    MessageBox.Show("No se pudo obtener el detalle del comprobante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generar y mostrar vista previa
                GeneradorComprobantes generador = new GeneradorComprobantes();
                generador.GenerarYMostrarVistaPrevia(ventaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar vista previa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowIndex = dgvComprobantes.SelectedRows[0].Index;
                Venta venta = _ventasFiltradas[rowIndex];

                Venta ventaCompleta = new CN_Venta().ObtenerVentaCompleta(venta.NumeroDocumento);

                if (ventaCompleta == null || ventaCompleta.IdVenta == 0)
                {
                    MessageBox.Show("No se pudo obtener el detalle del comprobante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GeneradorComprobantes generador = new GeneradorComprobantes();
                generador.GenerarYMostrarVistaPrevia(ventaCompleta);

                MessageBox.Show("Comprobante generado. Puede imprimirlo desde el visor de PDF.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirSeleccionados_Click(object sender, EventArgs e)
        {
            List<Venta> ventasSeleccionadas = new List<Venta>();

            // Obtener ventas seleccionadas mediante checkbox
            foreach (DataGridViewRow row in dgvComprobantes.Rows)
            {
                if (row.Cells["Seleccionar"].Value != null && (bool)row.Cells["Seleccionar"].Value == true)
                {
                    Venta venta = _ventasFiltradas[row.Index];
                    Venta ventaCompleta = new CN_Venta().ObtenerVentaCompleta(venta.NumeroDocumento);
                    if (ventaCompleta != null && ventaCompleta.IdVenta != 0)
                    {
                        ventasSeleccionadas.Add(ventaCompleta);
                    }
                }
            }

            if (ventasSeleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un comprobante marcando el checkbox", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                GeneradorComprobantes generador = new GeneradorComprobantes();
                byte[] pdfBytes = generador.GenerarPDFMultiple(ventasSeleccionadas);

                // Guardar temporalmente
                string tempPath = Path.Combine(Path.GetTempPath(), $"Comprobantes_Multiple_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                File.WriteAllBytes(tempPath, pdfBytes);

                // Abrir
                System.Diagnostics.Process.Start(tempPath);

                MessageBox.Show($"{ventasSeleccionadas.Count} comprobante(s) generado(s) exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar comprobantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowIndex = dgvComprobantes.SelectedRows[0].Index;
                Venta venta = _ventasFiltradas[rowIndex];

                Venta ventaCompleta = new CN_Venta().ObtenerVentaCompleta(venta.NumeroDocumento);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files|*.pdf";
                saveDialog.FileName = $"Comprobante_{venta.NumeroDocumento}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    GeneradorComprobantes generador = new GeneradorComprobantes();
                    generador.GenerarYGuardar(ventaCompleta, saveDialog.FileName);

                    MessageBox.Show("PDF guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_ventasFiltradas.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.FileName = $"Comprobantes_{DateTime.Now:yyyyMMdd}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Comprobantes");

                        // Encabezados
                        worksheet.Cell(1, 1).Value = "Fecha";
                        worksheet.Cell(1, 2).Value = "Tipo";
                        worksheet.Cell(1, 3).Value = "Número";
                        worksheet.Cell(1, 4).Value = "Cliente";
                        worksheet.Cell(1, 5).Value = "CUIT/DNI";
                        worksheet.Cell(1, 6).Value = "Subtotal";
                        worksheet.Cell(1, 7).Value = "IVA";
                        worksheet.Cell(1, 8).Value = "Total";

                        // Datos
                        int row = 2;
                        foreach (var venta in _ventasFiltradas)
                        {
                            worksheet.Cell(row, 1).Value = venta.FechaRegistro;
                            worksheet.Cell(row, 2).Value = venta.oTipoComprobante?.Descripcion ?? "";
                            worksheet.Cell(row, 3).Value = venta.NumeroDocumento;
                            worksheet.Cell(row, 4).Value = venta.NombreCliente;
                            worksheet.Cell(row, 5).Value = venta.DocumentoCliente;
                            worksheet.Cell(row, 6).Value = venta.SubTotal;
                            worksheet.Cell(row, 7).Value = venta.TotalIVA;
                            worksheet.Cell(row, 8).Value = venta.MontoTotal;
                            row++;
                        }

                        // Formato
                        worksheet.Columns().AdjustToContents();
                        worksheet.Row(1).Style.Font.Bold = true;

                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show("Excel exportado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvComprobantes.Rows)
            {
                row.Cells["Seleccionar"].Value = true;
            }
        }

        private void btnDeseleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvComprobantes.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
            }
        }
    }
}
