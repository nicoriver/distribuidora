using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades; // Suponiendo OpcionCombo está aquí
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdPreciosLista : Form
    {
        private int _idProducto;
        private string _nombreProducto;
        private decimal _costo;
        private CN_Lista _cnLista = new CN_Lista();
        
        public mdPreciosLista(int idProducto, string nombre, decimal costo)
        {
            InitializeComponent();
            _idProducto = idProducto;
            _nombreProducto = nombre;
            _costo = costo;
        }

        private void mdPreciosLista_Load(object sender, EventArgs e)
        {
            lblNombreProducto.Text = _nombreProducto;
            txtCosto.Text = _costo.ToString("0.00");
            
            // Cargar valores de IVA desde la base de datos
            List<Iva> listaIva = new CN_Iva().Listar();
            foreach (Iva item in listaIva)
            {
                cboIva.Items.Add(new OpcionCombo() { Valor = item.id_IVA, Texto = item.Valor.ToString("0.00") });
            }
            cboIva.DisplayMember = "Texto";
            cboIva.ValueMember = "Valor";
            if (cboIva.Items.Count > 0)
                cboIva.SelectedIndex = 0;
            
            // Cargar tipos de lista (Simulado si no hay tabla)
            cboTipoLista.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Mayorista" });
            cboTipoLista.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Minorista" });
            cboTipoLista.Items.Add(new OpcionCombo() { Valor = 3, Texto = "Promoción" });
            cboTipoLista.DisplayMember = "Texto";
            cboTipoLista.ValueMember = "Valor";
            cboTipoLista.SelectedIndex = 0;

            // Registrar evento para eliminar
            dgvPrecios.CellClick += dgvPrecios_CellClick;

            CargarPrecios();
        }

        private void CargarPrecios()
        {
            List<Lista> lista = _cnLista.Listar(_idProducto);
            
            // Crear una lista con el nombre del tipo de lista en lugar del ID
            var listaConNombres = lista.Select(l => new
            {
                l.Id_Lista,
                l.Id_articulo,
                l.Descripcion,
                TipoLista = ObtenerNombreTipoLista(l.id_Tipolistas),
                l.Importe,
                l.Fecha_Modificacion,
                l.Iva,
                l.Recargo,
                l.Descuento
            }).ToList();
            
            dgvPrecios.DataSource = listaConNombres;
            
            // Ocultar columnas innecesarias
            if(dgvPrecios.Columns["Id_articulo"] != null) dgvPrecios.Columns["Id_articulo"].Visible = false;
            if(dgvPrecios.Columns["oProducto"] != null) dgvPrecios.Columns["oProducto"].Visible = false;
        }
        
        private string ObtenerNombreTipoLista(int idTipo)
        {
            switch(idTipo)
            {
                case 1: return "Mayorista";
                case 2: return "Minorista";
                case 3: return "Promoción";
                default: return "Desconocido";
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            decimal recargo = 0;
            decimal iva = 0;
            decimal descuento = 0;

            decimal.TryParse(txtRecargo.Text, out recargo);
            
            // Obtener IVA del ComboBox seleccionado
            if (cboIva.SelectedItem != null)
            {
                decimal.TryParse(((OpcionCombo)cboIva.SelectedItem).Texto, out iva);
            }
            
            decimal.TryParse(txtDescuento.Text, out descuento);

            decimal precioFinal = _cnLista.CalcularPrecioVenta(_costo, recargo, iva, descuento);
            lblPrecioFinal.Text = precioFinal.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             if (cboTipoLista.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Calcular(); // Asegurar cálculo actualizado
            
            int tipoListaSeleccionado = Convert.ToInt32(((OpcionCombo)cboTipoLista.SelectedItem).Valor);
            
            // Validar que no exista ya una lista con el mismo tipo para este producto
            List<Lista> listasExistentes = _cnLista.Listar(_idProducto);
            if (listasExistentes.Any(l => l.id_Tipolistas == tipoListaSeleccionado))
            {
                MessageBox.Show("Ya existe una lista de tipo " + ObtenerNombreTipoLista(tipoListaSeleccionado) + " para este producto.", 
                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lista obj = new Lista()
            {
                Id_articulo = _idProducto,
                Descripcion = txtDescripcion.Text,
                id_Tipolistas = tipoListaSeleccionado,
                Importe = Convert.ToDecimal(lblPrecioFinal.Text),
                Iva = cboIva.SelectedItem != null ? Convert.ToDecimal(((OpcionCombo)cboIva.SelectedItem).Texto) : 0,
                Recargo = Convert.ToDecimal(txtRecargo.Text),
                Descuento = Convert.ToDecimal(txtDescuento.Text)
            };

            string mensaje = string.Empty;
            int resultado = _cnLista.Registrar(obj, out mensaje);

            if (resultado != 0)
            {
                MessageBox.Show("Precio guardado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPrecios();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrecios.Columns[e.ColumnIndex].Name == "btnEliminar" && e.RowIndex >= 0)
            {
                if (MessageBox.Show("¿Desea eliminar este precio de lista?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idLista = Convert.ToInt32(dgvPrecios.Rows[e.RowIndex].Cells["Id_Lista"].Value);
                    string mensaje = string.Empty;

                    bool resultado = _cnLista.Eliminar(idLista, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show("Precio eliminado correctamente", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPrecios();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
