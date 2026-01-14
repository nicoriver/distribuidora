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
    public partial class frmClientes : Form
    {
        private List<Cliente> listaClientes; // Lista para mantener los objetos completos en memoria

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            // Estado
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // Tipo DNI - Valores precargados
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 1, Texto = "DNI" });
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 2, Texto = "CUIT" });
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 3, Texto = "Libreta Civil" });
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 4, Texto = "Libreta Enrolamiento" });
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 5, Texto = "Cédula" });
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 6, Texto = "Pasaporte" });
            cboTipoDni.Items.Add(new OpcionCombo() { Valor = 7, Texto = "Otros" });
            cboTipoDni.DisplayMember = "Texto";
            cboTipoDni.ValueMember = "Valor";
            cboTipoDni.SelectedIndex = 0;

            // Tipo IVA - Valores precargados
            cboTipoIVA.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Consumidor Final" });
            cboTipoIVA.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Responsable Inscripto" });
            cboTipoIVA.Items.Add(new OpcionCombo() { Valor = 3, Texto = "Responsable Monotributo" });
            cboTipoIVA.Items.Add(new OpcionCombo() { Valor = 4, Texto = "No Categorizado" });
            cboTipoIVA.DisplayMember = "Texto";
            cboTipoIVA.ValueMember = "Valor";
            cboTipoIVA.SelectedIndex = 0;

            // Provincia - Desde BD
            List<Provincia> listaProvincias = new CN_Provincia().Listar();
            cboProvincia.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Seleccione..." });
            foreach (Provincia item in listaProvincias)
            {
                cboProvincia.Items.Add(new OpcionCombo() { Valor = item.IdProvincia, Texto = item.Nombre });
            }
            cboProvincia.DisplayMember = "Texto";
            cboProvincia.ValueMember = "Valor";
            cboProvincia.SelectedIndex = 0;

            // Localidad - Se cargará al seleccionar provincia
            cboLocalidad.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Seleccione provincia primero..." });
            cboLocalidad.DisplayMember = "Texto";
            cboLocalidad.ValueMember = "Valor";
            cboLocalidad.SelectedIndex = 0;

            // Zona - Desde BD
            List<Zona> listaZonas = new CN_Zona().Listar();
            cboZona.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Seleccione..." });
            foreach (Zona item in listaZonas)
            {
                cboZona.Items.Add(new OpcionCombo() { Valor = item.IdZona, Texto = item.Nombre });
            }
            cboZona.DisplayMember = "Texto";
            cboZona.ValueMember = "Valor";
            cboZona.SelectedIndex = 0;

            // Búsqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvdata.Rows.Clear();
            listaClientes = new CN_Cliente().Listar();

            foreach (Cliente item in listaClientes)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdCliente,item.Dni,item.Apellido + " " + item.Nombre,item.Email,item.Telefono,
                    item.Estado == true ? 1 : 0 ,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Obtener valores de ComboBox
            int idTipoDni = Convert.ToInt32(((OpcionCombo)cboTipoDni.SelectedItem).Valor);
            int idCodigoIva = Convert.ToInt32(((OpcionCombo)cboTipoIVA.SelectedItem).Valor);
            int idProvincia = Convert.ToInt32(((OpcionCombo)cboProvincia.SelectedItem).Valor);
            int idLocalidad = Convert.ToInt32(((OpcionCombo)cboLocalidad.SelectedItem).Valor);
            int idZona = Convert.ToInt32(((OpcionCombo)cboZona.SelectedItem).Valor);
            
            // Validaciones básicas de tipo de dato para evitar errores de conversión
            if (!int.TryParse(txtIdVendedor.Text, out int idVendedor)) idVendedor = 0;
            if (!decimal.TryParse(txtLatitud.Text, out decimal latitud)) latitud = 0;
            if (!decimal.TryParse(txtLongitud.Text, out decimal longitud)) longitud = 0;

            Cliente obj = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtid.Text),
                Dni = txtDni.Text,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                RazonSocial = txtRazonSocial.Text,
                Cuit = txtCuit.Text,
                IdTipoDni = idTipoDni,
                IdCodigoIva = idCodigoIva,
                
                Domicilio = txtDomicilio.Text,
                IdProvincia = idProvincia,
                IdLocalidad = idLocalidad,
                IdZona = idZona,
                IdPais = 0, // Campo eliminado del formulario
                Latitud = latitud,
                Longitud = longitud,

                Telefono = txtTelefono.Text,
                TelefonoAlt = txtTelefonoAlt.Text,
                Fax = txtFax.Text,
                Email = txtEmail.Text,
                Web = txtWeb.Text,
                Contacto = txtContacto.Text,
                IdVendedor = idVendedor,

                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdCliente == 0)
            {
                int idgenerado = new CN_Cliente().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    MessageBox.Show("Cliente registrado exitosamente");
                    Limpiar();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Cliente().Editar(obj, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Cliente actualizado exitosamente");
                    Limpiar();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            
            // General
            txtDni.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtRazonSocial.Text = "";
            txtCuit.Text = "";
            cboTipoDni.SelectedIndex = 0;
            cboTipoIVA.SelectedIndex = 0;

            // Ubicacion
            txtDomicilio.Text = "";
            cboProvincia.SelectedIndex = 0;
            cboLocalidad.SelectedIndex = 0;
            cboZona.SelectedIndex = 0;
            txtLatitud.Text = "0";
            txtLongitud.Text = "0";

            // Contacto
            txtTelefono.Text = "";
            txtTelefonoAlt.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtWeb.Text = "";
            txtContacto.Text = "";
            txtIdVendedor.Text = "0";

            cboestado.SelectedIndex = 0;
            tabControl1.SelectedIndex = 0;
            txtDni.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    int idSeleccionado = Convert.ToInt32(dgvdata.Rows[indice].Cells["Id"].Value);
                    
                    // Buscar el objeto completo en la lista
                    Cliente clienteSeleccionado = listaClientes.FirstOrDefault(c => c.IdCliente == idSeleccionado);

                    if (clienteSeleccionado != null)
                    {
                        txtid.Text = clienteSeleccionado.IdCliente.ToString();
                        
                        // General
                        txtDni.Text = clienteSeleccionado.Dni;
                        txtApellido.Text = clienteSeleccionado.Apellido;
                        txtNombre.Text = clienteSeleccionado.Nombre;
                        txtRazonSocial.Text = clienteSeleccionado.RazonSocial;
                        txtCuit.Text = clienteSeleccionado.Cuit;
                        
                        // Seleccionar Tipo DNI
                        foreach (OpcionCombo oc in cboTipoDni.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == clienteSeleccionado.IdTipoDni)
                            {
                                cboTipoDni.SelectedIndex = cboTipoDni.Items.IndexOf(oc);
                                break;
                            }
                        }

                        // Seleccionar Tipo IVA
                        foreach (OpcionCombo oc in cboTipoIVA.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == clienteSeleccionado.IdCodigoIva)
                            {
                                cboTipoIVA.SelectedIndex = cboTipoIVA.Items.IndexOf(oc);
                                break;
                            }
                        }

                        // Ubicacion
                        txtDomicilio.Text = clienteSeleccionado.Domicilio;
                        
                        // Seleccionar Provincia
                        foreach (OpcionCombo oc in cboProvincia.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == clienteSeleccionado.IdProvincia)
                            {
                                cboProvincia.SelectedIndex = cboProvincia.Items.IndexOf(oc);
                                break;
                            }
                        }

                        // Cargar localidades de la provincia y seleccionar
                        CargarLocalidadesPorProvincia(clienteSeleccionado.IdProvincia);
                        foreach (OpcionCombo oc in cboLocalidad.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == clienteSeleccionado.IdLocalidad)
                            {
                                cboLocalidad.SelectedIndex = cboLocalidad.Items.IndexOf(oc);
                                break;
                            }
                        }

                        // Seleccionar Zona
                        foreach (OpcionCombo oc in cboZona.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == clienteSeleccionado.IdZona)
                            {
                                cboZona.SelectedIndex = cboZona.Items.IndexOf(oc);
                                break;
                            }
                        }
                        txtLatitud.Text = clienteSeleccionado.Latitud.ToString();
                        txtLongitud.Text = clienteSeleccionado.Longitud.ToString();

                        // Contacto
                        txtTelefono.Text = clienteSeleccionado.Telefono;
                        txtTelefonoAlt.Text = clienteSeleccionado.TelefonoAlt;
                        txtFax.Text = clienteSeleccionado.Fax;
                        txtEmail.Text = clienteSeleccionado.Email;
                        txtWeb.Text = clienteSeleccionado.Web;
                        txtContacto.Text = clienteSeleccionado.Contacto;
                        txtIdVendedor.Text = clienteSeleccionado.IdVendedor.ToString();

                        // Estado
                        foreach (OpcionCombo oc in cboestado.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == (clienteSeleccionado.Estado ? 1 : 0))
                            {
                                int indice_combo = cboestado.Items.IndexOf(oc);
                                cboestado.SelectedIndex = indice_combo;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente obj = new Cliente()
                    {
                        IdCliente = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Cliente().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        Limpiar();
                        CargarUsuarios();
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
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
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
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void CargarLocalidadesPorProvincia(int idProvincia)
        {
            cboLocalidad.Items.Clear();
            cboLocalidad.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Seleccione..." });
            
            if (idProvincia > 0)
            {
                List<Localidad> listaLocalidades = new CN_Localidad().ListarPorProvincia(idProvincia);
                foreach (Localidad item in listaLocalidades)
                {
                    cboLocalidad.Items.Add(new OpcionCombo() { Valor = item.IdLocalidad, Texto = item.Nombre });
                }
            }
            
            cboLocalidad.SelectedIndex = 0;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex > 0)
            {
                int idProvincia = Convert.ToInt32(((OpcionCombo)cboProvincia.SelectedItem).Valor);
                CargarLocalidadesPorProvincia(idProvincia);
            }
            else
            {
                cboLocalidad.Items.Clear();
                cboLocalidad.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Seleccione provincia primero..." });
                cboLocalidad.SelectedIndex = 0;
            }
        }
    }
}
