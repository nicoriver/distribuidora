namespace CapaPresentacion
{
    partial class frmDevoluciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBoxBusqueda = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPuntoVenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxVentaOriginal = new System.Windows.Forms.GroupBox();
            this.lblTotalOriginal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClienteOriginal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFechaOriginal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTipoOriginal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxProductos = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDevolver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxTotales = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxObservaciones = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBoxBusqueda.SuspendLayout();
            this.groupBoxVentaOriginal.SuspendLayout();
            this.groupBoxProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBoxTotales.SuspendLayout();
            this.groupBoxObservaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(417, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DEVOLUCIONES / NOTAS DE CRÉDITO";
            // 
            // groupBoxBusqueda
            // 
            this.groupBoxBusqueda.Controls.Add(this.btnBuscar);
            this.groupBoxBusqueda.Controls.Add(this.txtNumeroDocumento);
            this.groupBoxBusqueda.Controls.Add(this.label3);
            this.groupBoxBusqueda.Controls.Add(this.cboPuntoVenta);
            this.groupBoxBusqueda.Controls.Add(this.label1);
            this.groupBoxBusqueda.Controls.Add(this.cboTipoComprobante);
            this.groupBoxBusqueda.Controls.Add(this.label12);
            this.groupBoxBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxBusqueda.Location = new System.Drawing.Point(12, 60);
            this.groupBoxBusqueda.Name = "groupBoxBusqueda";
            this.groupBoxBusqueda.Size = new System.Drawing.Size(1160, 100);
            this.groupBoxBusqueda.TabIndex = 1;
            this.groupBoxBusqueda.TabStop = false;
            this.groupBoxBusqueda.Text = "1. BÚSQUEDA DE VENTA ORIGINAL";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1030, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 40);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumeroDocumento.Location = new System.Drawing.Point(850, 40);
            this.txtNumeroDocumento.MaxLength = 10;
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(160, 30);
            this.txtNumeroDocumento.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(770, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Número:";
            // 
            // cboPuntoVenta
            // 
            this.cboPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntoVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPuntoVenta.FormattingEnabled = true;
            this.cboPuntoVenta.Location = new System.Drawing.Point(590, 40);
            this.cboPuntoVenta.Name = "cboPuntoVenta";
            this.cboPuntoVenta.Size = new System.Drawing.Size(160, 31);
            this.cboPuntoVenta.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(470, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Punto de Venta:";
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(200, 40);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(250, 31);
            this.cboTipoComprobante.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(20, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tipo de Comprobante:";
            // 
            // groupBoxVentaOriginal
            // 
            this.groupBoxVentaOriginal.Controls.Add(this.lblTotalOriginal);
            this.groupBoxVentaOriginal.Controls.Add(this.label6);
            this.groupBoxVentaOriginal.Controls.Add(this.lblClienteOriginal);
            this.groupBoxVentaOriginal.Controls.Add(this.label5);
            this.groupBoxVentaOriginal.Controls.Add(this.lblFechaOriginal);
            this.groupBoxVentaOriginal.Controls.Add(this.label4);
            this.groupBoxVentaOriginal.Controls.Add(this.lblTipoOriginal);
            this.groupBoxVentaOriginal.Controls.Add(this.label2);
            this.groupBoxVentaOriginal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxVentaOriginal.Location = new System.Drawing.Point(12, 170);
            this.groupBoxVentaOriginal.Name = "groupBoxVentaOriginal";
            this.groupBoxVentaOriginal.Size = new System.Drawing.Size(1160, 100);
            this.groupBoxVentaOriginal.TabIndex = 2;
            this.groupBoxVentaOriginal.TabStop = false;
            this.groupBoxVentaOriginal.Text = "2. DATOS DE LA VENTA ORIGINAL";
            // 
            // lblTotalOriginal
            // 
            this.lblTotalOriginal.AutoSize = true;
            this.lblTotalOriginal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalOriginal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalOriginal.Location = new System.Drawing.Point(950, 60);
            this.lblTotalOriginal.Name = "lblTotalOriginal";
            this.lblTotalOriginal.Size = new System.Drawing.Size(54, 23);
            this.lblTotalOriginal.TabIndex = 7;
            this.lblTotalOriginal.Text = "$0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(890, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Total:";
            // 
            // lblClienteOriginal
            // 
            this.lblClienteOriginal.AutoSize = true;
            this.lblClienteOriginal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClienteOriginal.Location = new System.Drawing.Point(100, 62);
            this.lblClienteOriginal.Name = "lblClienteOriginal";
            this.lblClienteOriginal.Size = new System.Drawing.Size(15, 20);
            this.lblClienteOriginal.TabIndex = 5;
            this.lblClienteOriginal.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(20, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cliente:";
            // 
            // lblFechaOriginal
            // 
            this.lblFechaOriginal.AutoSize = true;
            this.lblFechaOriginal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaOriginal.Location = new System.Drawing.Point(950, 30);
            this.lblFechaOriginal.Name = "lblFechaOriginal";
            this.lblFechaOriginal.Size = new System.Drawing.Size(15, 20);
            this.lblFechaOriginal.TabIndex = 3;
            this.lblFechaOriginal.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(890, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha:";
            // 
            // lblTipoOriginal
            // 
            this.lblTipoOriginal.AutoSize = true;
            this.lblTipoOriginal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoOriginal.Location = new System.Drawing.Point(100, 30);
            this.lblTipoOriginal.Name = "lblTipoOriginal";
            this.lblTipoOriginal.Size = new System.Drawing.Size(15, 20);
            this.lblTipoOriginal.TabIndex = 1;
            this.lblTipoOriginal.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            // 
            // groupBoxProductos
            // 
            this.groupBoxProductos.Controls.Add(this.dgvProductos);
            this.groupBoxProductos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxProductos.Location = new System.Drawing.Point(12, 280);
            this.groupBoxProductos.Name = "groupBoxProductos";
            this.groupBoxProductos.Size = new System.Drawing.Size(1160, 300);
            this.groupBoxProductos.TabIndex = 3;
            this.groupBoxProductos.TabStop = false;
            this.groupBoxProductos.Text = "3. PRODUCTOS A DEVOLVER";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Codigo,
            this.Producto,
            this.PrecioVenta,
            this.CantidadOriginal,
            this.CantidadDevolver,
            this.DescuentoPorcentaje,
            this.SubTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(3, 23);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 29;
            this.dgvProductos.Size = new System.Drawing.Size(1154, 274);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellValueChanged);
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 80F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.FillWeight = 200F;
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.FillWeight = 80F;
            this.PrecioVenta.HeaderText = "Precio";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            // 
            // CantidadOriginal
            // 
            this.CantidadOriginal.FillWeight = 80F;
            this.CantidadOriginal.HeaderText = "Cant. Original";
            this.CantidadOriginal.MinimumWidth = 6;
            this.CantidadOriginal.Name = "CantidadOriginal";
            this.CantidadOriginal.ReadOnly = true;
            // 
            // CantidadDevolver
            // 
            this.CantidadDevolver.FillWeight = 80F;
            this.CantidadDevolver.HeaderText = "Devolver";
            this.CantidadDevolver.MinimumWidth = 6;
            this.CantidadDevolver.Name = "CantidadDevolver";
            // 
            // DescuentoPorcentaje
            // 
            this.DescuentoPorcentaje.FillWeight = 80F;
            this.DescuentoPorcentaje.HeaderText = "Desc %";
            this.DescuentoPorcentaje.MinimumWidth = 6;
            this.DescuentoPorcentaje.Name = "DescuentoPorcentaje";
            this.DescuentoPorcentaje.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.FillWeight = 100F;
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // groupBoxTotales
            // 
            this.groupBoxTotales.Controls.Add(this.lblTotal);
            this.groupBoxTotales.Controls.Add(this.label11);
            this.groupBoxTotales.Controls.Add(this.lblIVA);
            this.groupBoxTotales.Controls.Add(this.label9);
            this.groupBoxTotales.Controls.Add(this.lblDescuento);
            this.groupBoxTotales.Controls.Add(this.label8);
            this.groupBoxTotales.Controls.Add(this.lblSubtotal);
            this.groupBoxTotales.Controls.Add(this.label7);
            this.groupBoxTotales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxTotales.Location = new System.Drawing.Point(12, 590);
            this.groupBoxTotales.Name = "groupBoxTotales";
            this.groupBoxTotales.Size = new System.Drawing.Size(400, 180);
            this.groupBoxTotales.TabIndex = 4;
            this.groupBoxTotales.TabStop = false;
            this.groupBoxTotales.Text = "4. TOTALES DE LA NOTA DE CRÉDITO";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(200, 130);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(180, 30);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "$0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(20, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 28);
            this.label11.TabIndex = 6;
            this.label11.Text = "TOTAL:";
            // 
            // lblIVA
            // 
            this.lblIVA.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIVA.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblIVA.Location = new System.Drawing.Point(200, 90);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(180, 25);
            this.lblIVA.TabIndex = 5;
            this.lblIVA.Text = "$0.00";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(20, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 23);
            this.label9.TabIndex = 4;
            this.label9.Text = "IVA 21%:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDescuento.Location = new System.Drawing.Point(200, 60);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(180, 25);
            this.lblDescuento.TabIndex = 3;
            this.lblDescuento.Text = "$0.00";
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(20, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Descuento:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSubtotal.Location = new System.Drawing.Point(200, 30);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(180, 25);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "$0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(20, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Subtotal:";
            // 
            // groupBoxObservaciones
            // 
            this.groupBoxObservaciones.Controls.Add(this.txtObservaciones);
            this.groupBoxObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxObservaciones.Location = new System.Drawing.Point(430, 590);
            this.groupBoxObservaciones.Name = "groupBoxObservaciones";
            this.groupBoxObservaciones.Size = new System.Drawing.Size(742, 180);
            this.groupBoxObservaciones.TabIndex = 5;
            this.groupBoxObservaciones.TabStop = false;
            this.groupBoxObservaciones.Text = "5. OBSERVACIONES";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(3, 23);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(736, 154);
            this.txtObservaciones.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(880, 780);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 45);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.DarkRed;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(1032, 780);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(140, 45);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar NC";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // frmDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1184, 837);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBoxObservaciones);
            this.Controls.Add(this.groupBoxTotales);
            this.Controls.Add(this.groupBoxProductos);
            this.Controls.Add(this.groupBoxVentaOriginal);
            this.Controls.Add(this.groupBoxBusqueda);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDevoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devoluciones / Notas de Crédito";
            this.Load += new System.EventHandler(this.frmDevoluciones_Load);
            this.groupBoxBusqueda.ResumeLayout(false);
            this.groupBoxBusqueda.PerformLayout();
            this.groupBoxVentaOriginal.ResumeLayout(false);
            this.groupBoxVentaOriginal.PerformLayout();
            this.groupBoxProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBoxTotales.ResumeLayout(false);
            this.groupBoxTotales.PerformLayout();
            this.groupBoxObservaciones.ResumeLayout(false);
            this.groupBoxObservaciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBoxBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPuntoVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBoxVentaOriginal;
        private System.Windows.Forms.Label lblTotalOriginal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClienteOriginal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFechaOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipoOriginal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox groupBoxTotales;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDevolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoPorcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}
