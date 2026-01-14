using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {

            dgvCategoria.DefaultCellStyle.Font =
           new Font("Segoe UI", 10);

            dgvCategoria.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvCategoria.EnableHeadersVisualStyles = false;

            dgvCategoria.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            cmbEstadoC.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstadoC.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cmbEstadoC.DisplayMember = "Texto";
            cmbEstadoC.ValueMember = "Valor";
            cmbEstadoC.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvCategoria.Columns)
            {

                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cmbBuscarc.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbBuscarc.DisplayMember = "Texto";
            cmbBuscarc.ValueMember = "Valor";
            cmbBuscarc.SelectedIndex = 0;



            //MOSTRAR TODOS LOS USUARIOS
            List<Categoria> lista = new CN_Categoria().Listar();

            foreach (Categoria item in lista)
            {

                dgvCategoria.Rows.Add(new object[] {"",item.IdCategoria,
                    item.Descripcion,                    
                    item.Estado == true ? "Activo" : "No Activo",
                    item.Estado == true ? 1 : 0 
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

           


        }


        private void Limpiar()
        {

            txtIndicec.Text = "-1";
            txtid.Text = "0";
            txtcategorias.Text = "";
            cmbEstadoC.SelectedIndex = 0;
            txtNombrec.Text = "";
            txtcategorias.Select();
        }

        private void dgvCategoria_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

        }


        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.Columns[e.ColumnIndex].Name == "btnseleccionarc")
            {

                int indice = e.RowIndex;

                if (indice >= 0)
                {

                    txtIndicec.Text = indice.ToString();
                    txtIdC.Text = dgvCategoria.Rows[indice].Cells["IdCategoria"].Value.ToString();
                    txtcategorias.Text = dgvCategoria.Rows[indice].Cells["CategoriaD"].Value.ToString();

                    foreach (OpcionCombo oc in cmbEstadoC.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvCategoria.Rows[indice].Cells["EstadoValorC"].Value))
                        {
                            int indice_combo = cmbEstadoC.Items.IndexOf(oc);
                            cmbEstadoC.SelectedIndex = indice_combo;
                            break;
                        }
                    }


                }


            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar la categoria", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Categoria obj = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Categoria().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvCategoria.Rows.RemoveAt(Convert.ToInt32(txtIndicec.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBuscarc.SelectedItem).Valor.ToString();

            if (dgvCategoria.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvCategoria.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardarc_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtIdC.Text),
                Descripcion = txtcategorias.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstadoC.SelectedItem).Valor) == 1 ? true : false

            };

            if (obj.IdCategoria == 0)
            {
                int idgenerado = new CN_Categoria().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {

                    dgvCategoria.Rows.Add(new object[] {"",idgenerado,txtcategorias.Text,
                        ((OpcionCombo)cmbEstadoC.SelectedItem).Valor.ToString()

                    });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }


            }
            else
            {
                bool resultado = new CN_Categoria().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvCategoria.Rows[Convert.ToInt32(txtIndicec.Text)];
                    row.Cells["IdCategoria"].Value = txtIdC.Text;
                    row.Cells["CategoriaD"].Value = txtcategorias.Text;
                    row.Cells["EstadoValorC"].Value = ((OpcionCombo)cmbEstadoC.SelectedItem).Valor.ToString();
                    row.Cells["EstadoC"].Value = ((OpcionCombo)cmbEstadoC.SelectedItem).Texto.ToString();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void btnbuscarc_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBuscarc.SelectedItem).Valor.ToString();

            if (dgvCategoria.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCategoria.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtNombrec.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscadorC_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
