namespace CapaPresentacion.Net8
{
    partial class frmVentasFiscales
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
            lblTipoComprobante = new Label();
            cboTipoComprobante = new ComboBox();
            lblPuntoVenta = new Label();
            cboPuntoVenta = new ComboBox();
            lblNumeroDocumento = new Label();
            txtNumeroDocumento = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblCliente = new Label();
            txtIdCliente = new TextBox();
            btnBuscarCliente = new Button();
            lblNombreCliente = new Label();
            txtNombreCliente = new TextBox();
            lblCondicionIVA = new Label();
            txtCondicionIVA = new TextBox();
            dgvProductos = new DataGridView();
            lblSubtotalLabel = new Label();
            lblSubtotal = new Label();
            lblDescuentoLabel = new Label();
            lblDescuento = new Label();
            lblIVALabel = new Label();
            lblIVA = new Label();
            lblTotalLabel = new Label();
            lblTotal = new Label();
            lblFormaPago = new Label();
            cboFormaPago = new ComboBox();
            lblPagaCon = new Label();
            txtPagaCon = new TextBox();
            lblCambio = new Label();
            txtCambio = new TextBox();
            btnGuardarVenta = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // lblTipoComprobante
            // 
            lblTipoComprobante.AutoSize = true;
            lblTipoComprobante.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoComprobante.Location = new Point(20, 20);
            lblTipoComprobante.Name = "lblTipoComprobante";
            lblTipoComprobante.Size = new Size(144, 20);
            lblTipoComprobante.TabIndex = 0;
            lblTipoComprobante.Text = "Tipo Comprobante:";
            // 
            // cboTipoComprobante
            // 
            cboTipoComprobante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoComprobante.FormattingEnabled = true;
            cboTipoComprobante.Location = new Point(20, 38);
            cboTipoComprobante.Name = "cboTipoComprobante";
            cboTipoComprobante.Size = new Size(200, 28);
            cboTipoComprobante.TabIndex = 1;
            cboTipoComprobante.SelectedIndexChanged += cboTipoComprobante_SelectedIndexChanged;
            // 
            // lblPuntoVenta
            // 
            lblPuntoVenta.AutoSize = true;
            lblPuntoVenta.Location = new Point(240, 20);
            lblPuntoVenta.Name = "lblPuntoVenta";
            lblPuntoVenta.Size = new Size(91, 20);
            lblPuntoVenta.TabIndex = 2;
            lblPuntoVenta.Text = "Punto Venta:";
            // 
            // cboPuntoVenta
            // 
            cboPuntoVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPuntoVenta.FormattingEnabled = true;
            cboPuntoVenta.Location = new Point(240, 38);
            cboPuntoVenta.Name = "cboPuntoVenta";
            cboPuntoVenta.Size = new Size(100, 28);
            cboPuntoVenta.TabIndex = 3;
            cboPuntoVenta.SelectedIndexChanged += cboPuntoVenta_SelectedIndexChanged;
            // 
            // lblNumeroDocumento
            // 
            lblNumeroDocumento.AutoSize = true;
            lblNumeroDocumento.Location = new Point(360, 20);
            lblNumeroDocumento.Name = "lblNumeroDocumento";
            lblNumeroDocumento.Size = new Size(66, 20);
            lblNumeroDocumento.TabIndex = 4;
            lblNumeroDocumento.Text = "Número:";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.BackColor = Color.LightGray;
            txtNumeroDocumento.Location = new Point(360, 38);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.ReadOnly = true;
            txtNumeroDocumento.Size = new Size(150, 27);
            txtNumeroDocumento.TabIndex = 5;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(530, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 6;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(530, 38);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 27);
            dtpFecha.TabIndex = 7;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCliente.Location = new Point(20, 75);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(81, 20);
            lblCliente.TabIndex = 8;
            lblCliente.Text = "ID Cliente:";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(20, 93);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.Size = new Size(100, 27);
            txtIdCliente.TabIndex = 9;
            txtIdCliente.KeyDown += txtIdCliente_KeyDown;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(130, 92);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(75, 25);
            btnBuscarCliente.TabIndex = 10;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(220, 75);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(67, 20);
            lblNombreCliente.TabIndex = 11;
            lblNombreCliente.Text = "Nombre:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.BackColor = Color.LightGray;
            txtNombreCliente.Location = new Point(220, 93);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(300, 27);
            txtNombreCliente.TabIndex = 12;
            // 
            // lblCondicionIVA
            // 
            lblCondicionIVA.AutoSize = true;
            lblCondicionIVA.Location = new Point(540, 75);
            lblCondicionIVA.Name = "lblCondicionIVA";
            lblCondicionIVA.Size = new Size(105, 20);
            lblCondicionIVA.TabIndex = 13;
            lblCondicionIVA.Text = "Condición IVA:";
            // 
            // txtCondicionIVA
            // 
            txtCondicionIVA.BackColor = Color.LightGray;
            txtCondicionIVA.Location = new Point(540, 93);
            txtCondicionIVA.Name = "txtCondicionIVA";
            txtCondicionIVA.ReadOnly = true;
            txtCondicionIVA.Size = new Size(200, 27);
            txtCondicionIVA.TabIndex = 14;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(20, 135);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 25;
            dgvProductos.Size = new Size(1160, 350);
            dgvProductos.TabIndex = 15;
            // 
            // lblSubtotalLabel
            // 
            lblSubtotalLabel.AutoSize = true;
            lblSubtotalLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubtotalLabel.Location = new Point(900, 488);
            lblSubtotalLabel.Name = "lblSubtotalLabel";
            lblSubtotalLabel.Size = new Size(84, 23);
            lblSubtotalLabel.TabIndex = 16;
            lblSubtotalLabel.Text = "Subtotal:";
            // 
            // lblSubtotal
            // 
            lblSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSubtotal.ForeColor = Color.DarkBlue;
            lblSubtotal.Location = new Point(1000, 485);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(180, 25);
            lblSubtotal.TabIndex = 17;
            lblSubtotal.Text = "0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDescuentoLabel
            // 
            lblDescuentoLabel.AutoSize = true;
            lblDescuentoLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescuentoLabel.Location = new Point(900, 511);
            lblDescuentoLabel.Name = "lblDescuentoLabel";
            lblDescuentoLabel.Size = new Size(98, 23);
            lblDescuentoLabel.TabIndex = 18;
            lblDescuentoLabel.Text = "Descuento:";
            // 
            // lblDescuento
            // 
            lblDescuento.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescuento.ForeColor = Color.DarkRed;
            lblDescuento.Location = new Point(1000, 508);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(180, 25);
            lblDescuento.TabIndex = 19;
            lblDescuento.Text = "0.00";
            lblDescuento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIVALabel
            // 
            lblIVALabel.AutoSize = true;
            lblIVALabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIVALabel.Location = new Point(902, 549);
            lblIVALabel.Name = "lblIVALabel";
            lblIVALabel.Size = new Size(82, 23);
            lblIVALabel.TabIndex = 20;
            lblIVALabel.Text = "IVA 21%:";
            // 
            // lblIVA
            // 
            lblIVA.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIVA.ForeColor = Color.DarkOrange;
            lblIVA.Location = new Point(1002, 546);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(180, 25);
            lblIVA.TabIndex = 21;
            lblIVA.Text = "0.00";
            lblIVA.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalLabel.Location = new Point(902, 587);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(77, 28);
            lblTotalLabel.TabIndex = 22;
            lblTotalLabel.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotal.ForeColor = Color.ForestGreen;
            lblTotal.Location = new Point(1002, 582);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(180, 30);
            lblTotal.TabIndex = 23;
            lblTotal.Text = "0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.Location = new Point(20, 510);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(112, 20);
            lblFormaPago.TabIndex = 22;
            lblFormaPago.Text = "Forma de Pago:";
            // 
            // cboFormaPago
            // 
            cboFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormaPago.FormattingEnabled = true;
            cboFormaPago.Location = new Point(20, 528);
            cboFormaPago.Name = "cboFormaPago";
            cboFormaPago.Size = new Size(180, 28);
            cboFormaPago.TabIndex = 23;
            // 
            // lblPagaCon
            // 
            lblPagaCon.AutoSize = true;
            lblPagaCon.Location = new Point(220, 510);
            lblPagaCon.Name = "lblPagaCon";
            lblPagaCon.Size = new Size(72, 20);
            lblPagaCon.TabIndex = 24;
            lblPagaCon.Text = "Paga con:";
            // 
            // txtPagaCon
            // 
            txtPagaCon.Location = new Point(220, 528);
            txtPagaCon.Name = "txtPagaCon";
            txtPagaCon.Size = new Size(120, 27);
            txtPagaCon.TabIndex = 25;
            txtPagaCon.Text = "0";
            txtPagaCon.TextAlign = HorizontalAlignment.Right;
            txtPagaCon.TextChanged += txtPagaCon_TextChanged;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Location = new Point(360, 510);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(64, 20);
            lblCambio.TabIndex = 26;
            lblCambio.Text = "Cambio:";
            // 
            // txtCambio
            // 
            txtCambio.BackColor = Color.LightGray;
            txtCambio.Location = new Point(360, 528);
            txtCambio.Name = "txtCambio";
            txtCambio.ReadOnly = true;
            txtCambio.Size = new Size(120, 27);
            txtCambio.TabIndex = 27;
            txtCambio.Text = "0";
            txtCambio.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGuardarVenta
            // 
            btnGuardarVenta.BackColor = Color.ForestGreen;
            btnGuardarVenta.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardarVenta.ForeColor = Color.White;
            btnGuardarVenta.Location = new Point(900, 618);
            btnGuardarVenta.Name = "btnGuardarVenta";
            btnGuardarVenta.Size = new Size(140, 40);
            btnGuardarVenta.TabIndex = 28;
            btnGuardarVenta.Text = " Guardar";
            btnGuardarVenta.UseVisualStyleBackColor = false;
            btnGuardarVenta.Click += btnGuardarVenta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Firebrick;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(1050, 618);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 40);
            btnCancelar.TabIndex = 29;
            btnCancelar.Text = " Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmVentasFiscales
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            ClientSize = new Size(1200, 670);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarVenta);
            Controls.Add(txtCambio);
            Controls.Add(lblCambio);
            Controls.Add(txtPagaCon);
            Controls.Add(lblPagaCon);
            Controls.Add(cboFormaPago);
            Controls.Add(lblFormaPago);
            Controls.Add(lblTotal);
            Controls.Add(lblTotalLabel);
            Controls.Add(lblIVA);
            Controls.Add(lblIVALabel);
            Controls.Add(lblDescuento);
            Controls.Add(lblDescuentoLabel);
            Controls.Add(lblSubtotal);
            Controls.Add(lblSubtotalLabel);
            Controls.Add(dgvProductos);
            Controls.Add(txtCondicionIVA);
            Controls.Add(lblCondicionIVA);
            Controls.Add(txtNombreCliente);
            Controls.Add(lblNombreCliente);
            Controls.Add(btnBuscarCliente);
            Controls.Add(txtIdCliente);
            Controls.Add(lblCliente);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtNumeroDocumento);
            Controls.Add(lblNumeroDocumento);
            Controls.Add(cboPuntoVenta);
            Controls.Add(lblPuntoVenta);
            Controls.Add(cboTipoComprobante);
            Controls.Add(lblTipoComprobante);
            Name = "frmVentasFiscales";
            Text = "Ventas Fiscales";
            Load += frmVentasFiscales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label lblPuntoVenta;
        private System.Windows.Forms.ComboBox cboPuntoVenta;
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblCondicionIVA;
        private System.Windows.Forms.TextBox txtCondicionIVA;
        
        private System.Windows.Forms.DataGridView dgvProductos;
        
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDescuentoLabel;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblIVALabel;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.Label lblPagaCon;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtCambio;
        
        private System.Windows.Forms.Button btnGuardarVenta;
        private System.Windows.Forms.Button btnCancelar;
    }
}
