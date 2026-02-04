namespace CapaPresentacion.Net8
{
    partial class frmClientes
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabUbicacion = new System.Windows.Forms.TabPage();
            this.tabContacto = new System.Windows.Forms.TabPage();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            
            // Labels y TextBoxes - Tab General
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
            this.cboTipoDni = new System.Windows.Forms.ComboBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.cboTipoIVA = new System.Windows.Forms.ComboBox();
            
            // Tab Ubicacion
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.lblZona = new System.Windows.Forms.Label();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.lblLon = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            
            // Tab Contacto
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
            
            // Botones y controles principales
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            
            // Búsqueda
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.btnlimpiarbuscador = new System.Windows.Forms.Button();
            
            // Hidden fields
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtindice = new System.Windows.Forms.TextBox();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabUbicacion.SuspendLayout();
            this.tabContacto.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabUbicacion);
            this.tabControl1.Controls.Add(this.tabContacto);
            this.tabControl1.Location = new System.Drawing.Point(20, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 350);
            this.tabControl1.TabIndex = 0;
            
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
            this.tabGeneral.Controls.Add(this.cboTipoDni);
            this.tabGeneral.Controls.Add(this.lblIva);
            this.tabGeneral.Controls.Add(this.cboTipoIVA);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(392, 324);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Datos";
            this.tabGeneral.UseVisualStyleBackColor = true;
            
            // Tab General Controls
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(10, 10);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 13);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            
            this.txtDni.Location = new System.Drawing.Point(10, 26);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(150, 20);
            this.txtDni.TabIndex = 1;
            
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(10, 52);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            
            this.txtApellido.Location = new System.Drawing.Point(10, 68);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(360, 20);
            this.txtApellido.TabIndex = 3;
            
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(10, 94);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            
            this.txtNombre.Location = new System.Drawing.Point(10, 110);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(360, 20);
            this.txtNombre.TabIndex = 5;
            
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(10, 136);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazonSocial.TabIndex = 6;
            this.lblRazonSocial.Text = "Razón Social:";
            
            this.txtRazonSocial.Location = new System.Drawing.Point(10, 152);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(360, 20);
            this.txtRazonSocial.TabIndex = 7;
            
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(10, 178);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(35, 13);
            this.lblCuit.TabIndex = 8;
            this.lblCuit.Text = "CUIT:";
            
            this.txtCuit.Location = new System.Drawing.Point(10, 194);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(150, 20);
            this.txtCuit.TabIndex = 9;
            
            this.lblTipoDni.AutoSize = true;
            this.lblTipoDni.Location = new System.Drawing.Point(10, 220);
            this.lblTipoDni.Name = "lblTipoDni";
            this.lblTipoDni.Size = new System.Drawing.Size(53, 13);
            this.lblTipoDni.TabIndex = 10;
            this.lblTipoDni.Text = "Tipo DNI:";
            
            this.cboTipoDni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDni.FormattingEnabled = true;
            this.cboTipoDni.Location = new System.Drawing.Point(10, 236);
            this.cboTipoDni.Name = "cboTipoDni";
            this.cboTipoDni.Size = new System.Drawing.Size(150, 21);
            this.cboTipoDni.TabIndex = 11;
            
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(10, 263);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(51, 13);
            this.lblIva.TabIndex = 12;
            this.lblIva.Text = "Tipo IVA:";
            
            this.cboTipoIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIVA.FormattingEnabled = true;
            this.cboTipoIVA.Location = new System.Drawing.Point(10, 279);
            this.cboTipoIVA.Name = "cboTipoIVA";
            this.cboTipoIVA.Size = new System.Drawing.Size(200, 21);
            this.cboTipoIVA.TabIndex = 13;
            
            // 
            // tabUbicacion
            // 
            this.tabUbicacion.Controls.Add(this.lblDomicilio);
            this.tabUbicacion.Controls.Add(this.txtDomicilio);
            this.tabUbicacion.Controls.Add(this.lblProvincia);
            this.tabUbicacion.Controls.Add(this.cboProvincia);
            this.tabUbicacion.Controls.Add(this.lblLocalidad);
            this.tabUbicacion.Controls.Add(this.cboLocalidad);
            this.tabUbicacion.Controls.Add(this.lblZona);
            this.tabUbicacion.Controls.Add(this.cboZona);
            this.tabUbicacion.Controls.Add(this.lblLat);
            this.tabUbicacion.Controls.Add(this.txtLatitud);
            this.tabUbicacion.Controls.Add(this.lblLon);
            this.tabUbicacion.Controls.Add(this.txtLongitud);
            this.tabUbicacion.Location = new System.Drawing.Point(4, 22);
            this.tabUbicacion.Name = "tabUbicacion";
            this.tabUbicacion.Size = new System.Drawing.Size(392, 324);
            this.tabUbicacion.TabIndex = 1;
            this.tabUbicacion.Text = "Ubicación";
            this.tabUbicacion.UseVisualStyleBackColor = true;
            
            // Tab Ubicacion Controls
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(10, 10);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(52, 13);
            this.lblDomicilio.TabIndex = 0;
            this.lblDomicilio.Text = "Domicilio:";
            
            this.txtDomicilio.Location = new System.Drawing.Point(10, 26);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(360, 20);
            this.txtDomicilio.TabIndex = 1;
            
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(10, 52);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 2;
            this.lblProvincia.Text = "Provincia:";
            
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(10, 68);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(360, 21);
            this.cboProvincia.TabIndex = 3;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(10, 95);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 4;
            this.lblLocalidad.Text = "Localidad:";
            
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(10, 111);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(360, 21);
            this.cboLocalidad.TabIndex = 5;
            
            this.lblZona.AutoSize = true;
            this.lblZona.Location = new System.Drawing.Point(10, 138);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(35, 13);
            this.lblZona.TabIndex = 6;
            this.lblZona.Text = "Zona:";
            
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(10, 154);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(250, 21);
            this.cboZona.TabIndex = 7;
            
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(10, 181);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(25, 13);
            this.lblLat.TabIndex = 8;
            this.lblLat.Text = "Lat:";
            
            this.txtLatitud.Location = new System.Drawing.Point(50, 178);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(100, 20);
            this.txtLatitud.TabIndex = 9;
            this.txtLatitud.Text = "0";
            
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new System.Drawing.Point(160, 181);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(28, 13);
            this.lblLon.TabIndex = 10;
            this.lblLon.Text = "Lon:";
            
            this.txtLongitud.Location = new System.Drawing.Point(200, 178);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(100, 20);
            this.txtLongitud.TabIndex = 11;
            this.txtLongitud.Text = "0";
            
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
            this.tabContacto.Location = new System.Drawing.Point(4, 22);
            this.tabContacto.Name = "tabContacto";
            this.tabContacto.Size = new System.Drawing.Size(392, 324);
            this.tabContacto.TabIndex = 2;
            this.tabContacto.Text = "Contacto";
            this.tabContacto.UseVisualStyleBackColor = true;
            
            // Tab Contacto Controls
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(10, 10);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Teléfono:";
            
            this.txtTelefono.Location = new System.Drawing.Point(10, 26);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(360, 20);
            this.txtTelefono.TabIndex = 1;
            
            this.lblTelAlt.AutoSize = true;
            this.lblTelAlt.Location = new System.Drawing.Point(10, 52);
            this.lblTelAlt.Name = "lblTelAlt";
            this.lblTelAlt.Size = new System.Drawing.Size(84, 13);
            this.lblTelAlt.TabIndex = 2;
            this.lblTelAlt.Text = "Teléfono Alt.:";
            
            this.txtTelefonoAlt.Location = new System.Drawing.Point(10, 68);
            this.txtTelefonoAlt.Name = "txtTelefonoAlt";
            this.txtTelefonoAlt.Size = new System.Drawing.Size(360, 20);
            this.txtTelefonoAlt.TabIndex = 3;
            
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(10, 94);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(27, 13);
            this.lblFax.TabIndex = 4;
            this.lblFax.Text = "Fax:";
            
            this.txtFax.Location = new System.Drawing.Point(10, 110);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(360, 20);
            this.txtFax.TabIndex = 5;
            
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 136);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            
            this.txtEmail.Location = new System.Drawing.Point(10, 152);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 20);
            this.txtEmail.TabIndex = 7;
            
            this.lblWeb.AutoSize = true;
            this.lblWeb.Location = new System.Drawing.Point(10, 178);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(30, 13);
            this.lblWeb.TabIndex = 8;
            this.lblWeb.Text = "Web:";
            
            this.txtWeb.Location = new System.Drawing.Point(10, 194);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(360, 20);
            this.txtWeb.TabIndex = 9;
            
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(10, 220);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(53, 13);
            this.lblContacto.TabIndex = 10;
            this.lblContacto.Text = "Contacto:";
            
            this.txtContacto.Location = new System.Drawing.Point(10, 236);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(360, 20);
            this.txtContacto.TabIndex = 11;
            
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(10, 262);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(68, 13);
            this.lblVendedor.TabIndex = 12;
            this.lblVendedor.Text = "Id Vendedor:";
            
            this.txtIdVendedor.Location = new System.Drawing.Point(10, 278);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(100, 20);
            this.txtIdVendedor.TabIndex = 13;
            this.txtIdVendedor.Text = "0";
            
            // 
            // Estado y Botones
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 420);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado:";
            
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(70, 417);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(150, 21);
            this.cboestado.TabIndex = 2;
            
            this.btnguardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.Location = new System.Drawing.Point(20, 450);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(120, 30);
            this.btnguardar.TabIndex = 3;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            
            this.btnlimpiar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.Location = new System.Drawing.Point(150, 450);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(120, 30);
            this.btnlimpiar.TabIndex = 4;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            
            this.btneliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btneliminar.ForeColor = System.Drawing.Color.White;
            this.btneliminar.Location = new System.Drawing.Point(280, 450);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(120, 30);
            this.btneliminar.TabIndex = 5;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            
            // 
            // DataGridView
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
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
            this.dgvdata.Location = new System.Drawing.Point(440, 90);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.Size = new System.Drawing.Size(750, 390);
            this.dgvdata.TabIndex = 10;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            
            // DataGridView Columns
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Text = "";
            this.btnseleccionar.UseColumnTextForButtonValue = true;
            this.btnseleccionar.Width = 30;
            
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            
            this.Documento.HeaderText = "DNI";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 100;
            
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 200;
            
            this.Correo.HeaderText = "Email";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 150;
            
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 120;
            
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 80;
            
            // 
            // Búsqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Location = new System.Drawing.Point(440, 63);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(64, 13);
            this.lblBusqueda.TabIndex = 11;
            this.lblBusqueda.Text = "Buscar por:";
            
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(510, 60);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(150, 21);
            this.cbobusqueda.TabIndex = 12;
            
            this.txtbusqueda.Location = new System.Drawing.Point(670, 60);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(200, 20);
            this.txtbusqueda.TabIndex = 13;
            
            this.btnbuscar.Location = new System.Drawing.Point(880, 58);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(60, 24);
            this.btnbuscar.TabIndex = 14;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(950, 58);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(60, 24);
            this.btnlimpiarbuscador.TabIndex = 15;
            this.btnlimpiarbuscador.Text = "Limpiar";
            this.btnlimpiarbuscador.UseVisualStyleBackColor = true;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            
            // Hidden fields
            this.txtid.Location = new System.Drawing.Point(20, 20);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(50, 20);
            this.txtid.TabIndex = 20;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            
            this.txtindice.Location = new System.Drawing.Point(80, 20);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(50, 20);
            this.txtindice.TabIndex = 21;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            
            // 
            // frmClientes
            // 
            this.ClientSize = new System.Drawing.Size(1220, 520);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmClientes";
            this.Text = "Gestión de Clientes";
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabUbicacion;
        private System.Windows.Forms.TabPage tabContacto;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblTipoDni;
        private System.Windows.Forms.ComboBox cboTipoDni;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.ComboBox cboTipoIVA;
        
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.ComboBox cboZona;
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
        
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button btneliminar;
        
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Button btnlimpiarbuscador;
        
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtindice;
    }
}
