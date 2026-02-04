using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using CapaPresentacion.Reportes;
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
        private int _NumeroComprobanteActual = 0; // Numero sin el punto de venta

        public frmVentasFiscales(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmVentasFiscales_Load(object sender, EventArgs e)
        {
            // Configurar fecha a dÃ­a anterior
            dtpFecha.Value = DateTime.Now.AddDays(-1);

            // Configurar DataGridView PRIMERO
            ConfigurarDataGridView();
            AgregarFilaVacia();
            // Forzar visibilidad
            txtTotalIVA.Visible = true;
            txtSubTotal.Visible = true;

            // Traer al frente
            txtTotalIVA.BringToFront();
            txtSubTotal.BringToFront();

            // Cargar puntos de venta (0001 a 0005)
            for (int i = 1; i <= 1; i++)
            {
                cboPuntoVenta.Items.Add(new OpcionCombo()
                {
                    Valor = i,
                    Texto = string.Format("{0:0000}", i)
                });
            }
            cboPuntoVenta.DisplayMember = "Texto";
            cboPuntoVenta.ValueMember = "Valor";
            cboPuntoVenta.SelectedIndex = 0;

            // Cargar tipos de comprobantes
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().ListarParaVentas();
            int indexRemito = -1;
            int currentIndex = 0;
            foreach (TipoComprobante tipo in listaTipos)
            {
                cboTipoComprobante.Items.Add(new OpcionCombo()
                {
                    Valor = tipo.IdTipoComprobante,
                    Texto = tipo.Descripcion
                });
                // Buscar Ã­ndice de "Remito"
                if (tipo.Descripcion.ToUpper().Contains("REMITO"))
                {
                    indexRemito = currentIndex;
                }
                currentIndex++;
            }
            cboTipoComprobante.DisplayMember = "Texto";
            cboTipoComprobante.ValueMember = "Valor";
            cboTipoComprobante.SelectedIndex = indexRemito >= 0 ? indexRemito : 0;

            // Cargar formas de pago
            cboFormaPago.Items.Add("Contado");
            cboFormaPago.Items.Add("Tarjeta");
            cboFormaPago.Items.Add("Transferencia");
            cboFormaPago.Items.Add("Billeteras");
            cboFormaPago.SelectedIndex = 0; // Contado por defecto

            // Actualizar nÃºmero de documento
            ActualizarNumeroDocumento();
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = true;
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvProductos.Columns.Clear();

            // Columna CÃ³digo (editable)
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.Name = "Codigo";
            colCodigo.HeaderText = "Codigo";
            colCodigo.Width = 120;
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
            colProducto.Width = 300;
            colProducto.ReadOnly = true;
            dgvProductos.Columns.Add(colProducto);

            // Columna Precio (solo lectura)
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "Precio";
            colPrecio.HeaderText = "Precio";
            colPrecio.Width = 100;
            colPrecio.ReadOnly = true;
            colPrecio.DefaultCellStyle.Format = "N2";
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colPrecio);

            // Columna Cantidad (editable)
            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.Name = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Width = 90;
            colCantidad.ReadOnly = false;
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colCantidad);

            // Columna Porcentaje (editable)
            DataGridViewTextBoxColumn colPorc = new DataGridViewTextBoxColumn();
            colPorc.Name = "Descuento";
            colPorc.HeaderText = "Porc%";
            colPorc.Width = 80;
            colPorc.ReadOnly = false;
            colPorc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colPorc);

            // Columna Stock (solo lectura)
            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
            colStock.Name = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Width = 80;
            colStock.ReadOnly = true;
            colStock.Visible = false;
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
            colPorcentajeIVA.Width = 70;
            colPorcentajeIVA.ReadOnly = true;
            colPorcentajeIVA.DefaultCellStyle.Format = "N2";
            colPorcentajeIVA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colPorcentajeIVA);

            // Columna ImporteIVA
            DataGridViewTextBoxColumn colImporteIVA = new DataGridViewTextBoxColumn();
            colImporteIVA.Name = "ImporteIVA";
            colImporteIVA.HeaderText = "Importe IVA";
            colImporteIVA.Width = 100;
            colImporteIVA.ReadOnly = true;
            colImporteIVA.DefaultCellStyle.Format = "N2";
            colImporteIVA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colImporteIVA);

            // Columna SubTotal
            DataGridViewTextBoxColumn colSubTotal = new DataGridViewTextBoxColumn();
            colSubTotal.Name = "SubTotal";
            colSubTotal.HeaderText = "Subtotal";
            colSubTotal.Width = 120;
            colSubTotal.ReadOnly = true;
            colSubTotal.DefaultCellStyle.Format = "N2";
            colSubTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colSubTotal);

            // Columna Total
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.Width = 120;
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
            dgvProductos.EditingControlShowing += dgvProductos_EditingControlShowing;
        }

        private void cboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoComprobante.SelectedIndex == -1) return;

            int idTipoComprobante = Convert.ToInt32(((OpcionCombo)cboTipoComprobante.SelectedItem).Valor);
            _TipoComprobanteSeleccionado = new CN_TipoComprobante().ObtenerPorId(idTipoComprobante);
            ActualizarNumeroDocumento();  // ? Agregar esta línea
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
                    "Al cambiar el tipo de comprobante se limpiaran los productos. ¿Continuar?",
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

            if (e.ColumnIndex == dgvProductos.Columns["Descuento"].Index)
            {
                CalcularTotalesLinea(e.RowIndex);
            }

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
                MessageBox.Show($"Producto con cÃ³digo '{codigo}' no encontrado", "Producto no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvProductos.Rows[rowIndex].Cells["Codigo"].Value = "";
                return;
            }

            // Obtener precio segÃºn lista
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

            // Calcular totales de la lÃ­nea
            CalcularTotalesLinea(rowIndex);

            // Mover a la celda de cantidad
            dgvProductos.CurrentCell = dgvProductos.Rows[rowIndex].Cells["Cantidad"];
            dgvProductos.BeginEdit(true);
        }
        
        //modificado 0302
        private void dgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Remover eventos anteriores para evitar duplicados
            e.Control.KeyDown -= new KeyEventHandler(dgvProductos_KeyDown);

            // Agregar el evento KeyDown
            e.Control.KeyDown += new KeyEventHandler(dgvProductos_KeyDown);
        }

        private void CalcularTotalesLinea(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvProductos.Rows.Count)
                return;
            DataGridViewRow row = dgvProductos.Rows[rowIndex];
            // Validar que las celdas necesarias tengan valores
            if (row.Cells["Precio"].Value == null || row.Cells["Cantidad"].Value == null)
                return;
            try
            {
                // Obtener valores
                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                decimal porcentajeDesc = 0;

                // Obtener descuento si existe
                if (row.Cells["Descuento"].Value != null && !string.IsNullOrEmpty(row.Cells["Descuento"].Value.ToString()))
                {
                    porcentajeDesc = Convert.ToDecimal(row.Cells["Descuento"].Value);
                }
                // Calcular subtotal del ítem
                decimal subtotalItem = precio * cantidad;

                // Calcular descuento del ítem
                decimal descuentoItem = subtotalItem * (porcentajeDesc / 100);

                // Calcular neto del ítem (subtotal - descuento)
                decimal netoItem = subtotalItem - descuentoItem;
                // Actualizar la celda SubTotal con el neto (después del descuento)
                row.Cells["SubTotal"].Value = netoItem.ToString("0.00");
                // Recalcular totales generales
                CalcularTotalesGenerales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular totales de línea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                int currentRow = dgvProductos.CurrentCell.RowIndex;
                int currentCol = dgvProductos.CurrentCell.ColumnIndex;
                // Si estamos en la columna Cantidad
                if (dgvProductos.Columns[currentCol].Name == "Cantidad")
                {
                    // Ir a la columna Descuento de la misma fila
                    int descuentoIndex = dgvProductos.Columns["Descuento"].Index;
                    dgvProductos.CurrentCell = dgvProductos.Rows[currentRow].Cells[descuentoIndex];
                    dgvProductos.BeginEdit(true);
                }
                // Si estamos en la columna Descuento
                else if (dgvProductos.Columns[currentCol].Name == "Descuento")
                {
                    // Finalizar edición para que se dispare el cálculo
                    dgvProductos.EndEdit();

                    // Ir a la siguiente fila, columna Cantidad
                    if (currentRow < dgvProductos.Rows.Count - 1)
                    {
                        int cantidadIndex = dgvProductos.Columns["Cantidad"].Index;
                        dgvProductos.CurrentCell = dgvProductos.Rows[currentRow + 1].Cells[cantidadIndex];
                        dgvProductos.BeginEdit(true);
                    }

                    if (dgvProductos.Rows[currentRow].Cells["Producto"].Value != null)
                    {
                        AgregarFilaVacia();
                        dgvProductos.CurrentCell = dgvProductos.Rows[currentRow + 1].Cells["Codigo"];
                        dgvProductos.BeginEdit(true);
                    }

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
            try
            {
                decimal subtotalBruto = 0;      // Suma de (Precio × Cantidad) sin descuentos
                decimal totalDescuentos = 0;     // Suma de todos los descuentos por ítem
                decimal netoTotal = 0;           // Subtotal - Descuentos
                decimal totalIVA = 0;            // IVA calculado sobre el neto total
                decimal totalFinal = 0;          // Neto + IVA
                                                 // Obtener el tipo de comprobante seleccionado
                bool discriminaIVA = false;
                bool esRemito = false;
                if (cboTipoComprobante.SelectedItem != null)
                {
                    // El ComboBox usa OpcionCombo, no TipoComprobante directamente
                    // Necesitamos obtener el TipoComprobante desde la lista
                    var lista = new CN_TipoComprobante().ListarParaVentas();
                    OpcionCombo opcionSeleccionada = (OpcionCombo)cboTipoComprobante.SelectedItem;
                    int idTipoComprobante = Convert.ToInt32(opcionSeleccionada.Valor);

                    TipoComprobante tipoSeleccionado = lista.FirstOrDefault(t => t.IdTipoComprobante == idTipoComprobante);

                    if (tipoSeleccionado != null)
                    {
                        discriminaIVA = tipoSeleccionado.DiscriminaIVA;
                        esRemito = tipoSeleccionado.Descripcion.ToUpper().Contains("REMITO");
                    }
                }
                // Recorrer todas las filas del DataGridView
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Precio"].Value == null || row.Cells["Cantidad"].Value == null)
                        continue;
                    decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal porcentajeDesc = 0;
                    if (row.Cells["Descuento"].Value != null && !string.IsNullOrEmpty(row.Cells["Descuento"].Value.ToString()))
                    {
                        porcentajeDesc = Convert.ToDecimal(row.Cells["Descuento"].Value);
                    }
                    // Calcular subtotal bruto del ítem
                    decimal subtotalItem = precio * cantidad;
                    subtotalBruto += subtotalItem;
                    // Calcular descuento del ítem
                    decimal descuentoItem = subtotalItem * (porcentajeDesc / 100);
                    totalDescuentos += descuentoItem;
                    // El neto del ítem ya está en SubTotal
                    if (row.Cells["SubTotal"].Value != null)
                    {
                        decimal netoItem = Convert.ToDecimal(row.Cells["SubTotal"].Value);
                        netoTotal += netoItem;
                    }
                }
                // Calcular IVA sobre el total neto (no por producto)
                if (!esRemito)
                {
                    // Para Facturas A y B, calcular IVA 21% sobre el neto total
                    totalIVA = netoTotal * 0.21m;
                }
                // Calcular total final
                totalFinal = netoTotal + totalIVA;
                // Mostrar en los TextBox correspondientes
                if (discriminaIVA)
                {
                    // Factura A: mostrar IVA discriminado
                    txtTotalIVA.Text = totalIVA.ToString("0.00");
                    txtTotalIVA.Visible = true;
                    lblTotalIVA.Visible = true;
                }
                else
                {
                    // Factura B o Remito: ocultar IVA
                    txtTotalIVA.Text = "0.00";
                    txtTotalIVA.Visible = false;
                    lblTotalIVA.Visible = false;
                }
                txtDescuento.Text = totalDescuentos.ToString();
                txtTotal.Text = totalFinal.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular totales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Ingrese el documento del cliente", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumentoCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
                return;
            }

            int productosValidos = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Count(r => r.Cells["Producto"].Value != null);

            if (productosValidos == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", "Validacion",
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
                        row.Cells["Descuento"].Value, 
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
               
                oCliente = new Cliente { IdCliente = int.Parse(txtIdCliente.Text) },

                // NumeroDocumento = string.Format("{0:00000}", _NumeroComprobanteActual), // Solo el nÃºmero
                NumeroDocumento = string.Format("{0:0000000000}", Convert.ToInt32(txtNumeroDocumento.Text)), // Solo el nÃºmero
                PuntoVenta = Convert.ToInt32(((OpcionCombo)cboPuntoVenta.SelectedItem).Valor),
                FormaPago = cboFormaPago.SelectedItem.ToString(),
                DocumentoCliente = txtDocumentoCliente.Text,
                NombreCliente = txtNombreCliente.Text,
                MontoPago = decimal.Parse(txtPagaCon.Text == "" ? "0" : txtPagaCon.Text),
                MontoCambio = decimal.Parse(txtCambio.Text),
                SubTotal = decimal.Parse(txtSubTotal.Text),
                TotalIVA = decimal.Parse(txtTotalIVA.Text),
                TotalDescuento = decimal.Parse(txtDescuento.Text),
                MontoTotal = decimal.Parse(txtTotal.Text)
            };

            string mensaje;
            int idVenta;
            bool resultado = new CN_Venta().RegistrarVentaFiscal(venta, detalle, out idVenta, out mensaje);

            if (resultado)
            {
                // Guardar nÃºmero de documento antes de limpiar
                string numeroDocumento = txtNumeroDocumento.Text;
                // Preguntar si desea imprimir el comprobante
                DialogResult respuesta = MessageBox.Show(
                    $"Venta registrada exitosamente\nNumero: {numeroDocumento}\n\n¿Desea imprimir el comprobante?",
                    "Venta Exitosa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    // Imprimir el comprobante antes de limpiar
                    ImprimirComprobanteActual(venta, detalle);
                }
                // Limpiar formulario para nueva carga
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show($"Error al registrar venta:\n{mensaje}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirComprobanteActual(Venta venta, DataTable detalle)
        {
            try
            {
                // Obtener venta completa con todos los datos necesarios
                Venta ventaCompleta = new CN_Venta().ObtenerVentaCompleta(venta.NumeroDocumento);

                if (ventaCompleta == null || ventaCompleta.IdVenta == 0)
                {
                    MessageBox.Show("No se pudo obtener el detalle del comprobante",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generar y mostrar PDF
                GeneradorComprobantes generador = new GeneradorComprobantes();
                generador.GenerarYMostrarVistaPrevia(ventaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}",
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
            txtIdCliente.Text = "";
            txtDocumentoCliente.Text = "";
            txtNombreCliente.Text = "";
            txtPagaCon.Text = "";
            txtCambio.Text = "0.00";
            ActualizarNumeroDocumento();
            LimpiarProductos();
            txtIdCliente.Focus();
        }

        private void ActualizarNumeroDocumento()
        {
            // Verificar que haya tipo de comprobante seleccionado
            if (_TipoComprobanteSeleccionado == null)
            {
                return;
            }

            // Verificar que haya punto de venta seleccionado
            if (cboPuntoVenta.SelectedItem == null)
            {
                return;
            }

            try
            {
                // Obtener punto de venta
                int puntoVenta = Convert.ToInt32(((OpcionCombo)cboPuntoVenta.SelectedItem).Valor);

                // Obtener siguiente número para este tipo de comprobante y punto de venta
                int numeroDocumento = new CN_Venta().ObtenerCorrelativoPorTipo(
                    _TipoComprobanteSeleccionado.IdTipoComprobante,
                    puntoVenta);

                // Actualizar el label o textbox donde muestras el número
                // Ajusta según tu formulario:
                txtNumeroDocumento.Text = string.Format("{0:0000000000}", numeroDocumento);
                // O si usas TextBox:
                // txtNumeroDocumento.Text = string.Format("{0:0000000000}", numeroDocumento);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener número de documento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new Modales.mdProducto())
            {
                modal.ShowDialog();
                // Solo para consulta, no se agrega al grid
            }
        }
  
        private void cboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento se dispara cuando cambia el punto de venta
            // Aquí puedes actualizar el número de documento si lo necesitas
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Verificar que haya un ID válido
                if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
                {
                    return;
                }

                try
                {
                    int idCliente = Convert.ToInt32(txtIdCliente.Text);

                    // Buscar el cliente
                    Cliente cliente = new CN_Cliente().Listar().FirstOrDefault(x => x.IdCliente == idCliente);

                    if (cliente != null)
                    {
                        // Llenar los datos del cliente
                        txtDocumentoCliente.Text = cliente.Cuit;
                        txtNombreCliente.Text = cliente.Nombre;

                        // Mover el foco al siguiente control
                        txtDocumentoCliente.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdCliente.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar cliente: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}