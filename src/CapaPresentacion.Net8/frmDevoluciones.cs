using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Net8.Utilidades;
using CapaPresentacion.Net8.Base;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDevoluciones : Form
    {
        private Venta? _VentaOriginal;

        public frmDevoluciones()
        {
            InitializeComponent();
        }

        private void frmDevoluciones_Load(object sender, EventArgs e)
        {
            // Cargar combos
            CargarTiposComprobante();
            CargarPuntosVenta();
            
            // Inicializar controles
            LimpiarFormulario();
        }

        private void CargarTiposComprobante()
        {
            List<TipoComprobante> listaTipos = new CN_TipoComprobante().ListarParaVentas();
            
            cboTipoComprobante.Items.Clear();
            foreach (TipoComprobante item in listaTipos)
            {
                cboTipoComprobante.Items.Add(new OpcionCombo
                {
                    Valor = item.IdTipoComprobante,
                    Texto = item.Descripcion
                });
            }
            cboTipoComprobante.DisplayMember = "Texto";
            cboTipoComprobante.ValueMember = "Valor";
            
            if (cboTipoComprobante.Items.Count > 0)
                cboTipoComprobante.SelectedIndex = 0;
        }

        private void CargarPuntosVenta()
        {
            // Por ahora solo punto de venta 1
            // TODO: Cargar desde BD si hay múltiples puntos de venta
            cboPuntoVenta.Items.Clear();
            cboPuntoVenta.Items.Add(new OpcionCombo { Valor = 1, Texto = "0001" });
            cboPuntoVenta.DisplayMember = "Texto";
            cboPuntoVenta.ValueMember = "Valor";
            
            if (cboPuntoVenta.Items.Count > 0)
                cboPuntoVenta.SelectedIndex = 0;
        }

        #region Búsqueda de Venta Original

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado tipo de comprobante
            if (cboTipoComprobante.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de comprobante", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoComprobante.Focus();
                return;
            }

            // Validar que se haya seleccionado punto de venta
            if (cboPuntoVenta.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un punto de venta", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPuntoVenta.Focus();
                return;
            }
            int idTipoSeleccionado = Convert.ToInt32(((OpcionCombo)cboTipoComprobante.SelectedItem).Valor);
            string numeroIngresado = txtNumeroDocumento.Text.Trim();

            if (string.IsNullOrEmpty(numeroIngresado))
            {
                MessageBox.Show("Ingrese un número de documento", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroDocumento.Focus();
                return;
            }

            // Validar que sea un número
            if (!int.TryParse(numeroIngresado, out int numero))
            {
                MessageBox.Show("El número debe ser un valor numérico", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroDocumento.Focus();
                return;
            }

            try
            {
                // Construir número completo: PPPP-NNNNNNNNNN
                int puntoVenta = Convert.ToInt32(((OpcionCombo)cboPuntoVenta.SelectedItem).Valor);
                string numeroFormateado = numero.ToString("0000000000"); // 10 dígitos
                string numeroDocumento = $"{puntoVenta:0000}-{numeroFormateado}";

                // Buscar venta completa
                _VentaOriginal = new CN_Venta().ObtenerVentaCompleta(numeroFormateado, puntoVenta, idTipoSeleccionado);

                if (_VentaOriginal == null || _VentaOriginal.IdVenta == 0)
                {
                    MessageBox.Show("No se encontró una venta con ese número de documento", 
                        "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validar que el tipo de comprobante coincida
                 idTipoSeleccionado = Convert.ToInt32(((OpcionCombo)cboTipoComprobante.SelectedItem).Valor);
                if (_VentaOriginal.oTipoComprobante.IdTipoComprobante != idTipoSeleccionado)
                {
                    MessageBox.Show($"La venta encontrada es de tipo '{_VentaOriginal.oTipoComprobante.Descripcion}' " +
                                  $"pero seleccionó '{((OpcionCombo)cboTipoComprobante.SelectedItem).Texto}'",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que no sea una Nota de Crédito
                if (_VentaOriginal.oTipoComprobante != null && 
                    _VentaOriginal.oTipoComprobante.EsNotaCredito)
                {
                    MessageBox.Show("No se puede crear una Nota de Crédito de otra Nota de Crédito", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que tenga productos
                if (_VentaOriginal.oDetalle_Venta == null || _VentaOriginal.oDetalle_Venta.Count == 0)
                {
                    MessageBox.Show("La venta no tiene productos", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargar datos en el formulario
                CargarDatosVenta();
                CargarProductos();
                HabilitarControles(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la venta:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosVenta()
        {
            // Mostrar datos de la venta original
            lblTipoOriginal.Text = _VentaOriginal.oTipoComprobante?.Descripcion ?? "N/A";
            lblFechaOriginal.Text = _VentaOriginal.FechaRegistro;
            lblClienteOriginal.Text = $"{_VentaOriginal.NombreCliente} - {_VentaOriginal.DocumentoCliente}";
            lblTotalOriginal.Text = $"${_VentaOriginal.MontoTotal:N2}";
        }

        private void CargarProductos()
        {
            dgvProductos.Rows.Clear();

            if (_VentaOriginal.oDetalle_Venta == null || _VentaOriginal.oDetalle_Venta.Count == 0)
            {
                MessageBox.Show("La venta no tiene productos en el detalle.", 
                    "Sin Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productosAgregados = 0;
            foreach (var detalle in _VentaOriginal.oDetalle_Venta)
            {
                // DEBUG: Verificar valores
                int idProducto = detalle.oProducto?.IdProducto ?? 0;
                string codigo = detalle.oProducto?.Codigo ?? "N/A";
                string nombre = detalle.oProducto?.Nombre ?? "N/A";

                System.Diagnostics.Debug.WriteLine($"Cargando producto: IdProducto={idProducto}, Codigo={codigo}, Nombre={nombre}");

                if (idProducto == 0)
                {
                    MessageBox.Show($"ADVERTENCIA: Producto sin IdProducto válido.\n\n" +
                                  $"Código: {codigo}\n" +
                                  $"Nombre: {nombre}\n\n" +
                                  $"Este producto será omitido.",
                        "Producto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                int index = dgvProductos.Rows.Add();
                DataGridViewRow row = dgvProductos.Rows[index];

                row.Cells["IdProducto"].Value = idProducto;
                row.Cells["Codigo"].Value = codigo;
                row.Cells["Producto"].Value = nombre;
                row.Cells["PrecioVenta"].Value = detalle.PrecioVenta;
                row.Cells["CantidadOriginal"].Value = detalle.Cantidad;
                row.Cells["CantidadDevolver"].Value = 0;
                row.Cells["DescuentoPorcentaje"].Value = detalle.PorcentajeDescuento;
                row.Cells["SubTotal"].Value = 0;

                productosAgregados++;
            }

            System.Diagnostics.Debug.WriteLine($"CargarProductos: {productosAgregados} productos agregados al grid");
        }

        #endregion

        #region Cálculo de Totales

        private void dgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProductos.Columns[e.ColumnIndex].Name != "CantidadDevolver") return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

            // Validar cantidad a devolver
            int cantidadDevolver = 0;
            if (row.Cells["CantidadDevolver"].Value != null)
            {
                if (!int.TryParse(row.Cells["CantidadDevolver"].Value.ToString(), out cantidadDevolver))
                {
                    MessageBox.Show("La cantidad debe ser un número entero", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["CantidadDevolver"].Value = 0;
                    return;
                }
            }

            int cantidadOriginal = Convert.ToInt32(row.Cells["CantidadOriginal"].Value);

            if (cantidadDevolver < 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells["CantidadDevolver"].Value = 0;
                return;
            }

            if (cantidadDevolver > cantidadOriginal)
            {
                MessageBox.Show($"No puede devolver más de {cantidadOriginal} unidades", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells["CantidadDevolver"].Value = cantidadOriginal;
                cantidadDevolver = cantidadOriginal;
            }

            // Calcular subtotal del ítem
            CalcularSubtotalItem(row);

            // Recalcular totales generales
            CalcularTotales();
        }

        private void CalcularSubtotalItem(DataGridViewRow row)
        {
            int cantidadDevolver = Convert.ToInt32(row.Cells["CantidadDevolver"].Value ?? 0);
            
            if (cantidadDevolver == 0)
            {
                row.Cells["SubTotal"].Value = 0;
                return;
            }

            decimal precio = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
            decimal descPorcentaje = Convert.ToDecimal(row.Cells["DescuentoPorcentaje"].Value ?? 0);

            // Calcular
            decimal subtotalItem = precio * cantidadDevolver;
            decimal importeDescuento = subtotalItem * (descPorcentaje / 100);
            decimal netoItem = subtotalItem - importeDescuento;

            // IVA según tipo de comprobante original
            decimal porcentajeIVA = 0;
            if (_VentaOriginal.oTipoComprobante.DiscriminaIVA)
            {
                porcentajeIVA = 21;
            }

            decimal importeIVA = netoItem * (porcentajeIVA / 100);
            decimal total = netoItem + importeIVA;

            row.Cells["SubTotal"].Value = total;
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal totalDescuento = 0;
            decimal totalIVA = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.IsNewRow) continue;

                int cantidadDevolver = Convert.ToInt32(row.Cells["CantidadDevolver"].Value ?? 0);
                if (cantidadDevolver == 0) continue;

                decimal precio = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
                decimal descPorcentaje = Convert.ToDecimal(row.Cells["DescuentoPorcentaje"].Value ?? 0);

                // Calcular subtotal del ítem
                decimal subtotalItem = precio * cantidadDevolver;
                decimal importeDescuento = subtotalItem * (descPorcentaje / 100);
                decimal netoItem = subtotalItem - importeDescuento;

                // Acumular
                subtotal += subtotalItem;
                totalDescuento += importeDescuento;

                // IVA según tipo de comprobante original
                if (_VentaOriginal.oTipoComprobante.DiscriminaIVA)
                {
                    decimal ivaItem = netoItem * 0.21m;
                    totalIVA += ivaItem;
                }
            }

            decimal neto = subtotal - totalDescuento;
            decimal total = neto + totalIVA;

            // Mostrar como valores NEGATIVOS
            lblSubtotal.Text = $"-${subtotal:N2}";
            lblDescuento.Text = $"-${totalDescuento:N2}";
            lblIVA.Text = $"-${totalIVA:N2}";
            lblTotal.Text = $"-${total:N2}";
        }

        #endregion

        #region Generación de Nota de Crédito

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!ValidarNotaCredito(out string mensaje))
            {
                MessageBox.Show(mensaje, "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Determinar tipo de NC
                int idTipoNC = DeterminarTipoNC(_VentaOriginal.oTipoComprobante.IdTipoComprobante);

                // Obtener próximo número
                int proximoNumero = new CN_Venta().ObtenerProximoNumero(idTipoNC, 1);
                string numeroNC = proximoNumero.ToString("0000000000");

                // Preparar objeto Venta (valores negativos)
                decimal subtotal = ParsearImporte(lblSubtotal.Text);
                decimal descuento = ParsearImporte(lblDescuento.Text);
                decimal iva = ParsearImporte(lblIVA.Text);
                decimal total = ParsearImporte(lblTotal.Text);

                Venta notaCredito = new Venta
                {
                    oUsuario = new Usuario { IdUsuario = 1 }, // TODO: Usuario actual
                    oVentaOriginal = new Venta { IdVenta = _VentaOriginal.IdVenta },
                    oTipoComprobante = new TipoComprobante { IdTipoComprobante = idTipoNC },
                    NumeroDocumento = numeroNC,
                    PuntoVenta = 1,
                    SubTotal = -subtotal,
                    PorcentajeDescuento = 0, // TODO: Calcular si hay descuento general
                    TotalDescuento = -descuento,
                    TotalIVA = -iva,
                    MontoTotal = -total,
                    MontoCambio = 0,
                    Observaciones = txtObservaciones.Text.Trim()
                };

                // Preparar DataTable
                DataTable dtDetalle = PrepararDetalleNC();

                // DEBUG: Validar que el DataTable tenga filas
                if (dtDetalle == null || dtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show($"Error: El detalle de productos está vacío.\\n\\n" +
                                  $"Filas en DataGridView: {dgvProductos.Rows.Count}\\n" +
                                  $"Filas en DataTable: {dtDetalle?.Rows.Count ?? 0}\\n\\n" +
                                  $"Verifique que haya ingresado cantidades a devolver.",
                        "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar
                int idNC = 0;
                bool resultado = new CN_Venta().RegistrarNotaCredito(
                    notaCredito,
                    dtDetalle,
                    out idNC,
                    out mensaje
                );

                if (resultado)
                {
                    MessageBox.Show($"Nota de Crédito generada correctamente\n\n" +
                                  $"ID NC: {idNC}\n" +
                                  $"Venta Original: {_VentaOriginal.NumeroDocumento}\n" +
                                  $"Total NC: ${CalcularTotalNC():N2}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Generar PDF de la Nota de Crédito
                    try
                    {
                        // Preguntar si desea generar PDF
                        DialogResult respuesta = MessageBox.Show(
                            "¿Desea generar el comprobante de Nota de Crédito en PDF?",
                            "Generar Comprobante NC",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (respuesta == DialogResult.Yes)
                        {
                            // Crear objeto Venta para la NC con los datos actuales
                            Venta ncParaPDF = new Venta
                            {
                                IdVenta = idNC,
                                NumeroDocumento = numeroNC,
                              //  oTipoComprobante = _TipoNCSeleccionado,
                                FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy"),
                                NombreCliente = _VentaOriginal.NombreCliente,
                                DocumentoCliente = _VentaOriginal.DocumentoCliente,
                                oCliente = _VentaOriginal.oCliente,
                                SubTotal = Math.Abs(notaCredito.SubTotal),
                                TotalIVA = Math.Abs(notaCredito.TotalIVA),
                                TotalDescuento = Math.Abs(notaCredito.TotalDescuento),
                                MontoTotal = Math.Abs(notaCredito.MontoTotal),
                                oDetalle_Venta = ObtenerDetalleNCParaPDF()
                            };

                            //var generador = new Reportes.GeneradorComprobantesFiscales();
                            string rutaPDF = "";//generador.GuardarYAbrir(ncParaPDF);
                            
                            MessageBox.Show($"Comprobante de NC generado:\n{rutaPDF}", 
                                "PDF Generado", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exPDF)
                    {
                        MessageBox.Show($"La NC se guardó correctamente, pero hubo un error al generar el PDF:\n{exPDF.Message}",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show($"Error al generar la Nota de Crédito:\n{mensaje}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la Nota de Crédito:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal ParsearImporte(string texto)
        {
            // Remover solo $, mantener signo , .
            string valor = texto.Replace("$", "").Trim();
            if (decimal.TryParse(valor, out decimal resultado))
            {
                return resultado;
            }
            return 0;
        }
        private bool ValidarNotaCredito(out string mensaje)
        {
            mensaje = string.Empty;

            // Validar que haya venta original cargada
            if (_VentaOriginal == null || _VentaOriginal.IdVenta == 0)
            {
                mensaje = "Debe buscar una venta original primero";
                return false;
            }

            // Validar que haya al menos un producto con cantidad > 0
            bool hayProductos = false;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.IsNewRow) continue;
                int cantidadDevolver = Convert.ToInt32(row.Cells["CantidadDevolver"].Value ?? 0);
                if (cantidadDevolver > 0)
                {
                    hayProductos = true;
                    break;
                }
            }

            if (!hayProductos)
            {
                mensaje = "Debe seleccionar al menos un producto para devolver";
                return false;
            }

            // Validar observaciones (máximo 500 caracteres)
            if (txtObservaciones.Text.Length > 500)
            {
                mensaje = "Las observaciones no pueden superar los 500 caracteres";
                return false;
            }

            return true;
        }

        private int DeterminarTipoNC(int idTipoOriginal)
        {
            // Factura A (1) → NC A (4)
            // Factura B (2) → NC B (5)
            // Remito (3) → NC B (5)
            return idTipoOriginal == 1 ? 4 : 5;
        }

        private DataTable PrepararDetalleNC()
        {
            DataTable dt = new DataTable();
            
            // IMPORTANTE: El orden y tipo de columnas DEBE coincidir EXACTAMENTE con EDetalle_VentaFiscal
            dt.Columns.Add("IdProducto", typeof(int));
            dt.Columns.Add("PrecioCosto", typeof(decimal));
            dt.Columns.Add("PrecioVenta", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));  // ✅ INT, no decimal
            dt.Columns.Add("PorcentajeIVA", typeof(decimal));
            dt.Columns.Add("ImporteIVA", typeof(decimal));
            dt.Columns.Add("PorcentajeDescuento", typeof(decimal));
            dt.Columns.Add("ImporteDescuento", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));
            dt.Columns.Add("IdListaPrecio", typeof(int));
            dt.Columns.Add("Observaciones", typeof(string));

            int rowsProcessed = 0;
            int rowsAdded = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.IsNewRow) continue;
                rowsProcessed++;

                // DEBUG: Verificar valores de las celdas
                var cantidadCell = row.Cells["CantidadDevolver"].Value;
                int cantidadDevolver = Convert.ToInt32(cantidadCell ?? 0);
                
                if (cantidadDevolver == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Fila {rowsProcessed}: CantidadDevolver = 0, saltando...");
                    continue;
                }

                // Validar y obtener IdProducto
                var idProductoCell = row.Cells["IdProducto"].Value;
                if (idProductoCell == null || idProductoCell == DBNull.Value)
                {
                    MessageBox.Show($"Error: El producto en la fila {rowsProcessed} no tiene IdProducto válido.",
                        "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                int idProducto = Convert.ToInt32(idProductoCell);
                
                if (idProducto <= 0)
                {
                    MessageBox.Show($"Error: El IdProducto en la fila {rowsProcessed} es inválido: {idProducto}",
                        "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                decimal precio = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
                decimal descPorcentaje = Convert.ToDecimal(row.Cells["DescuentoPorcentaje"].Value ?? 0);

                // Calcular importes (NEGATIVOS para NC)
                decimal subtotalItem = precio * cantidadDevolver;
                decimal importeDescuento = subtotalItem * (descPorcentaje / 100);
                decimal netoItem = subtotalItem - importeDescuento;

                decimal porcentajeIVA = _VentaOriginal.oTipoComprobante.DiscriminaIVA ? 21 : 0;
                decimal importeIVA = netoItem * (porcentajeIVA / 100);

                // DEBUG: Log detallado
                System.Diagnostics.Debug.WriteLine($"Agregando producto: IdProducto={idProducto}, Precio={precio}, Cantidad={cantidadDevolver}");

                // Agregar fila con valores NEGATIVOS
                dt.Rows.Add(
                    idProducto,                    // IdProducto (int)
                    0m,                            // PrecioCosto (decimal)
                    -precio,                       // PrecioVenta (decimal, negativo)
                    -cantidadDevolver,             // Cantidad (int, negativo)
                    porcentajeIVA,                 // PorcentajeIVA (decimal)
                    -importeIVA,                   // ImporteIVA (decimal, negativo)
                    descPorcentaje,                // PorcentajeDescuento (decimal)
                    -importeDescuento,             // ImporteDescuento (decimal, negativo)
                    -netoItem,                     // SubTotal (decimal, negativo, sin IVA)
                    1,                             // IdListaPrecio (int)
                    DBNull.Value                   // Observaciones (string)
                );
                
                rowsAdded++;
                System.Diagnostics.Debug.WriteLine($"Fila {rowsProcessed}: Producto {idProducto}, Cantidad {cantidadDevolver}, agregada correctamente");
            }

            System.Diagnostics.Debug.WriteLine($"PrepararDetalleNC: Procesadas={rowsProcessed}, Agregadas={rowsAdded}");
            return dt;
        }

        #endregion

        #region Utilidades

        private void HabilitarControles(bool habilitar)
        {
            dgvProductos.Enabled = habilitar;
            txtObservaciones.Enabled = habilitar;
            btnGenerar.Enabled = habilitar;
        }

        private void LimpiarFormulario()
        {
            _VentaOriginal = null;

            txtNumeroDocumento.Clear();
            lblTipoOriginal.Text = "-";
            lblFechaOriginal.Text = "-";
            lblClienteOriginal.Text = "-";
            lblTotalOriginal.Text = "$0.00";

            dgvProductos.Rows.Clear();
            txtObservaciones.Clear();

            lblSubtotal.Text = "$0.00";
            lblDescuento.Text = "$0.00";
            lblIVA.Text = "$0.00";
            lblTotal.Text = "$0.00";


            HabilitarControles(false);
            txtNumeroDocumento.Focus();
        }

        private decimal CalcularTotalNC()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.IsNewRow) continue;
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value ?? 0);
            }
            return Math.Abs(total);
        }

        private List<Detalle_Venta> ObtenerDetalleNCParaPDF()
        {
            var lista = new List<Detalle_Venta>();
            
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.IsNewRow) continue;
                
                int cantidadDevolver = Convert.ToInt32(row.Cells["CantidadDevolver"].Value ?? 0);
                if (cantidadDevolver <= 0) continue;

                var detalle = new Detalle_Venta
                {
                    oProducto = new Producto
                    {
                        IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        Codigo = row.Cells["Codigo"].Value?.ToString() ?? "",
                        Nombre = row.Cells["Producto"].Value?.ToString() ?? ""
                    },
                    PrecioVenta = Math.Abs(Convert.ToDecimal(row.Cells["PrecioVenta"].Value ?? 0)),
                    Cantidad = cantidadDevolver,
                    PorcentajeDescuento = Convert.ToDecimal(row.Cells["DescuentoPorcentaje"].Value ?? 0)
                };

                lista.Add(detalle);
            }

            return lista;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        #endregion
    }
}
