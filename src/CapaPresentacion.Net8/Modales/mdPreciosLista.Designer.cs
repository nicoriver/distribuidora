namespace CapaPresentacion.Net8.Modales
{
    partial class mdPreciosLista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.txtRecargo = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.cboIva = new System.Windows.Forms.ComboBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblPrecioFinalLabel = new System.Windows.Forms.Label();
            this.lblPrecioFinal = new System.Windows.Forms.Label();
            this.lblTipoLista = new System.Windows.Forms.Label();
            this.cboTipoLista = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblPreciosGuardados = new System.Windows.Forms.Label();
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            this.SuspendLayout();
            
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Listas de Precios";
            
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombreProducto.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNombreProducto.Location = new System.Drawing.Point(20, 50);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(100, 19);
            this.lblNombreProducto.TabIndex = 1;
            this.lblNombreProducto.Text = "Producto";
            
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(20, 85);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(37, 13);
            this.lblCosto.TabIndex = 2;
            this.lblCosto.Text = "Costo:";
            
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(20, 101);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 3;
            this.txtCosto.BackColor = System.Drawing.Color.LightGray;
            
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(20, 130);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(63, 13);
            this.lblRecargo.TabIndex = 4;
            this.lblRecargo.Text = "Recargo %:";
            
            // 
            // txtRecargo
            // 
            this.txtRecargo.Location = new System.Drawing.Point(20, 146);
            this.txtRecargo.Name = "txtRecargo";
            this.txtRecargo.Size = new System.Drawing.Size(100, 20);
            this.txtRecargo.TabIndex = 5;
            this.txtRecargo.Text = "0";
            
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(140, 130);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(31, 13);
            this.lblIva.TabIndex = 6;
            this.lblIva.Text = "IVA:";
            
            // 
            // cboIva
            // 
            this.cboIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIva.FormattingEnabled = true;
            this.cboIva.Location = new System.Drawing.Point(140, 146);
            this.cboIva.Name = "cboIva";
            this.cboIva.Size = new System.Drawing.Size(100, 21);
            this.cboIva.TabIndex = 7;
            
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(260, 130);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(76, 13);
            this.lblDescuento.TabIndex = 8;
            this.lblDescuento.Text = "Descuento %:";
            
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(260, 146);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 9;
            this.txtDescuento.Text = "0";
            
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(380, 144);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(80, 24);
            this.btnCalcular.TabIndex = 10;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            
            // 
            // lblPrecioFinalLabel
            // 
            this.lblPrecioFinalLabel.AutoSize = true;
            this.lblPrecioFinalLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecioFinalLabel.Location = new System.Drawing.Point(20, 180);
            this.lblPrecioFinalLabel.Name = "lblPrecioFinalLabel";
            this.lblPrecioFinalLabel.Size = new System.Drawing.Size(90, 19);
            this.lblPrecioFinalLabel.TabIndex = 11;
            this.lblPrecioFinalLabel.Text = "Precio Final:";
            
            // 
            // lblPrecioFinal
            // 
            this.lblPrecioFinal.AutoSize = true;
            this.lblPrecioFinal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPrecioFinal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPrecioFinal.Location = new System.Drawing.Point(120, 176);
            this.lblPrecioFinal.Name = "lblPrecioFinal";
            this.lblPrecioFinal.Size = new System.Drawing.Size(50, 25);
            this.lblPrecioFinal.TabIndex = 12;
            this.lblPrecioFinal.Text = "0.00";
            
            // 
            // lblTipoLista
            // 
            this.lblTipoLista.AutoSize = true;
            this.lblTipoLista.Location = new System.Drawing.Point(20, 220);
            this.lblTipoLista.Name = "lblTipoLista";
            this.lblTipoLista.Size = new System.Drawing.Size(58, 13);
            this.lblTipoLista.TabIndex = 13;
            this.lblTipoLista.Text = "Tipo Lista:";
            
            // 
            // cboTipoLista
            // 
            this.cboTipoLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoLista.FormattingEnabled = true;
            this.cboTipoLista.Location = new System.Drawing.Point(20, 236);
            this.cboTipoLista.Name = "cboTipoLista";
            this.cboTipoLista.Size = new System.Drawing.Size(150, 21);
            this.cboTipoLista.TabIndex = 14;
            
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(190, 220);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción:";
            
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(190, 236);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 16;
            
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(410, 234);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 24);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            
            // 
            // lblPreciosGuardados
            // 
            this.lblPreciosGuardados.AutoSize = true;
            this.lblPreciosGuardados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreciosGuardados.Location = new System.Drawing.Point(20, 275);
            this.lblPreciosGuardados.Name = "lblPreciosGuardados";
            this.lblPreciosGuardados.Size = new System.Drawing.Size(140, 19);
            this.lblPreciosGuardados.TabIndex = 18;
            this.lblPreciosGuardados.Text = "Precios Guardados";
            
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnEliminar});
            this.dgvPrecios.Location = new System.Drawing.Point(20, 300);
            this.dgvPrecios.MultiSelect = false;
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.ReadOnly = true;
            this.dgvPrecios.Size = new System.Drawing.Size(470, 180);
            this.dgvPrecios.TabIndex = 19;
            
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Text = "";
            this.btnEliminar.UseColumnTextForButtonValue = true;
            this.btnEliminar.Width = 40;
            
            // 
            // mdPreciosLista
            // 
            this.ClientSize = new System.Drawing.Size(520, 500);
            this.Controls.Add(this.dgvPrecios);
            this.Controls.Add(this.lblPreciosGuardados);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.cboTipoLista);
            this.Controls.Add(this.lblTipoLista);
            this.Controls.Add(this.lblPrecioFinal);
            this.Controls.Add(this.lblPrecioFinalLabel);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.cboIva);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.txtRecargo);
            this.Controls.Add(this.lblRecargo);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdPreciosLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listas de Precios";
            this.Load += new System.EventHandler(this.mdPreciosLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.TextBox txtRecargo;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.ComboBox cboIva;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblPrecioFinalLabel;
        private System.Windows.Forms.Label lblPrecioFinal;
        private System.Windows.Forms.Label lblTipoLista;
        private System.Windows.Forms.ComboBox cboTipoLista;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblPreciosGuardados;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
    }
}
