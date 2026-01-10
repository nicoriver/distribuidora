namespace CapaPresentacion
{
    partial class frmClientes
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
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblTipoDni = new System.Windows.Forms.Label();
            this.txtIdTipoDni = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtIdCodigoIva = new System.Windows.Forms.TextBox();
            this.tabUbicacion = new System.Windows.Forms.TabPage();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtIdProvincia = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtIdLocalidad = new System.Windows.Forms.TextBox();
            this.lblZona = new System.Windows.Forms.Label();
            this.txtIdZona = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.txtIdPais = new System.Windows.Forms.TextBox();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.lblLon = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.tabContacto = new System.Windows.Forms.TabPage();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelAlt = new System.Windows.Forms.Label();
            this.txtTelefonoAlt = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.txtIdVendedor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabUbicacion.SuspendLayout();
            this.tabContacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.Black;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(2701, 98);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(112, 55);
            this.btnbuscar.TabIndex = 53;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Documento,
            this.NombreCompleto,
            this.Correo,
            this.Telefono,
            this.EstadoValor,
            this.Estado});
            this.dgvdata.Location = new System.Drawing.Point(739, 241);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersWidth = 102;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(2243, 887);
            this.dgvdata.TabIndex = 47;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.MinimumWidth = 12;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 12;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 250;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Nro Documento";
            this.Documento.MinimumWidth = 12;
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 150;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.MinimumWidth = 12;
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 180;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 12;
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 150;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 12;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 250;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 12;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 250;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 12;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 250;
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 18;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(2829, 98);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(112, 55);
            this.btnlimpiarbuscador.TabIndex = 54;
            this.btnlimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Location = new System.Drawing.Point(2275, 103);
            this.txtbusqueda.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(399, 38);
            this.txtbusqueda.TabIndex = 52;
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(1949, 100);
            this.cbobusqueda.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(303, 39);
            this.cbobusqueda.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1771, 110);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 32);
            this.label11.TabIndex = 50;
            this.label11.Text = "Buscar por:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(536, 105);
            this.txtid.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(60, 38);
            this.txtid.TabIndex = 49;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(739, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(2239, 133);
            this.label10.TabIndex = 48;
            this.label10.Text = "Lista de Clientes:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtindice
            // 
            this.txtindice.Location = new System.Drawing.Point(453, 105);
            this.txtindice.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(60, 38);
            this.txtindice.TabIndex = 55;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(80, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(350, 58);
            this.label9.TabIndex = 46;
            this.label9.Text = "Detalle Cliente";
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btneliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btneliminar.IconColor = System.Drawing.Color.White;
            this.btneliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btneliminar.IconSize = 16;
            this.btneliminar.Location = new System.Drawing.Point(80, 1202);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(512, 55);
            this.btneliminar.TabIndex = 45;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.White;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 18;
            this.btnlimpiar.Location = new System.Drawing.Point(80, 1130);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(512, 55);
            this.btnlimpiar.TabIndex = 44;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnguardar.IconColor = System.Drawing.Color.White;
            this.btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnguardar.IconSize = 16;
            this.btnguardar.Location = new System.Drawing.Point(80, 1059);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(512, 55);
            this.btnguardar.TabIndex = 43;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(84, 983);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 32);
            this.label8.TabIndex = 42;
            this.label8.Text = "Estado:";
            // 
            // cboestado
            // 
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(217, 976);
            this.cboestado.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(473, 39);
            this.cboestado.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 1454);
            this.label1.TabIndex = 28;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabUbicacion);
            this.tabControl1.Controls.Add(this.tabContacto);
            this.tabControl1.Location = new System.Drawing.Point(80, 119);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 830);
            this.tabControl1.TabIndex = 60;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lblDni);
            this.tabGeneral.Controls.Add(this.txtDni);
            this.tabGeneral.Controls.Add(this.lblApellido);
            this.tabGeneral.Controls.Add(this.txtApellido);
            this.tabGeneral.Controls.Add(this.lblNombre);
            this.tabGeneral.Controls.Add(this.txtNombre);
            this.tabGeneral.Controls.Add(this.lblRazonSocial);
            this.tabGeneral.Controls.Add(this.txtRazonSocial);
            this.tabGeneral.Controls.Add(this.lblCuit);
            this.tabGeneral.Controls.Add(this.txtCuit);
            this.tabGeneral.Controls.Add(this.lblTipoDni);
            this.tabGeneral.Controls.Add(this.txtIdTipoDni);
            this.tabGeneral.Controls.Add(this.lblIva);
            this.tabGeneral.Controls.Add(this.txtIdCodigoIva);
            this.tabGeneral.Location = new System.Drawing.Point(10, 48);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabGeneral.Size = new System.Drawing.Size(593, 772);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Datos";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(16, 24);
            this.lblDni.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(69, 32);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(22, 74);
            this.txtDni.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(260, 38);
            this.txtDni.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(16, 150);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(126, 32);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(16, 189);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(527, 38);
            this.txtApellido.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(16, 254);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(122, 32);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(22, 304);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(527, 38);
            this.txtNombre.TabIndex = 5;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(16, 368);
            this.lblRazonSocial.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(190, 32);
            this.lblRazonSocial.TabIndex = 6;
            this.lblRazonSocial.Text = "Razón Social:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(16, 422);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(527, 38);
            this.txtRazonSocial.TabIndex = 7;
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(16, 467);
            this.lblCuit.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(86, 32);
            this.lblCuit.TabIndex = 8;
            this.lblCuit.Text = "CUIT:";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(16, 503);
            this.txtCuit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(260, 38);
            this.txtCuit.TabIndex = 9;
            // 
            // lblTipoDni
            // 
            this.lblTipoDni.AutoSize = true;
            this.lblTipoDni.Location = new System.Drawing.Point(5, 620);
            this.lblTipoDni.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTipoDni.Name = "lblTipoDni";
            this.lblTipoDni.Size = new System.Drawing.Size(166, 32);
            this.lblTipoDni.TabIndex = 10;
            this.lblTipoDni.Text = "ID Tipo DNI:";
            // 
            // txtIdTipoDni
            // 
            this.txtIdTipoDni.Location = new System.Drawing.Point(176, 613);
            this.txtIdTipoDni.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdTipoDni.Name = "txtIdTipoDni";
            this.txtIdTipoDni.Size = new System.Drawing.Size(100, 38);
            this.txtIdTipoDni.TabIndex = 11;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(309, 620);
            this.lblIva.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(101, 32);
            this.lblIva.TabIndex = 12;
            this.lblIva.Text = "ID IVA:";
            // 
            // txtIdCodigoIva
            // 
            this.txtIdCodigoIva.Location = new System.Drawing.Point(429, 613);
            this.txtIdCodigoIva.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdCodigoIva.Name = "txtIdCodigoIva";
            this.txtIdCodigoIva.Size = new System.Drawing.Size(100, 38);
            this.txtIdCodigoIva.TabIndex = 13;
            // 
            // tabUbicacion
            // 
            this.tabUbicacion.Controls.Add(this.lblDomicilio);
            this.tabUbicacion.Controls.Add(this.txtDomicilio);
            this.tabUbicacion.Controls.Add(this.lblProvincia);
            this.tabUbicacion.Controls.Add(this.txtIdProvincia);
            this.tabUbicacion.Controls.Add(this.lblLocalidad);
            this.tabUbicacion.Controls.Add(this.txtIdLocalidad);
            this.tabUbicacion.Controls.Add(this.lblZona);
            this.tabUbicacion.Controls.Add(this.txtIdZona);
            this.tabUbicacion.Controls.Add(this.lblPais);
            this.tabUbicacion.Controls.Add(this.txtIdPais);
            this.tabUbicacion.Controls.Add(this.lblLat);
            this.tabUbicacion.Controls.Add(this.txtLatitud);
            this.tabUbicacion.Controls.Add(this.lblLon);
            this.tabUbicacion.Controls.Add(this.txtLongitud);
            this.tabUbicacion.Location = new System.Drawing.Point(10, 48);
            this.tabUbicacion.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabUbicacion.Name = "tabUbicacion";
            this.tabUbicacion.Size = new System.Drawing.Size(593, 772);
            this.tabUbicacion.TabIndex = 1;
            this.tabUbicacion.Text = "Ubicación";
            this.tabUbicacion.UseVisualStyleBackColor = true;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(16, 24);
            this.lblDomicilio.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(139, 32);
            this.lblDomicilio.TabIndex = 0;
            this.lblDomicilio.Text = "Domicilio:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(16, 60);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(527, 38);
            this.txtDomicilio.TabIndex = 1;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(16, 155);
            this.lblProvincia.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(114, 32);
            this.lblProvincia.TabIndex = 2;
            this.lblProvincia.Text = "ID Prov:";
            // 
            // txtIdProvincia
            // 
            this.txtIdProvincia.Location = new System.Drawing.Point(160, 148);
            this.txtIdProvincia.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdProvincia.Name = "txtIdProvincia";
            this.txtIdProvincia.Size = new System.Drawing.Size(100, 38);
            this.txtIdProvincia.TabIndex = 3;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(293, 155);
            this.lblLocalidad.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(102, 32);
            this.lblLocalidad.TabIndex = 4;
            this.lblLocalidad.Text = "ID Loc:";
            // 
            // txtIdLocalidad
            // 
            this.txtIdLocalidad.Location = new System.Drawing.Point(427, 148);
            this.txtIdLocalidad.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdLocalidad.Name = "txtIdLocalidad";
            this.txtIdLocalidad.Size = new System.Drawing.Size(100, 38);
            this.txtIdLocalidad.TabIndex = 5;
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Location = new System.Drawing.Point(16, 250);
            this.lblZona.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(121, 32);
            this.lblZona.TabIndex = 6;
            this.lblZona.Text = "ID Zona:";
            // 
            // txtIdZona
            // 
            this.txtIdZona.Location = new System.Drawing.Point(160, 243);
            this.txtIdZona.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdZona.Name = "txtIdZona";
            this.txtIdZona.Size = new System.Drawing.Size(100, 38);
            this.txtIdZona.TabIndex = 7;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(293, 250);
            this.lblPais.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(112, 32);
            this.lblPais.TabIndex = 8;
            this.lblPais.Text = "ID Pais:";
            // 
            // txtIdPais
            // 
            this.txtIdPais.Location = new System.Drawing.Point(427, 243);
            this.txtIdPais.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdPais.Name = "txtIdPais";
            this.txtIdPais.Size = new System.Drawing.Size(100, 38);
            this.txtIdPais.TabIndex = 9;
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(16, 346);
            this.lblLat.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(62, 32);
            this.lblLat.TabIndex = 10;
            this.lblLat.Text = "Lat:";
            // 
            // txtLatitud
            // 
            this.txtLatitud.Location = new System.Drawing.Point(93, 339);
            this.txtLatitud.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(180, 38);
            this.txtLatitud.TabIndex = 11;
            // 
            // lblLon
            // 
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new System.Drawing.Point(307, 346);
            this.lblLon.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(70, 32);
            this.lblLon.TabIndex = 12;
            this.lblLon.Text = "Lon:";
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(387, 339);
            this.txtLongitud.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(180, 38);
            this.txtLongitud.TabIndex = 13;
            // 
            // tabContacto
            // 
            this.tabContacto.Controls.Add(this.lblTelefono);
            this.tabContacto.Controls.Add(this.txtTelefono);
            this.tabContacto.Controls.Add(this.lblTelAlt);
            this.tabContacto.Controls.Add(this.txtTelefonoAlt);
            this.tabContacto.Controls.Add(this.lblFax);
            this.tabContacto.Controls.Add(this.txtFax);
            this.tabContacto.Controls.Add(this.lblEmail);
            this.tabContacto.Controls.Add(this.txtEmail);
            this.tabContacto.Controls.Add(this.lblWeb);
            this.tabContacto.Controls.Add(this.txtWeb);
            this.tabContacto.Controls.Add(this.lblContacto);
            this.tabContacto.Controls.Add(this.txtContacto);
            this.tabContacto.Controls.Add(this.lblVendedor);
            this.tabContacto.Controls.Add(this.txtIdVendedor);
            this.tabContacto.Location = new System.Drawing.Point(10, 48);
            this.tabContacto.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabContacto.Name = "tabContacto";
            this.tabContacto.Size = new System.Drawing.Size(593, 772);
            this.tabContacto.TabIndex = 2;
            this.tabContacto.Text = "Contacto";
            this.tabContacto.UseVisualStyleBackColor = true;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(16, 24);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(134, 32);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(16, 60);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(527, 38);
            this.txtTelefono.TabIndex = 1;
            // 
            // lblTelAlt
            // 
            this.lblTelAlt.AutoSize = true;
            this.lblTelAlt.Location = new System.Drawing.Point(16, 155);
            this.lblTelAlt.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTelAlt.Name = "lblTelAlt";
            this.lblTelAlt.Size = new System.Drawing.Size(183, 32);
            this.lblTelAlt.TabIndex = 2;
            this.lblTelAlt.Text = "Teléfono Alt.:";
            // 
            // txtTelefonoAlt
            // 
            this.txtTelefonoAlt.Location = new System.Drawing.Point(16, 191);
            this.txtTelefonoAlt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtTelefonoAlt.Name = "txtTelefonoAlt";
            this.txtTelefonoAlt.Size = new System.Drawing.Size(527, 38);
            this.txtTelefonoAlt.TabIndex = 3;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(16, 286);
            this.lblFax.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(69, 32);
            this.lblFax.TabIndex = 4;
            this.lblFax.Text = "Fax:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(16, 322);
            this.txtFax.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(527, 38);
            this.txtFax.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 429);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(94, 32);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(16, 465);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(527, 38);
            this.txtEmail.TabIndex = 7;
            // 
            // lblWeb
            // 
            this.lblWeb.AutoSize = true;
            this.lblWeb.Location = new System.Drawing.Point(16, 572);
            this.lblWeb.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(80, 32);
            this.lblWeb.TabIndex = 8;
            this.lblWeb.Text = "Web:";
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(16, 608);
            this.txtWeb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(527, 38);
            this.txtWeb.TabIndex = 9;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(16, 668);
            this.lblContacto.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(136, 32);
            this.lblContacto.TabIndex = 10;
            this.lblContacto.Text = "Contacto:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(16, 703);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(527, 38);
            this.txtContacto.TabIndex = 11;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(16, 799);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(180, 32);
            this.lblVendedor.TabIndex = 12;
            this.lblVendedor.Text = "ID Vendedor:";
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Location = new System.Drawing.Point(213, 792);
            this.txtIdVendedor.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(127, 38);
            this.txtIdVendedor.TabIndex = 13;
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3056, 1454);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabUbicacion.ResumeLayout(false);
            this.tabUbicacion.PerformLayout();
            this.tabContacto.ResumeLayout(false);
            this.tabContacto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtindice;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnguardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabUbicacion;
        private System.Windows.Forms.TabPage tabContacto;
        
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblTipoDni;
        private System.Windows.Forms.TextBox txtIdTipoDni; 
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtIdCodigoIva; 

        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox txtIdProvincia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox txtIdLocalidad;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.TextBox txtIdZona;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.TextBox txtIdPais;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.TextBox txtLongitud;

        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelAlt;
        private System.Windows.Forms.TextBox txtTelefonoAlt;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox txtIdVendedor;
    }
}