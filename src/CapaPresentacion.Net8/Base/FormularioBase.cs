using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Net8.Base
{
    public class FormularioBase : Form
    {
        public FormularioBase()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Font = new Font("Segoe UI", 9F);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 600);
        }

        protected TableLayoutPanel CrearLayout(int filas, int columnas)
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = filas,
                ColumnCount = columnas,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            return layout;
        }

        protected void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected bool SolicitarConfirmacion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
