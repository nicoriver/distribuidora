using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVentasFiscales : Form
    {
        private Usuario _Usuario;
        private TipoComprobante _TipoComprobanteSeleccionado;
        private int _IdListaPrecioActual = 2; // Por defecto Minorista
        private decimal _PorcentajeIVAGeneral = 21; // IVA por defecto

        public frmVentasFiscales(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmVentasFiscales_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNumeroDocumento.Text = string.Format("{0:00000}", new CN_Venta().ObtenerCorrelativo());

            // Configurar DataGridView PRIMERO
            ConfigurarDataGridView();
            AgregarFilaVacia();

            // Cargar tipos de comprobantes DESPUÉS
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().ListarParaVentas();
            foreach (TipoComprobante tipo in listaTipos)
            {
                cboTipoComprobante.Items.Add(new OpcionCombo()
                {
                    Valor = tipo.IdTipoComprobante,
                    Texto = tipo.Descripcion
                });
            }
            cboTipoComprobante.DisplayMember = "Texto";
            cboTipoComprobante.ValueMember = "Valor";
            cboTipoComprobante.SelectedIndex = 0; // Esto dispara el evento, pero ahora las columnas ya existen
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = true;
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvProductos.Columns.Clear();

            // Columna Código (editable)
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.Name = "Codigo";
            colCodigo.HeaderText = "Código";
            colCodigo.Width = 100;
            colCodigo.ReadOnly = false;
            dgvProductos.Columns.Add(colCodigo);

            // Columna IdProducto (oculta)
            DataGridViewTextBoxColumn colIdProducto = new DataGridViewTextBoxColumn();
            colIdProducto.Name = "IdProducto";
            colIdProducto.HeaderText = "IdProducto";
            colIdProducto.Visible = false;
            dgvProductos.Columns.Add(colIdProducto);

            // Columna Producto (solo lectura)
            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.Name = "Producto";
            colProducto.HeaderText = "Producto";
            colProducto.Width = 250;
            colProducto.ReadOnly = true;
            dgvProductos.Columns.Add(colProducto);

            // Columna Precio (solo lectura)
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "Precio";
            colPrecio.HeaderText = "Precio";
            colPrecio.Width = 80;
            colPrecio.ReadOnly = true;
            colPrecio.DefaultCellStyle.Format = "N2";
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colPrecio);

            // Columna Cantidad (editable)
            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.Name = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Width = 80;
            colCantidad.ReadOnly = false;
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colCantidad);

            // Columna Stock (solo lectura)
            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
            colStock.Name = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Width = 70;
            colStock.ReadOnly = true;
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colStock);

            // Columna ControlaStock (oculta)
            DataGridViewTextBoxColumn colControlaStock = new DataGridViewTextBoxColumn();
            colControlaStock.Name = "ControlaStock";
            colControlaStock.Visible = false;
            dgvProductos.Columns.Add(colControlaStock);

            // Columna PorcentajeIVA
            DataGridViewTextBoxColumn colPorcentajeIVA = new DataGridViewTextBoxColumn();
            colPorcentajeIVA.Name = "PorcentajeIVA";
            colPorcentajeIVA.HeaderText = "IVA %";
            colPorcentajeIVA.Width = 60;
            colPorcentajeIVA.ReadOnly = true;
            colPorcentajeIVA.DefaultCellStyle.Format = "N2";
            colPorcentajeIVA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colPorcentajeIVA);

            // Columna ImporteIVA
            DataGridViewTextBoxColumn colImporteIVA = new DataGridViewTextBoxColumn();
            colImporteIVA.Name = "ImporteIVA";
            colImporteIVA.HeaderText = "Importe IVA";
            colImporteIVA.Width = 90;
            colImporteIVA.ReadOnly = true;
            colImporteIVA.DefaultCellStyle.Format = "N2";
            colImporteIVA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colImporteIVA);

            // Columna SubTotal
            DataGridViewTextBoxColumn colSubTotal = new DataGridViewTextBoxColumn();
            colSubTotal.Name = "SubTotal";
            colSubTotal.HeaderText = "Subtotal";
            colSubTotal.Width = 100;
            colSubTotal.ReadOnly = true;
            colSubTotal.DefaultCellStyle.Format = "N2";
            colSubTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colSubTotal);

            // Columna Total
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.Width = 100;
            colTotal.ReadOnly = true;
            colTotal.DefaultCellStyle.Format = "N2";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colTotal);

            // Columna Eliminar
            DataGridViewButtonColumn colEliminar = new DataGridViewButtonColumn();
            colEliminar.Name = "btnEliminar";
            colEliminar.HeaderText = "";
            colEliminar.Text = "X";
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.Width = 40;
            colEliminar.DefaultCellStyle.BackColor = Color.Red;
            colEliminar.DefaultCellStyle.ForeColor = Color.White;
            dgvProductos.Columns.Add(colEliminar);

            // Eventos
            dgvProductos.CellEndEdit += dgvProductos_CellEndEdit;
            dgvProductos.CellClick += dgvProductos_CellClick;
            dgvProductos.KeyDown += dgvProductos_KeyDown;
        }

        private void cboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoComprobante.SelectedIndex == -1) return;

            int idTipoComprobante = Convert.ToInt32(((OpcionCombo)cboTipoComprobante.SelectedItem).Valor);
            _TipoComprobanteSeleccionado = new CN_TipoComprobante().ObtenerPorId(idTipoComprobante);
            _IdListaPrecioActual = _TipoComprobanteSeleccionado.IdListaPrecio;

            // Verificar que las columnas existan antes de acceder
            if (dgvProductos.Columns.Count == 0) return;

            // Mostrar/Ocultar columnas de IVA
            bool discriminaIVA = _TipoComprobanteSeleccionado.DiscriminaIVA;
            if (dgvProductos.Columns["PorcentajeIVA"] != null)
                dgvProductos.Columns["PorcentajeIVA"].Visible = discriminaIVA;
            if (dgvProductos.Columns["ImporteIVA"] != null)
                dgvProductos.Columns["ImporteIVA"].Visible = discriminaIVA;
            
            lblSubTotal.Visible = discriminaIVA;
            txtSubTotal.Visible = discriminaIVA;
            lblTotalIVA.Visible = discriminaIVA;
            txtTotalIVA.Visible = discriminaIVA;

            // Limpiar productos si hay cambio
            if (dgvProductos.Rows.Count > 1)
            {
                var result = MessageBox.Show(
                    "Al cambiar el tipo de comprobante se limpiarán los productos. ¿Continuar?",
                    "Advertencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    LimpiarProductos();
                }
            }
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
            string columnName = dgvProductos.Columns[e.ColumnIndex].Name;

            if (columnName == "Codigo")
            {
                string codigo = row.Cells["Codigo"].Value?.ToString().Trim();
                if (!string.IsNullOrEmpty(codigo))
                {
                    BuscarYCargarProducto(e.RowIndex, codigo);
                }
            }
            else if (columnName == "Cantidad")
            {
                CalcularTotalesLinea(e.RowIndex);
            }
        }

        private void BuscarYCargarProducto(int rowIndex, string codigo)
        {
            Producto producto = new CN__Producto().Listar()
                .FirstOrDefault(p => p.Codigo == codigo && p.Estado == true);

            if (producto == null)
            {
                MessageBox.Show($"Producto con código '{codigo}' no encontrado", "Producto no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvProductos.Rows[rowIndex].Cells["Codigo"].Value = "";
                return;
            }

            // Obtener precio según lista
            string mensaje;
            decimal precio = new CN_Lista().ObtenerPrecioProducto(
                producto.IdProducto,
                _IdListaPrecioActual,
                out mensaje);

            if (precio == 0)
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                precio = producto.PrecioVenta; // Fallback
            }

            // Cargar datos del producto
            dgvProductos.Rows[rowIndex].Cells["IdProducto"].Value = producto.IdProducto;
            dgvProductos.Rows[rowIndex].Cells["Producto"].Value = producto.Nombre;
            dgvProductos.Rows[rowIndex].Cells["Precio"].Value = precio;
            dgvProductos.Rows[rowIndex].Cells["Cantidad"].Value = 1;
            dgvProductos.Rows[rowIndex].Cells["Stock"].Value = producto.Stock;
            dgvProductos.Rows[rowIndex].Cells["ControlaStock"].Value = producto.ControlaStock;
            dgvProductos.Rows[rowIndex].Cells["PorcentajeIVA"].Value = _PorcentajeIVAGeneral;

            // Calcular totales de la línea
            CalcularTotalesLinea(rowIndex);

            // Mover a la celda de cantidad
            dgvProductos.CurrentCell = dgvProductos.Rows[rowIndex].Cells["Cantidad"];
            dgvProductos.BeginEdit(true);
        }

        private void CalcularTotalesLinea(int rowIndex)
        {
            DataGridViewRow row = dgvProductos.Rows[rowIndex];

            if (row.Cells["Precio"].Value == null || row.Cells["Cantidad"].Value == null)
                return;

            decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
            int cantidad;
            if (!int.TryParse(row.Cells["Cantidad"].Value.ToString(), out cantidad) || cantidad <= 0)
            {
                cantidad = 1;
                row.Cells["Cantidad"].Value = 1;
            }

            // Validar stock si controla
            bool controlaStock = row.Cells["ControlaStock"].Value != null &&
                                Convert.ToBoolean(row.Cells["ControlaStock"].Value);
            if (controlaStock)
            {
                int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                if (cantidad > stock)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {stock}", "Stock",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["Cantidad"].Value = stock;
                    cantidad = stock;
                }
            }

            decimal porcentajeIVA = Convert.ToDecimal(row.Cells["PorcentajeIVA"].Value);
            decimal subtotal, importeIVA, total;

            if (_TipoComprobanteSeleccionado.DiscriminaIVA)
            {
                // Factura A: IVA discriminado
                var resultado = new CN_Venta().CalcularImportesConIVADiscriminado(
                    precio, cantidad, porcentajeIVA, 0);
                subtotal = resultado.SubTotal;
                importeIVA = resultado.ImporteIVA;
                total = resultado.Total;
            }
            else
            {
                // Factura B/Recibo: IVA incluido
                var resultado = new CN_Venta().CalcularImportesConIVAIncluido(
                    precio, cantidad, porcentajeIVA, 0);
                subtotal = resultado.SubTotal;
                importeIVA = resultado.ImporteIVA;
                total = resultado.Total;
            }

            row.Cells["SubTotal"].Value = subtotal;
            row.Cells["ImporteIVA"].Value = importeIVA;
            row.Cells["Total"].Value = total;

            CalcularTotalesGenerales();
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                int currentRow = dgvProductos.CurrentCell.RowIndex;
                int currentCol = dgvProductos.CurrentCell.ColumnIndex;
                string columnName = dgvProductos.Columns[currentCol].Name;

                if (columnName == "Codigo")
                {
                    // Ya se procesó en CellEndEdit, mover a cantidad
                    if (dgvProductos.Rows[currentRow].Cells["Producto"].Value != null)
                    {
                        dgvProductos.CurrentCell = dgvProductos.Rows[currentRow].Cells["Cantidad"];
                        dgvProductos.BeginEdit(true);
                    }
                }
                else if (columnName == "Cantidad")
                {
                    // Agregar nueva fila y mover a código
                    if (dgvProductos.Rows[currentRow].Cells["Producto"].Value != null)
                    {
                        AgregarFilaVacia();
                        dgvProductos.CurrentCell = dgvProductos.Rows[currentRow + 1].Cells["Codigo"];
                        dgvProductos.BeginEdit(true);
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (dgvProductos.CurrentCell.ColumnIndex == dgvProductos.Columns["btnEliminar"].Index)
                {
                    EliminarFila(dgvProductos.CurrentCell.RowIndex);
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                EliminarFila(e.RowIndex);
            }
        }

        private void EliminarFila(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvProductos.Rows.Count)
            {
                if (dgvProductos.Rows[rowIndex].Cells["Producto"].Value != null)
                {
                    dgvProductos.Rows.RemoveAt(rowIndex);
                    CalcularTotalesGenerales();

                    if (dgvProductos.Rows.Count == 0)
                        AgregarFilaVacia();
                }
            }
        }

        private void AgregarFilaVacia()
        {
            dgvProductos.Rows.Add();
        }

        private void CalcularTotalesGenerales()
        {
            decimal subtotal = 0;
            decimal totalIVA = 0;
            decimal total = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["SubTotal"].Value != null)
                {
                    subtotal += Convert.ToDecimal(row.Cells["SubTotal"].Value);
                    totalIVA += Convert.ToDecimal(row.Cells["ImporteIVA"].Value ?? 0);
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            txtSubTotal.Text = subtotal.ToString("N2");
            txtTotalIVA.Text = totalIVA.ToString("N2");
            txtTotal.Text = total.ToString("N2");

            CalcularCambio();
        }

        private void txtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void CalcularCambio()
        {
            decimal total = 0;
            decimal.TryParse(txtTotal.Text, out total);

            decimal pagaCon = 0;
            decimal.TryParse(txtPagaCon.Text, out pagaCon);

            decimal cambio = pagaCon - total;
            txtCambio.Text = cambio >= 0 ? cambio.ToString("N2") : "0.00";
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumentoCliente.Text))
            {
                MessageBox.Show("Ingrese el documento del cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumentoCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
                return;
            }

            int productosValidos = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Count(r => r.Cells["Producto"].Value != null);

            if (productosValidos == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear DataTable con detalle
            DataTable detalle = new DataTable();
            detalle.Columns.Add("IdProducto", typeof(int));
            detalle.Columns.Add("PrecioCosto", typeof(decimal));
            detalle.Columns.Add("PrecioVenta", typeof(decimal));
            detalle.Columns.Add("Cantidad", typeof(int));
            detalle.Columns.Add("PorcentajeIVA", typeof(decimal));
            detalle.Columns.Add("ImporteIVA", typeof(decimal));
            detalle.Columns.Add("PorcentajeDescuento", typeof(decimal));
            detalle.Columns.Add("ImporteDescuento", typeof(decimal));
            detalle.Columns.Add("SubTotal", typeof(decimal));
            detalle.Columns.Add("IdListaPrecio", typeof(int));
            detalle.Columns.Add("Observaciones", typeof(string));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Producto"].Value != null)
                {
                    detalle.Rows.Add(
                        row.Cells["IdProducto"].Value,
                        0,
                        row.Cells["Precio"].Value,
                        row.Cells["Cantidad"].Value,
                        row.Cells["PorcentajeIVA"].Value,
                        row.Cells["ImporteIVA"].Value,
                        0,
                        0,
                        row.Cells["SubTotal"].Value,
                        _IdListaPrecioActual,
                        ""
                    );
                }
            }

            Venta venta = new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oTipoComprobante = _TipoComprobanteSeleccionado,
                NumeroDocumento = txtNumeroDocumento.Text,
                DocumentoCliente = txtDocumentoCliente.Text,
                NombreCliente = txtNombreCliente.Text,
                MontoPago = decimal.Parse(txtPagaCon.Text == "" ? "0" : txtPagaCon.Text),
                MontoCambio = decimal.Parse(txtCambio.Text),
                SubTotal = decimal.Parse(txtSubTotal.Text),
                TotalIVA = decimal.Parse(txtTotalIVA.Text),
                TotalDescuento = 0,
                MontoTotal = decimal.Parse(txtTotal.Text)
            };

            string mensaje;
            int idVenta;
            bool resultado = new CN_Venta().RegistrarVentaFiscal(venta, detalle, out idVenta, out mensaje);

            if (resultado)
            {
                MessageBox.Show($"Venta registrada exitosamente\nNúmero: {txtNumeroDocumento.Text}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show($"Error al registrar venta:\n{mensaje}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarProductos()
        {
            dgvProductos.Rows.Clear();
            AgregarFilaVacia();
            CalcularTotalesGenerales();
        }

        private void LimpiarFormulario()
        {
            txtDocumentoCliente.Text = "";
            txtNombreCliente.Text = "";
            txtPagaCon.Text = "";
            txtCambio.Text = "0.00";
            txtNumeroDocumento.Text = string.Format("{0:00000}", new CN_Venta().ObtenerCorrelativo());
            LimpiarProductos();
            txtDocumentoCliente.Focus();
        }
    }
}
