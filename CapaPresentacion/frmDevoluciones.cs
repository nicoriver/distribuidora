using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDevoluciones : Form
    {
        // Variables privadas
        private Venta _ventaOriginal;
        private List<Detalle_Venta> _detalleOriginal;
        private int _idTipoNC;
        private int _idUsuario;

        // Instancias de capa de negocio
        private CN_Venta_Extensiones objNegocio = new CN_Venta_Extensiones();

        public frmDevoluciones(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void frmDevoluciones_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView
            ConfigurarDataGridView();

            // Inicializar fecha
            dtpFecha.Value = DateTime.Now;

            // Deshabilitar botón guardar inicialmente
            btnGuardar.Enabled = false;
            // Cargar puntos de venta (0001 a 0005)
            for (int i = 1; i <= 5; i++)
            {
                cboPtoVentaD.Items.Add(new OpcionCombo()
                {
                    Valor = i,
                    Texto = string.Format("{0:0000}", i)
                });
            }
            cboPtoVentaD.DisplayMember = "Texto";
            cboPtoVentaD.ValueMember = "Valor";
            cboPtoVentaD.SelectedIndex = 0;

            // Cargar tipos de comprobantes
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().ListarParaVentas();
            int indexRemito = -1;
            int currentIndex = 0;
            foreach (TipoComprobante tipo in listaTipos)
            {
                cboTipocomprobanteD.Items.Add(new OpcionCombo()
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
            cboTipocomprobanteD.DisplayMember = "Texto";
            cboTipocomprobanteD.ValueMember = "Valor";
            cboTipocomprobanteD.SelectedIndex = indexRemito >= 0 ? indexRemito : 0;


        }

        private void ConfigurarDataGridView()
        {
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // ===== AGREGAR ESTAS LÍNEAS PRIMERO =====
            dgvDetalle.Columns.Clear(); // Limpiar columnas existentes

            dgvDetalle.Columns.Add("Codigo", "Código");
            dgvDetalle.Columns.Add("Producto", "Producto");
            dgvDetalle.Columns.Add("CantidadOriginal", "Cant. Original");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("PrecioVenta", "Precio");
            dgvDetalle.Columns.Add("PorcentajeIVA", "IVA %");
            dgvDetalle.Columns.Add("ImporteIVA", "Importe IVA");
            dgvDetalle.Columns.Add("SubTotal", "SubTotal");

            // Configurar anchos
            dgvDetalle.Columns["Codigo"].Width = 80;
            dgvDetalle.Columns["Producto"].Width = 300;
            dgvDetalle.Columns["CantidadOriginal"].Width = 80;
            dgvDetalle.Columns["Cantidad"].Width = 80;
            dgvDetalle.Columns["PrecioVenta"].Width = 100;
            dgvDetalle.Columns["PorcentajeIVA"].Width = 70;
            dgvDetalle.Columns["ImporteIVA"].Width = 100;
            dgvDetalle.Columns["SubTotal"].Width = 120;
            // ===== FIN DE LAS LÍNEAS NUEVAS =====
            // Configurar columnas editables (las que ya descomentaste)
            dgvDetalle.Columns["Codigo"].ReadOnly = true;
            dgvDetalle.Columns["Producto"].ReadOnly = true;
            dgvDetalle.Columns["CantidadOriginal"].ReadOnly = true;
            dgvDetalle.Columns["Cantidad"].ReadOnly = false; // Editable
            dgvDetalle.Columns["PrecioVenta"].ReadOnly = true;
            dgvDetalle.Columns["PorcentajeIVA"].ReadOnly = true;
            dgvDetalle.Columns["ImporteIVA"].ReadOnly = true;
            dgvDetalle.Columns["SubTotal"].ReadOnly = true;
        
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Configurar columnas editables
            dgvDetalle.Columns["Codigo"].ReadOnly = true;
            dgvDetalle.Columns["Producto"].ReadOnly = true;
            dgvDetalle.Columns["CantidadOriginal"].ReadOnly = true;
            dgvDetalle.Columns["Cantidad"].ReadOnly = false; // Editable
            dgvDetalle.Columns["PrecioVenta"].ReadOnly = true;
            dgvDetalle.Columns["PorcentajeIVA"].ReadOnly = true;
            dgvDetalle.Columns["ImporteIVA"].ReadOnly = true;
            dgvDetalle.Columns["SubTotal"].ReadOnly = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string numeroDocumento = txtNumeroComprobanteOriginal.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                MessageBox.Show("Debe ingresar un número de comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroComprobanteOriginal.Focus();
                return;
            }

            try
            {
                // Buscar la venta original
                string mensaje;
                OpcionCombo opcion = (OpcionCombo)cboTipocomprobanteD.SelectedItem;
                int idTipoComprobante = Convert.ToInt32(opcion.Valor);

                OpcionCombo punto = (OpcionCombo)cboPtoVentaD.SelectedItem;
                int idPtoventa = Convert.ToInt32(punto.Valor);                

                _ventaOriginal = objNegocio.ObtenerVentaPorNroDocTipoCompPtovta(numeroDocumento, idTipoComprobante, idPtoventa, out mensaje);

                if (_ventaOriginal == null)
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarFormulario();
                    return;
                }

                // Obtener el detalle de la venta
                _detalleOriginal = objNegocio.ObtenerDetalleVenta(_ventaOriginal.IdVenta, out mensaje);

                if (_detalleOriginal == null || _detalleOriginal.Count == 0)
                {
                    MessageBox.Show("No se encontró detalle para el comprobante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarFormulario();
                    return;
                }

                // Determinar el tipo de NC
                _idTipoNC = objNegocio.DeterminarTipoNotaCredito(_ventaOriginal.oTipoComprobante.IdTipoComprobante, out mensaje);

                if (_idTipoNC == 0)
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarFormulario();
                    return;
                }

                // Cargar datos en el formulario
                CargarDatosComprobante();
                CargarDetalleProductos();

                // Habilitar controles
                groupBox2.Enabled = true;
                btnGuardar.Enabled = true;

                MessageBox.Show("Comprobante cargado exitosamente. Puede modificar las cantidades si es necesario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el comprobante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosComprobante()
        {
            // Cargar tipo original
            txtTipoOriginal.Text = _ventaOriginal.oTipoComprobante?.Descripcion ?? _ventaOriginal.TipoDocumento;

            // Cargar tipo de NC
            txtTipoNC.Text = objNegocio.ObtenerDescripcionTipoNC(_ventaOriginal.oTipoComprobante.IdTipoComprobante);

            // Obtener próximo número de NC
            string mensajeNumero;
            string numeroNC = objNegocio.ObtenerProximoNumeroNC(_idTipoNC, out mensajeNumero);
            txtNumeroNC.Text = numeroNC;

            // Cargar fecha
            dtpFecha.Value = DateTime.Now;

            // Cargar cliente
            txtCliente.Text = _ventaOriginal.NombreCliente;
            txtDocumentoCliente.Text = _ventaOriginal.DocumentoCliente;

            AjustarColumnasSegunTipo(_ventaOriginal.oTipoComprobante.DiscriminaIVA);
        }

        private void AjustarColumnasSegunTipo(bool discriminaIVA)
        {
            if (discriminaIVA)
            {
                // Factura A - Mostrar columnas de IVA
                dgvDetalle.Columns["PorcentajeIVA"].Visible = true;
                dgvDetalle.Columns["ImporteIVA"].Visible = true;
            }
            else
            {
                // Factura B / Remito - Ocultar columnas de IVA
                dgvDetalle.Columns["PorcentajeIVA"].Visible = false;
                dgvDetalle.Columns["ImporteIVA"].Visible = false;
            }
        }
        private void CargarDetalleProductos()
        {
            dgvDetalle.Rows.Clear();

            foreach (var item in _detalleOriginal)
            {
                int index = dgvDetalle.Rows.Add();
                DataGridViewRow row = dgvDetalle.Rows[index];

                row.Cells["Codigo"].Value = item.oProducto?.Codigo ?? "";
                row.Cells["Producto"].Value = item.oProducto?.Nombre ?? "";
                row.Cells["CantidadOriginal"].Value = item.Cantidad;
                row.Cells["Cantidad"].Value = item.Cantidad; // Por defecto, devolver todo
                row.Cells["PrecioVenta"].Value = item.PrecioVenta.ToString("0.00");
                row.Cells["PorcentajeIVA"].Value = item.PorcentajeIVA.ToString("0.00");
                row.Cells["ImporteIVA"].Value = item.ImporteIVA.ToString("0.00");
                row.Cells["SubTotal"].Value = item.SubTotal.ToString("0.00");

                // Guardar el objeto completo en el Tag
                row.Tag = item;
            }

            // Calcular totales iniciales
            CalcularTotales();
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalle.Columns["Cantidad"].Index)
            {
                DataGridViewRow row = dgvDetalle.Rows[e.RowIndex];
                Detalle_Venta itemOriginal = (Detalle_Venta)row.Tag;

                // Validar cantidad
                int cantidadNueva;
                if (!int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out cantidadNueva))
                {
                    MessageBox.Show("La cantidad debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["Cantidad"].Value = itemOriginal.Cantidad;
                    return;
                }

                if (cantidadNueva < 0)
                {
                    MessageBox.Show("La cantidad no puede ser negativa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["Cantidad"].Value = itemOriginal.Cantidad;
                    return;
                }

                if (cantidadNueva > itemOriginal.Cantidad)
                {
                    MessageBox.Show($"La cantidad no puede ser mayor a la original ({itemOriginal.Cantidad})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["Cantidad"].Value = itemOriginal.Cantidad;
                    return;
                }

                // Recalcular valores de la fila
                RecalcularFila(row, cantidadNueva, itemOriginal);

                // Recalcular totales
                CalcularTotales();
            }
        }

        private void RecalcularFila(DataGridViewRow row, int cantidadNueva, Detalle_Venta itemOriginal)
        {
            // Calcular subtotal del item (precio * cantidad)
            decimal subtotalItem = itemOriginal.PrecioVenta * cantidadNueva;

            // Aplicar descuento si existe
            decimal descuentoItem = subtotalItem * (itemOriginal.PorcentajeDescuento / 100);
            decimal baseImponible = subtotalItem - descuentoItem;

            // Calcular IVA
            decimal ivaItem = baseImponible * (itemOriginal.PorcentajeIVA / 100);

            // Actualizar celdas
            row.Cells["ImporteIVA"].Value = ivaItem.ToString("0.00");
            row.Cells["SubTotal"].Value = baseImponible.ToString("0.00");
        }

        private void CalcularTotales()
        {
            decimal subTotal = 0;
            decimal totalIVA = 0;
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["SubTotal"].Value != null)
                {
                    decimal subtotalFila = Convert.ToDecimal(row.Cells["SubTotal"].Value);
                    decimal ivaFila = Convert.ToDecimal(row.Cells["ImporteIVA"].Value);

                    subTotal += subtotalFila;
                    totalIVA += ivaFila;
                }
            }

            total = subTotal + totalIVA;

            txtSubtotal.Text = subTotal.ToString("0.00");
            txtTotalIVA.Text = totalIVA.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya datos cargados
                if (_ventaOriginal == null)
                {
                    MessageBox.Show("Debe buscar un comprobante primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que haya al menos un producto con cantidad > 0
                bool hayProductos = false;
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    if (cantidad > 0)
                    {
                        hayProductos = true;
                        break;
                    }
                }

                if (!hayProductos)
                {
                    MessageBox.Show("Debe especificar al menos un producto con cantidad mayor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar operación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de generar la Nota de Crédito por un total de $ {txtTotal.Text}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado != DialogResult.Yes)
                {
                    return;
                }
                int indiceGuion = txtNumeroNC.Text.IndexOf('-');
                string nrodocumento = txtNumeroNC.Text.Substring(indiceGuion + 1);
                // Crear objeto Venta para la NC
                Venta notaCredito = new Venta()
                {
                    oUsuario = new Usuario() { IdUsuario = _idUsuario },
                    //oTipoComprobante = _TipoComprobanteSeleccionado,
                    oTipoComprobante =  new TipoComprobante() { IdTipoComprobante = _idTipoNC } ,
                    oCliente = new Cliente() { IdCliente = _ventaOriginal.oCliente.IdCliente },
                    IdVentaOriginal = _ventaOriginal.IdVenta,
                    TipoDocumento = txtTipoNC.Text,
                    NumeroDocumento = nrodocumento,
                    DocumentoCliente = _ventaOriginal.DocumentoCliente,
                    NombreCliente = _ventaOriginal.NombreCliente,
                    MontoPago = Convert.ToDecimal(txtTotal.Text),
                    MontoCambio = 0,
                    SubTotal = Convert.ToDecimal(txtSubtotal.Text),
                    TotalIVA = Convert.ToDecimal(txtTotalIVA.Text),
                    TotalDescuento = 0,
                    MontoTotal = Convert.ToDecimal(txtTotal.Text),
                    Observaciones = txtObservaciones.Text
                };

                // Crear lista de detalle
                List<Detalle_Venta> detalleNC = new List<Detalle_Venta>();

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                    if (cantidad > 0)
                    {
                        Detalle_Venta itemOriginal = (Detalle_Venta)row.Tag;

                        Detalle_Venta itemNC = new Detalle_Venta()
                        {
                        
                            //IdProducto = itemOriginal.IdProducto,
                            PrecioCosto = itemOriginal.PrecioCosto,
                            PrecioVenta = itemOriginal.PrecioVenta,
                            Cantidad = cantidad,
                            PorcentajeIVA = itemOriginal.PorcentajeIVA,
                            ImporteIVA = Convert.ToDecimal(row.Cells["ImporteIVA"].Value),
                            PorcentajeDescuento = itemOriginal.PorcentajeDescuento,
                            ImporteDescuento = 0,
                            SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value),
                            IdListaPrecio = itemOriginal.IdListaPrecio,
                            Observaciones = itemOriginal.Observaciones,
                            oProducto = itemOriginal.oProducto
                        };

                        detalleNC.Add(itemNC);
                    }
                }

                // Registrar la nota de crédito
                string mensaje;
                int idNotaCredito = objNegocio.RegistrarNotaCredito(notaCredito, detalleNC, out mensaje);

                if (idNotaCredito == 0)
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(
                    $"Nota de Crédito registrada exitosamente.\nNúmero: {txtNumeroNC.Text}\nTotal: $ {txtTotal.Text}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Preguntar si desea imprimir
                DialogResult imprimirResultado = MessageBox.Show(
                    "¿Desea imprimir la Nota de Crédito?",
                    "Imprimir",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (imprimirResultado == DialogResult.Yes)
                {
                    // TODO: Implementar impresión de NC
                    MessageBox.Show("Funcionalidad de impresión pendiente de implementar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpiar formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la Nota de Crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            // Limpiar búsqueda
            txtNumeroComprobanteOriginal.Text = "";

            // Limpiar datos del comprobante
            txtTipoOriginal.Text = "";
            txtTipoNC.Text = "";
            txtNumeroNC.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtCliente.Text = "";
            txtDocumentoCliente.Text = "";

            // Limpiar detalle
            dgvDetalle.Rows.Clear();

            // Limpiar totales
            txtSubtotal.Text = "0.00";
            txtTotalIVA.Text = "0.00";
            txtTotal.Text = "0.00";

            // Limpiar observaciones
            txtObservaciones.Text = "";

            // Resetear variables
            _ventaOriginal = null;
            _detalleOriginal = null;
            _idTipoNC = 0;

            // Deshabilitar controles
            groupBox2.Enabled = false;
            btnGuardar.Enabled = false;

            // Focus en búsqueda
            txtNumeroComprobanteOriginal.Focus();
        }

        private void dgvDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Resaltar la columna editable
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDetalle.Columns["Cantidad"].Index)
            {
                e.CellStyle.BackColor = Color.LightYellow;
            }
        }
    }
}
