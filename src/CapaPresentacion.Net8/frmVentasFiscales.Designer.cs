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
            // Encabezado
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblPuntoVenta = new System.Windows.Forms.Label();
            this.cboPuntoVenta = new System.Windows.Forms.ComboBox();
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            
            // Cliente
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblCondicionIVA = new System.Windows.Forms.Label();
            this.txtCondicionIVA = new System.Windows.Forms.TextBox();
            
            // Productos
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            
            // Totales
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDescuentoLabel = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblIVALabel = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            
            // Pago
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.lblPagaCon = new System.Windows.Forms.Label();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            
            // Botones
            this.btnGuardarVenta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoComprobante.Location = new System.Drawing.Point(20, 20);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(120, 15);
            this.lblTipoComprobante.TabIndex = 0;
            this.lblTipoComprobante.Text = "Tipo Comprobante:";
            
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(20, 38);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(200, 23);
            this.cboTipoComprobante.TabIndex = 1;
            this.cboTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobante_SelectedIndexChanged);
            
            // 
            // lblPuntoVenta
            // 
            this.lblPuntoVenta.AutoSize = true;
            this.lblPuntoVenta.Location = new System.Drawing.Point(240, 20);
            this.lblPuntoVenta.Name = "lblPuntoVenta";
            this.lblPuntoVenta.Size = new System.Drawing.Size(80, 15);
            this.lblPuntoVenta.TabIndex = 2;
            this.lblPuntoVenta.Text = "Punto Venta:";
            
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntoVenta.FormattingEnabled = true;
            this.cboPuntoVenta.Location = new System.Drawing.Point(240, 38);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(100, 23);
            this.cboPuntoVenta.TabIndex = 3;
            this.cboPuntoVenta.SelectedIndexChanged += new System.EventHandler(this.cboPuntoVenta_SelectedIndexChanged);
            
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(360, 20);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(56, 15);
            this.lblNumeroDocumento.TabIndex = 4;
            this.lblNumeroDocumento.Text = "Número:";
            
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(360, 38);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(150, 23);
            this.txtNumeroDocumento.TabIndex = 5;
            this.txtNumeroDocumento.BackColor = System.Drawing.Color.LightGray;
            
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(530, 20);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(530, 38);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 23);
            this.dtpFecha.TabIndex = 7;
            
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(20, 75);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(70, 15);
            this.lblCliente.TabIndex = 8;
            this.lblCliente.Text = "ID Cliente:";
            
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(20, 93);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(100, 23);
            this.txtIdCliente.TabIndex = 9;
            this.txtIdCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
            
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(130, 92);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(75, 25);
            this.btnBuscarCliente.TabIndex = 10;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(220, 75);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(54, 15);
            this.lblNombreCliente.TabIndex = 11;
            this.lblNombreCliente.Text = "Nombre:";
            
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(220, 93);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(300, 23);
            this.txtNombreCliente.TabIndex = 12;
            this.txtNombreCliente.BackColor = System.Drawing.Color.LightGray;
            
            // 
            // lblCondicionIVA
            // 
            this.lblCondicionIVA.AutoSize = true;
            this.lblCondicionIVA.Location = new System.Drawing.Point(540, 75);
            this.lblCondicionIVA.Name = "lblCondicionIVA";
            this.lblCondicionIVA.Size = new System.Drawing.Size(87, 15);
            this.lblCondicionIVA.TabIndex = 13;
            this.lblCondicionIVA.Text = "Condición IVA:";
            
            // 
            // txtCondicionIVA
            // 
            this.txtCondicionIVA.Location = new System.Drawing.Point(540, 93);
            this.txtCondicionIVA.Name = "txtCondicionIVA";
            this.txtCondicionIVA.ReadOnly = true;
            this.txtCondicionIVA.Size = new System.Drawing.Size(200, 23);
            this.txtCondicionIVA.TabIndex = 14;
            this.txtCondicionIVA.BackColor = System.Drawing.Color.LightGray;
            
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(20, 135);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 25;
            this.dgvProductos.Size = new System.Drawing.Size(1160, 350);
            this.dgvProductos.TabIndex = 15;
            
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalLabel.Location = new System.Drawing.Point(900, 500);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(70, 19);
            this.lblSubtotalLabel.TabIndex = 16;
            this.lblSubtotalLabel.Text = "Subtotal:";
            
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSubtotal.Location = new System.Drawing.Point(1000, 497);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(180, 25);
            this.lblSubtotal.TabIndex = 17;
            this.lblSubtotal.Text = "0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // 
            // lblDescuentoLabel
            // 
            this.lblDescuentoLabel.AutoSize = true;
            this.lblDescuentoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescuentoLabel.Location = new System.Drawing.Point(900, 530);
            this.lblDescuentoLabel.Name = "lblDescuentoLabel";
            this.lblDescuentoLabel.Size = new System.Drawing.Size(90, 19);
            this.lblDescuentoLabel.TabIndex = 18;
            this.lblDescuentoLabel.Text = "Descuento:";
            
            // 
            // lblDescuento
            // 
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDescuento.Location = new System.Drawing.Point(1000, 527);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(180, 25);
            this.lblDescuento.TabIndex = 19;
            this.lblDescuento.Text = "0.00";
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // 
            // lblIVALabel
            // 
            this.lblIVALabel.AutoSize = true;
            this.lblIVALabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIVALabel.Location = new System.Drawing.Point(900, 560);
            this.lblIVALabel.Name = "lblIVALabel";
            this.lblIVALabel.Size = new System.Drawing.Size(70, 19);
            this.lblIVALabel.TabIndex = 20;
            this.lblIVALabel.Text = "IVA 21%:";
            
            // 
            // lblIVA
            // 
            this.lblIVA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIVA.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblIVA.Location = new System.Drawing.Point(1000, 557);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(180, 25);
            this.lblIVA.TabIndex = 21;
            this.lblIVA.Text = "0.00";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(900, 595);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(65, 21);
            this.lblTotalLabel.TabIndex = 22;
            this.lblTotalLabel.Text = "TOTAL:";
            
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotal.Location = new System.Drawing.Point(1000, 590);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(180, 30);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(20, 510);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(90, 15);
            this.lblFormaPago.TabIndex = 22;
            this.lblFormaPago.Text = "Forma de Pago:";
            
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(20, 528);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(180, 23);
            this.cboFormaPago.TabIndex = 23;
            
            // 
            // lblPagaCon
            // 
            this.lblPagaCon.AutoSize = true;
            this.lblPagaCon.Location = new System.Drawing.Point(220, 510);
            this.lblPagaCon.Name = "lblPagaCon";
            this.lblPagaCon.Size = new System.Drawing.Size(62, 15);
            this.lblPagaCon.TabIndex = 24;
            this.lblPagaCon.Text = "Paga con:";
            
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.Location = new System.Drawing.Point(220, 528);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.Size = new System.Drawing.Size(120, 23);
            this.txtPagaCon.TabIndex = 25;
            this.txtPagaCon.Text = "0";
            this.txtPagaCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Location = new System.Drawing.Point(360, 510);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(51, 15);
            this.lblCambio.TabIndex = 26;
            this.lblCambio.Text = "Cambio:";
            
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(360, 528);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(120, 23);
            this.txtCambio.TabIndex = 27;
            this.txtCambio.Text = "0";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCambio.BackColor = System.Drawing.Color.LightGray;
            
            // 
            // btnGuardarVenta
            // 
            this.btnGuardarVenta.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardarVenta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardarVenta.ForeColor = System.Drawing.Color.White;
            this.btnGuardarVenta.Location = new System.Drawing.Point(900, 610);
            this.btnGuardarVenta.Name = "btnGuardarVenta";
            this.btnGuardarVenta.Size = new System.Drawing.Size(140, 40);
            this.btnGuardarVenta.TabIndex = 28;
            this.btnGuardarVenta.Text = " Guardar";
            this.btnGuardarVenta.UseVisualStyleBackColor = false;
            this.btnGuardarVenta.Click += new System.EventHandler(this.btnGuardarVenta_Click);
            
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1050, 610);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = " Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            
            // 
            // frmVentasFiscales
            // 
            this.ClientSize = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarVenta);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.txtPagaCon);
            this.Controls.Add(this.lblPagaCon);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblIVALabel);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblDescuentoLabel);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblSubtotalLabel);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtCondicionIVA);
            this.Controls.Add(this.lblCondicionIVA);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.lblNumeroDocumento);
            this.Controls.Add(this.cboPuntoVenta);
            this.Controls.Add(this.lblPuntoVenta);
            this.Controls.Add(this.cboTipoComprobante);
            this.Controls.Add(this.lblTipoComprobante);
            this.Name = "frmVentasFiscales";
            this.Text = "Ventas Fiscales";
            this.Load += new System.EventHandler(this.frmVentasFiscales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
