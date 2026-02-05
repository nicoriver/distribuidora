using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Net8.Base;
using CapaPresentacion.Net8.Utilidades;

namespace CapaPresentacion.Net8
{
    public partial class frmVentasFiscales : FormularioBase
    {
        private TipoComprobante _TipoComprobanteSeleccionado;
        private int _IdListaPrecioActual = 0;
        private Cliente _ClienteSeleccionado = null;

        public frmVentasFiscales()
        {
            InitializeComponent();
        }

        private void frmVentasFiscales_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar Punto de Venta (hardcoded por ahora)
            cboPuntoVenta.Items.Add(new OpcionCombo() { Valor = 1, Texto = "0001" });
            cboPuntoVenta.Items.Add(new OpcionCombo() { Valor = 2, Texto = "0002" });
            cboPuntoVenta.DisplayMember = "Texto";
            cboPuntoVenta.ValueMember = "Valor";
            if (cboPuntoVenta.Items.Count > 0)
                cboPuntoVenta.SelectedIndex = 0;

            // Cargar Tipos de Comprobante
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().ListarParaVentas();

            // Buscar índice de Remito para seleccionarlo por defecto
            int indexRemito = -1;
            for (int i = 0; i < listaTipos.Count; i++)
            {
                if (listaTipos[i].Codigo == "R")
                {
                    indexRemito = i;
                    break;
                }
            }

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
            cboTipoComprobante.SelectedIndex = indexRemito >= 0 ? indexRemito : 0;

            // Cargar Forma de Pago
            cboFormaPago.Items.Add("Efectivo");
            cboFormaPago.Items.Add("Tarjeta");
            cboFormaPago.Items.Add("Transferencia");
            cboFormaPago.Items.Add("Cuenta Corriente");
            cboFormaPago.SelectedIndex = 0;

            // Fecha ayer (según documentación)
            dtpFecha.Value = DateTime.Now.AddDays(-1);

            // Agregar primera fila vacía
            AgregarFilaVacia();
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.Rows.Clear();
            dgvProductos.AllowUserToAddRows = false;

            // Columna Código (editable)
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "Codigo";
            colCodigo.Width = 100;
            colCodigo.ReadOnly = false;
            dgvProductos.Columns.Add(colCodigo);

            // Columna IdProducto (oculta - para uso interno)
            DataGridViewTextBoxColumn colIdProducto = new DataGridViewTextBoxColumn();
            colIdProducto.HeaderText = "IdProducto";
            colIdProducto.Name = "IdProducto";
            colIdProducto.Visible = false;
            dgvProductos.Columns.Add(colIdProducto);

            // Columna Producto (readonly)
            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.HeaderText = "Producto";
            colProducto.Name = "Producto";
            colProducto.Width = 300;
            colProducto.ReadOnly = true;
            dgvProductos.Columns.Add(colProducto);

            // Columna Precio (readonly)
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "Precio";
            colPrecio.Width = 100;
            colPrecio.ReadOnly = true;
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPrecio.DefaultCellStyle.Format = "N2";
            dgvProductos.Columns.Add(colPrecio);

            // Columna Unidades (editable)
            DataGridViewTextBoxColumn colUnidades = new DataGridViewTextBoxColumn();
            colUnidades.HeaderText = "Unidades";
            colUnidades.Name = "Unidades";
            colUnidades.Width = 90;
            colUnidades.ReadOnly = false;
            colUnidades.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colUnidades);

            // Columna Descuento % (editable)
            DataGridViewTextBoxColumn colDescPorc = new DataGridViewTextBoxColumn();
            colDescPorc.HeaderText = "Descuento (%)";
            colDescPorc.Name = "DescuentoPorcentaje";
            colDescPorc.Width = 100;
            colDescPorc.ReadOnly = false;
            colDescPorc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns.Add(colDescPorc);

            // Columna Total (readonly)
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.HeaderText = "Total";
            colTotal.Name = "Total";
            colTotal.Width = 120;
            colTotal.ReadOnly = true;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotal.DefaultCellStyle.Format = "N2";
            dgvProductos.Columns.Add(colTotal);

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

            // Actualizar número de documento
            ActualizarNumeroDocumento();

            // Actualizar etiquetas de totales según tipo de comprobante
            bool discriminaIVA = _TipoComprobanteSeleccionado.DiscriminaIVA;

            if (discriminaIVA)
            {
                // Factura A - Discrimina IVA
                lblSubtotalLabel.Text = "Neto Gravado:";
                lblIVALabel.Visible = true;
                lblIVA.Visible = true;
            }
            else
            {
                // Factura B o Remito - No discrimina
                lblSubtotalLabel.Text = "Subtotal:";
                lblIVALabel.Visible = false;
                lblIVA.Visible = false;
            }

            // Recalcular totales
            CalcularTotalesGenerales();
        }

        private void AgregarFilaVacia()
        {
            // 6 columnas: Codigo, IdProducto, Producto, Precio, Unidades, DescuentoPorcentaje, Total
            dgvProductos.Rows.Add("", "", "", 0, 0, 0, 0);
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
            string columnName = dgvProductos.Columns[e.ColumnIndex].Name;

            // FLUJO: Código → Unidades → Descuento
            if (columnName == "Codigo")
            {
                // Usuario ingresó código → Buscar producto
                string codigo = row.Cells["Codigo"].Value?.ToString() ?? "";
                if (!string.IsNullOrWhiteSpace(codigo))
                {
                    BuscarYCargarProducto(e.RowIndex, codigo);
                }
            }
            else if (columnName == "Unidades")
            {
                // Usuario ingresó unidades → Calcular y mover a Descuento
                CalcularTotalesLinea(e.RowIndex);
                
                // Mover foco a Descuento
                dgvProductos.CurrentCell = row.Cells["DescuentoPorcentaje"];
                dgvProductos.BeginEdit(true);
            }
            else if (columnName == "DescuentoPorcentaje")
            {
                // Usuario ingresó descuento → Calcular, nueva fila, volver a Código
                CalcularTotalesLinea(e.RowIndex);
                
                // Agregar nueva fila vacía si es la última
                if (e.RowIndex == dgvProductos.Rows.Count - 1)
                {
                    AgregarFilaVacia();
                }
                
                // Mover foco a Código de la siguiente fila
                if (e.RowIndex + 1 < dgvProductos.Rows.Count)
                {
                    dgvProductos.CurrentCell = dgvProductos.Rows[e.RowIndex + 1].Cells["Codigo"];
                    dgvProductos.BeginEdit(true);
                }
            }
        }

        private void BuscarYCargarProducto(int rowIndex, string codigo)
        {
            try
            {
                // Buscar producto por código
                Producto producto = new CN__Producto().Listar()
                    .FirstOrDefault(p => p.Codigo == codigo);

                if (producto == null)
                {
                    MostrarError($"Producto con código '{codigo}' no encontrado");
                    dgvProductos.Rows[rowIndex].Cells["Codigo"].Value = "";
                    return;
                }

                // Obtener precio según lista del tipo de comprobante
                string mensaje = "";
                decimal precio = new CN_Lista().ObtenerPrecioProducto(
                    producto.IdProducto,
                    _IdListaPrecioActual,
                    out mensaje
                );

                if (precio == 0)
                {
                    MostrarError($"No se encontró precio para el producto en la lista seleccionada");
                    return;
                }

                // Completar datos del producto
                DataGridViewRow row = dgvProductos.Rows[rowIndex];
                row.Cells["IdProducto"].Value = producto.IdProducto;
                row.Cells["Producto"].Value = producto.Nombre;
                row.Cells["Precio"].Value = precio;
                
                // Inicializar Unidades en 0 si está vacío
                if (row.Cells["Unidades"].Value == null || 
                    string.IsNullOrWhiteSpace(row.Cells["Unidades"].Value.ToString()))
                {
                    row.Cells["Unidades"].Value = 0;
                }
                
                // Inicializar Descuento en 0 si está vacío
                if (row.Cells["DescuentoPorcentaje"].Value == null || 
                    string.IsNullOrWhiteSpace(row.Cells["DescuentoPorcentaje"].Value.ToString()))
                {
                    row.Cells["DescuentoPorcentaje"].Value = 0;
                }

                // Mover foco a Unidades
                dgvProductos.CurrentCell = row.Cells["Unidades"];
                dgvProductos.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MostrarError("Error al buscar producto: " + ex.Message);
            }
        }

        private void CalcularTotalesLinea(int rowIndex)
        {
            try
            {
                DataGridViewRow row = dgvProductos.Rows[rowIndex];

                // Obtener valores
                decimal precio = 0;
                decimal unidades = 0;
                decimal descPorcentaje = 0;

                decimal.TryParse(row.Cells["Precio"].Value?.ToString() ?? "0", out precio);
                decimal.TryParse(row.Cells["Unidades"].Value?.ToString() ?? "0", out unidades);
                decimal.TryParse(row.Cells["DescuentoPorcentaje"].Value?.ToString() ?? "0", out descPorcentaje);

                // Calcular total del ítem
                // Total = (Precio × Unidades) - Descuento$
                // Descuento$ = (Precio × Unidades) × (Desc% / 100)
                
                decimal subtotalItem = precio * unidades;
                decimal descuentoItem = subtotalItem * (descPorcentaje / 100);
                decimal totalItem = subtotalItem - descuentoItem;

                // Actualizar Total de la fila
                row.Cells["Total"].Value = totalItem;

                // Actualizar totales generales
                CalcularTotalesGenerales();
            }
            catch (Exception ex)
            {
                MostrarError("Error al calcular totales: " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementaremos en Fase 3
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // Eliminar fila actual
                if (dgvProductos.CurrentRow != null && !dgvProductos.CurrentRow.IsNewRow)
                {
                    int rowIndex = dgvProductos.CurrentRow.Index;
                    
                    // Confirmar eliminación si tiene datos
                    string producto = dgvProductos.CurrentRow.Cells["Producto"].Value?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(producto))
                    {
                        if (SolicitarConfirmacion($"¿Eliminar el producto '{producto}'?"))
                        {
                            dgvProductos.Rows.RemoveAt(rowIndex);
                            CalcularTotalesGenerales();
                        }
                    }
                    else
                    {
                        // Fila vacía, eliminar sin confirmar
                        dgvProductos.Rows.RemoveAt(rowIndex);
                    }
                }
                
                e.Handled = true;
            }
        }

        private void CalcularTotalesGenerales()
        {
            try
            {
                decimal subtotal = 0;
                decimal descuentoTotal = 0;

                // Sumar todos los ítems
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.IsNewRow) continue;

                    decimal precio = 0;
                    decimal unidades = 0;
                    decimal descPorcentaje = 0;

                    decimal.TryParse(row.Cells["Precio"].Value?.ToString() ?? "0", out precio);
                    decimal.TryParse(row.Cells["Unidades"].Value?.ToString() ?? "0", out unidades);
                    decimal.TryParse(row.Cells["DescuentoPorcentaje"].Value?.ToString() ?? "0", out descPorcentaje);

                    decimal subtotalItem = precio * unidades;
                    decimal descuentoItem = subtotalItem * (descPorcentaje / 100);

                    subtotal += subtotalItem;
                    descuentoTotal += descuentoItem;
                }

                // Calcular neto (subtotal - descuento)
                decimal neto = subtotal - descuentoTotal;

                // Calcular IVA y Total según tipo de comprobante
                decimal iva = 0;
                decimal total = 0;

                // IMPORTANTE: Tanto Factura A como Factura B aplican IVA 21%
                // La diferencia es:
                // - Factura A (DiscriminaIVA=1): MUESTRA el IVA discriminado
                // - Factura B (DiscriminaIVA=0): NO MUESTRA el IVA pero SÍ lo aplica
                // - Remito (REC): NO aplica IVA
                
                if (_TipoComprobanteSeleccionado != null && _TipoComprobanteSeleccionado.Codigo != "REC")
                {
                    // Factura A o Factura B - Ambas aplican IVA 21%
                    iva = neto * 0.21m;
                    total = neto + iva;
                }
                else
                {
                    // Remito - No aplica IVA
                    total = neto;
                }

                // Mostrar totales
                lblSubtotal.Text = subtotal.ToString("N2");
                lblDescuento.Text = descuentoTotal.ToString("N2");
                lblIVA.Text = iva.ToString("N2");
                lblTotal.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MostrarError("Error al calcular totales: " + ex.Message);
            }
        }

        private void ActualizarNumeroDocumento()
        {
            if (_TipoComprobanteSeleccionado == null)
            {
                txtNumeroDocumento.Text = "";
                return;
            }

            if (cboPuntoVenta.SelectedItem == null)
            {
                txtNumeroDocumento.Text = "";
                return;
            }

            int puntoVenta = Convert.ToInt32(((OpcionCombo)cboPuntoVenta.SelectedItem).Valor);

            try
            {
                // Obtener el próximo número desde la base de datos
                int proximoNumero = new CN_Venta().ObtenerProximoNumero(
                    _TipoComprobanteSeleccionado.IdTipoComprobante,
                    puntoVenta
                );

                string puntoVentaStr = puntoVenta.ToString("0000");
                string numeroStr = proximoNumero.ToString("00000000");

                txtNumeroDocumento.Text = $"{puntoVentaStr}-{numeroStr}";
            }
            catch (Exception ex)
            {
                // Si falla, usar número 1 por defecto
                string puntoVentaStr = puntoVenta.ToString("0000");
                string numeroStr = "00000001";
                txtNumeroDocumento.Text = $"{puntoVentaStr}-{numeroStr}";
                
                MostrarError("Error al obtener número de documento: " + ex.Message);
            }
        }

        private void cboPuntoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNumeroDocumento();
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarCliente();
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                MostrarError("Ingrese un ID de cliente");
                return;
            }

            int idCliente = 0;
            if (!int.TryParse(txtIdCliente.Text, out idCliente))
            {
                MostrarError("ID de cliente inválido");
                return;
            }

            Cliente cliente = new CN_Cliente().Listar().FirstOrDefault(c => c.IdCliente == idCliente);

            if (cliente == null)
            {
                MostrarError("Cliente no encontrado");
                _ClienteSeleccionado = null;
                txtNombreCliente.Text = "";
                txtCondicionIVA.Text = "";
                return;
            }

            _ClienteSeleccionado = cliente;
            txtNombreCliente.Text = $"{cliente.Apellido}, {cliente.Nombre}";
            txtCondicionIVA.Text = ""; // TODO: Cargar desde tabla CodigoIVA si es necesario
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            // Implementaremos en Fase 5
            MostrarError("Funcionalidad de guardar será implementada en Fase 5");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (SolicitarConfirmacion("¿Desea cancelar la venta actual?"))
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtCondicionIVA.Text = "";
            _ClienteSeleccionado = null;

            dgvProductos.Rows.Clear();
            AgregarFilaVacia();

            txtPagaCon.Text = "0";
            txtCambio.Text = "0";

            CalcularTotalesGenerales();
        }
    }
}
