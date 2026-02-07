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
            dgvProductos.Rows.Clear();
            dgvProductos.Columns.Clear();
            
            // Configuración general
            dgvProductos.AllowUserToAddRows = false; // ✅ IMPORTANTE: Evita que se agregue fila automática
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.ReadOnly = false;

            // Columna Código (editable)
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "Codigo";
            colCodigo.Width = 80;
            colCodigo.ReadOnly = false;
            dgvProductos.Columns.Add(colCodigo);

            // Columna IdProducto (oculta)
            DataGridViewTextBoxColumn colIdProducto = new DataGridViewTextBoxColumn();
            colIdProducto.HeaderText = "IdProducto";
            colIdProducto.Name = "IdProducto";
            colIdProducto.Visible = false;
            dgvProductos.Columns.Add(colIdProducto);

            // Columna Producto (readonly)
            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.HeaderText = "Producto";
            colProducto.Name = "Producto";
            colProducto.Width = 200;
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
            colUnidades.Width = 80;
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

            // ✅ Columna Botón Eliminar
            DataGridViewButtonColumn colEliminar = new DataGridViewButtonColumn();
            colEliminar.HeaderText = "";
            colEliminar.Name = "btnEliminar";
            colEliminar.Text = "Eliminar";
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.Width = 80;
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
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                string columnName = dgvProductos.Columns[e.ColumnIndex].Name;

                // FLUJO: Código → Unidades → Descuento → Código siguiente
                if (columnName == "Codigo")
                {
                    // Usuario ingresó código → Buscar producto
                    string codigo = row.Cells["Codigo"].Value?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(codigo))
                    {
                        BuscarYCargarProducto(e.RowIndex, codigo);
                    }
                    else
                    {
                        // ✅ Usuario borró código → Limpiar producto pero mantener unidades/descuento
                        row.Cells["IdProducto"].Value = null;
                        row.Cells["Producto"].Value = "";
                        row.Cells["Precio"].Value = 0;
                        CalcularTotalesLinea(e.RowIndex);
                        CalcularTotalesGenerales();
                    }
                }
                else if (columnName == "Unidades")
                {
                    // Usuario ingresó unidades → Calcular y mover a Descuento
                    CalcularTotalesLinea(e.RowIndex);
                    CalcularTotalesGenerales();
                    
                    // ✅ Usar BeginInvoke para evitar error SetCurrentCellAddressCore
                    this.BeginInvoke(new Action(() =>
                    {
                        if (e.RowIndex < dgvProductos.Rows.Count)
                        {
                            dgvProductos.CurrentCell = dgvProductos.Rows[e.RowIndex].Cells["DescuentoPorcentaje"];
                            dgvProductos.BeginEdit(true);
                        }
                    }));
                }
                else if (columnName == "DescuentoPorcentaje")
                {
                    // Usuario ingresó descuento → Calcular y mover a siguiente fila
                    CalcularTotalesLinea(e.RowIndex);
                    CalcularTotalesGenerales();
                    
                    // ✅ Usar BeginInvoke para evitar error SetCurrentCellAddressCore
                    int currentRow = e.RowIndex;
                    this.BeginInvoke(new Action(() =>
                    {
                        if (currentRow + 1 < dgvProductos.Rows.Count)
                        {
                            // Ya existe siguiente fila
                            dgvProductos.CurrentCell = dgvProductos.Rows[currentRow + 1].Cells["Codigo"];
                            dgvProductos.BeginEdit(true);
                        }
                        else
                        {
                            // No existe, crear nueva fila vacía
                            AgregarFilaVacia();
                            dgvProductos.CurrentCell = dgvProductos.Rows[currentRow + 1].Cells["Codigo"];
                            dgvProductos.BeginEdit(true);
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al editar celda: {ex.Message}");
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
            if (e.RowIndex < 0) return;

            // ✅ Manejar click en botón Eliminar
            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                string producto = row.Cells["Producto"].Value?.ToString() ?? "";

                if (!string.IsNullOrWhiteSpace(producto))
                {
                    if (SolicitarConfirmacion($"¿Eliminar el producto '{producto}'?"))
                    {
                        dgvProductos.Rows.RemoveAt(e.RowIndex);
                        CalcularTotalesGenerales();
                    }
                }
                else
                {
                    // Fila vacía, eliminar sin confirmar
                    dgvProductos.Rows.RemoveAt(e.RowIndex);
                    CalcularTotalesGenerales();
                }
            }
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
                        CalcularTotalesGenerales();
                    }
                    
                    // Prevenir que el evento se propague
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
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
                    // ✅ IGNORAR filas vacías (sin producto)
                    if (row.Cells["IdProducto"].Value == null || 
                        string.IsNullOrWhiteSpace(row.Cells["IdProducto"].Value.ToString()))
                    {
                        continue;
                    }

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
                // - Remito (R): NO aplica IVA
                
                if (_TipoComprobanteSeleccionado != null && _TipoComprobanteSeleccionado.Codigo != "R")
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

                // ✅ Mostrar solo el número con 10 dígitos (sin punto de venta)
                // El punto de venta ya se muestra en cboPuntoVenta
                txtNumeroDocumento.Text = proximoNumero.ToString("0000000000");
            }
            catch (Exception ex)
            {
                // Si falla, usar número 1 por defecto
                txtNumeroDocumento.Text = "0000000001";
                MostrarError($"Error al obtener próximo número: {ex.Message}");
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

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPagaCon.Text, out decimal pagaCon))
            {
                decimal total = 0;
                decimal.TryParse(lblTotal.Text, out total);
                
                decimal cambio = pagaCon - total;
                txtCambio.Text = cambio.ToString("N2");
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones
                if (!ValidarVenta(out string mensajeError))
                {
                    MostrarError(mensajeError);
                    return;
                }

                // 2. Confirmar guardado
                if (!SolicitarConfirmacion($"¿Desea guardar la venta?\n\nTipo: {_TipoComprobanteSeleccionado.Descripcion}\nCliente: {txtNombreCliente.Text}\nTotal: ${lblTotal.Text}"))
                {
                    return;
                }

                // 2. Calcular totales
                decimal subtotal = decimal.Parse(lblSubtotal.Text);
                decimal descuentoTotal = decimal.Parse(lblDescuento.Text);
                decimal iva = decimal.Parse(lblIVA.Text);
                decimal total = decimal.Parse(lblTotal.Text);

                // 3. Crear objeto Venta
                int puntoVenta = Convert.ToInt32(((OpcionCombo)cboPuntoVenta.SelectedItem).Valor);

                // ✅ Construir número de documento completo: NNNNNNNNNN
                // txtNumeroDocumento solo tiene el número (10 dígitos)
                //string numeroCompleto = $"{puntoVenta:0000}-{txtNumeroDocumento.Text}";
                string numeroCompleto = $"{txtNumeroDocumento.Text}";
                Venta oVenta = new Venta
                {
                    oUsuario = new Usuario { IdUsuario = 1 }, // TODO: Usuario actual
                    
                    // Asignar objetos completos para que el stored procedure extraiga los IDs
                    oTipoComprobante = _TipoComprobanteSeleccionado,
                    oCliente = _ClienteSeleccionado,
                    NumeroDocumento = numeroCompleto, // ✅ Formato completo: 0001-0000000123
                    PuntoVenta = puntoVenta,
                    TipoDocumento = _TipoComprobanteSeleccionado.Codigo,
                    DocumentoCliente = _ClienteSeleccionado.Dni,
                    NombreCliente = $"{_ClienteSeleccionado.Apellido}, {_ClienteSeleccionado.Nombre}",
                    FechaRegistro = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    
                    // Estructura AFIP
                    SubTotal = subtotal,
                    TotalDescuento = descuentoTotal,
                    TotalIVA = iva,
                    MontoTotal = total,
                    
                    // Pago (opcional)
                    FormaPago = cboFormaPago.SelectedItem?.ToString() ?? "Efectivo",
                    MontoPago = decimal.TryParse(txtPagaCon.Text, out decimal pago) ? pago : 0,
                    MontoCambio = decimal.TryParse(txtCambio.Text, out decimal cambio) ? cambio : 0
                };

                // 4. Preparar detalles como DataTable para sp_RegistrarVentaFiscal
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("IdProducto", typeof(int));
                dtDetalles.Columns.Add("PrecioCosto", typeof(decimal));
                dtDetalles.Columns.Add("PrecioVenta", typeof(decimal));
                dtDetalles.Columns.Add("Cantidad", typeof(int));
                dtDetalles.Columns.Add("PorcentajeIVA", typeof(decimal));
                dtDetalles.Columns.Add("ImporteIVA", typeof(decimal));
                dtDetalles.Columns.Add("PorcentajeDescuento", typeof(decimal));
                dtDetalles.Columns.Add("ImporteDescuento", typeof(decimal));
                dtDetalles.Columns.Add("SubTotal", typeof(decimal));
                dtDetalles.Columns.Add("IdListaPrecio", typeof(int));
                dtDetalles.Columns.Add("Observaciones", typeof(string));
                
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["IdProducto"].Value == null) continue;

                    int IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                    decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                    decimal unidades = Convert.ToDecimal(row.Cells["Unidades"].Value);
                    decimal descPorcentaje = Convert.ToDecimal(row.Cells["DescuentoPorcentaje"].Value ?? 0);
                    decimal totalItem = Convert.ToDecimal(row.Cells["Total"].Value);

                    // Calcular importes según AFIP
                    decimal subtotalItem = precio * unidades;
                    decimal importeDescuento = subtotalItem * (descPorcentaje / 100);
                    decimal subtotalConDescuento = subtotalItem - importeDescuento;
                    
                    // IVA: 21% para Facturas, 0% para Remitos
                    decimal porcentajeIVA = (_TipoComprobanteSeleccionado.Codigo != "R") ? 21 : 0;
                    decimal importeIVA = subtotalConDescuento * (porcentajeIVA / 100);

                    // TODO: Obtener precio de costo real del producto
                    decimal precioCosto = 0; // Por ahora en 0, debería venir de la BD

                    dtDetalles.Rows.Add(
                        IdProducto,
                        precioCosto,
                        precio,
                        Convert.ToInt32(unidades),
                        porcentajeIVA,
                        importeIVA,
                        descPorcentaje,
                        importeDescuento,
                        totalItem,
                        _IdListaPrecioActual,
                        DBNull.Value // Observaciones
                    );
                }

                // 5. Guardar en BD usando RegistrarVentaFiscal
                string mensaje = string.Empty;
                int idVentaGenerado = 0;
                bool resultado = new CN_Venta().RegistrarVentaFiscal(oVenta, dtDetalles, out idVentaGenerado, out mensaje);

                if (resultado)
                {
                    MostrarExito($"Venta registrada correctamente\n\n" +
                               $"ID Venta: {idVentaGenerado}\n" +
                               $"Tipo: {_TipoComprobanteSeleccionado.Descripcion}\n" +
                               $"Número: {txtNumeroDocumento.Text}\n" +
                               $"Total: ${total:N2}");
                    
                    // Generar PDF del comprobante
                    try
                    {
                        // Obtener la venta completa para el PDF
                        Venta ventaCompleta = new CN_Venta().ObtenerVentaCompleta(
                            txtNumeroDocumento.Text, 
                            Convert.ToInt32(((OpcionCombo)cboPuntoVenta.SelectedItem).Valor),
                            _TipoComprobanteSeleccionado.IdTipoComprobante
                        );

                        if (ventaCompleta != null && ventaCompleta.IdVenta > 0)
                        {
                            var generador = new Reportes.GeneradorComprobantesFiscales();
                            
                            DialogResult respuesta = MessageBox.Show(
                                "¿Desea generar el comprobante en PDF?",
                                "Generar Comprobante",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (respuesta == DialogResult.Yes)
                            {
                                string rutaPDF = generador.GuardarYAbrir(ventaCompleta);
                                MessageBox.Show($"Comprobante generado:\n{rutaPDF}", 
                                    "PDF Generado", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception exPDF)
                    {
                        MessageBox.Show($"La venta se guardó correctamente, pero hubo un error al generar el PDF:\n{exPDF.Message}",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    
                    LimpiarFormulario();
                }
                else
                {
                    MostrarError("Error al guardar la venta:\n" + mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al procesar la venta:\n" + ex.Message);
            }
        }

        private bool ValidarVenta(out string mensaje)
        {
            mensaje = string.Empty;

            // 1. Validar cliente
            if (_ClienteSeleccionado == null)
            {
                mensaje = "Debe seleccionar un cliente antes de guardar la venta.";
                txtIdCliente.Focus();
                return false;
            }

            // 2. Validar que hay productos
            int cantidadProductos = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                // ✅ IGNORAR filas vacías (sin producto)
                if (row.Cells["IdProducto"].Value != null && 
                    !string.IsNullOrWhiteSpace(row.Cells["IdProducto"].Value.ToString()))
                {
                    cantidadProductos++;
                }
            }

            if (cantidadProductos == 0)
            {
                mensaje = "Debe agregar al menos un producto a la venta.";
                dgvProductos.Focus();
                return false;
            }

            // 3. Validar cantidades y descuentos
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                // ✅ IGNORAR filas vacías (sin producto)
                if (row.Cells["IdProducto"].Value == null || 
                    string.IsNullOrWhiteSpace(row.Cells["IdProducto"].Value.ToString()))
                {
                    continue;
                }

                string producto = row.Cells["Producto"].Value?.ToString() ?? "";

                // Validar cantidad
                decimal cantidad = 0;
                if (!decimal.TryParse(row.Cells["Unidades"].Value?.ToString(), out cantidad) || cantidad <= 0)
                {
                    mensaje = $"La cantidad del producto '{producto}' debe ser mayor a 0.";
                    dgvProductos.CurrentCell = row.Cells["Unidades"];
                    dgvProductos.BeginEdit(true);
                    return false;
                }

                // Validar descuento
                decimal descuento = 0;
                decimal.TryParse(row.Cells["DescuentoPorcentaje"].Value?.ToString(), out descuento);
                
                if (descuento < 0 || descuento > 100)
                {
                    mensaje = $"El descuento del producto '{producto}' debe estar entre 0% y 100%.";
                    dgvProductos.CurrentCell = row.Cells["DescuentoPorcentaje"];
                    dgvProductos.BeginEdit(true);
                    return false;
                }
            }

            // 4. Validar forma de pago
            if (cboFormaPago.SelectedIndex == -1)
            {
                mensaje = "Debe seleccionar una forma de pago.";
                cboFormaPago.Focus();
                return false;
            }

            // ✅ ELIMINADO: No validar "Paga con" - es opcional
            // El usuario puede guardar sin completar este campo

            // 5. Validar total
            decimal totalVenta = 0;
            decimal.TryParse(lblTotal.Text, out totalVenta);

            if (totalVenta <= 0)
            {
                mensaje = "El total de la venta debe ser mayor a 0.";
                return false;
            }

            return true;
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
            // Cliente
            txtIdCliente.Text = "";
            txtNombreCliente.Text = "";
            txtCondicionIVA.Text = "";
            _ClienteSeleccionado = null;

            // Grid
            dgvProductos.Rows.Clear();
            AgregarFilaVacia();

            // Totales
            lblSubtotal.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblIVA.Text = "0.00";
            lblTotal.Text = "0.00";

            // Pago
            txtPagaCon.Text = "0";
            txtCambio.Text = "0";

            // Actualizar número de documento para próxima venta
            ActualizarNumeroDocumento();

            // Foco en cliente
            txtIdCliente.Focus();
        }
    }
}
