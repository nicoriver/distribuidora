using System;
using System.Drawing;
using System.Windows.Forms;
using CapaPresentacion.Net8.Base;

namespace CapaPresentacion.Net8
{
    public partial class Inicio : FormularioBase
    {
        public Inicio()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Sistema de Ventas - JC Distribuciones";
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            this.BackColor = Color.FromArgb(240, 240, 240);

            CrearMenu();
            CrearBarraEstado();
        }

        private void CrearMenu()
        {
            var menuStrip = new MenuStrip
            {
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F)
            };

            var menuVentas = new ToolStripMenuItem("Ventas");
            menuVentas.DropDownItems.Add("Nueva Venta", null, (s, e) => AbrirFormulario(new frmVentasFiscales()));
            menuVentas.DropDownItems.Add("Devoluciones", null, (s, e) => AbrirFormulario(new frmDevoluciones()));

            var menuMaestros = new ToolStripMenuItem("Maestros");
            menuMaestros.DropDownItems.Add("Clientes", null, (s, e) => AbrirFormulario(new frmClientes()));
            menuMaestros.DropDownItems.Add("Productos", null, (s, e) => AbrirFormulario(new frmProducto()));
            menuMaestros.DropDownItems.Add("Proveedores", null, (s, e) => MessageBox.Show("Próximamente: frmProveedores"));

            var menuReportes = new ToolStripMenuItem("Reportes");
            menuReportes.DropDownItems.Add("Ventas", null, (s, e) => AbrirFormulario(new frmReporteVentas()));

            var menuSalir = new ToolStripMenuItem("Salir");
            menuSalir.Click += (s, e) => this.Close();

            menuStrip.Items.Add(menuVentas);
            menuStrip.Items.Add(menuMaestros);
            menuStrip.Items.Add(menuReportes);
            menuStrip.Items.Add(menuSalir);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void CrearBarraEstado()
        {
            var statusStrip = new StatusStrip();
            var lblEstado = new ToolStripStatusLabel("Listo");
            var lblUsuario = new ToolStripStatusLabel("Usuario: Admin");
            var lblFecha = new ToolStripStatusLabel(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            statusStrip.Items.Add(lblEstado);
            statusStrip.Items.Add(new ToolStripStatusLabel { Spring = true });
            statusStrip.Items.Add(lblUsuario);
            statusStrip.Items.Add(lblFecha);

            this.Controls.Add(statusStrip);
        }

        private void AbrirFormulario(Form formulario)
        {
            // Cerrar formularios hijos abiertos
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            // Configurar y mostrar el nuevo formulario
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            SuspendLayout();
            // 
            // Inicio
            // 
            resources.ApplyResources(this, "$this");
            Name = "Inicio";
            Load += Inicio_Load;
            ResumeLayout(false);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
