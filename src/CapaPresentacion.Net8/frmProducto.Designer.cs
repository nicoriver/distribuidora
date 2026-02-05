namespace CapaPresentacion.Net8
{
    partial class frmProducto
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
            dgvdata = new DataGridView();
            btnseleccionar = new DataGridViewButtonColumn();
            Id = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            IdCategoria = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            lblCodigo = new Label();
            txtcodigo = new TextBox();
            lblCodigoBarra = new Label();
            txtCodigoBarra = new TextBox();
            lblNombre = new Label();
            txtnombre = new TextBox();
            lblDescripcion = new Label();
            txtdescripcion = new TextBox();
            lblCategoria = new Label();
            cbocategoria = new ComboBox();
            lblEstado = new Label();
            cboestado = new ComboBox();
            lblPrecioCompra = new Label();
            txtPrecioCompra = new TextBox();
            lblDescuentoDistri = new Label();
            txtDescuentoDistri = new TextBox();
            lblPuntoReposicion = new Label();
            txtPuntoReposicion = new NumericUpDown();
            chkControlaStock = new CheckBox();
            btnguardar = new Button();
            btnlimpiar = new Button();
            btneliminar = new Button();
            btnPrecios = new Button();
            lblBusqueda = new Label();
            cbobusqueda = new ComboBox();
            txtbusqueda = new TextBox();
            btnbuscar = new Button();
            btnlimpiarbuscador = new Button();
            btnexportar = new Button();
            txtid = new TextBox();
            txtindice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPuntoReposicion).BeginInit();
            SuspendLayout();
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, Id, Codigo, Nombre, Descripcion, IdCategoria, Categoria, Stock, PrecioCompra, PrecioVenta, EstadoValor, Estado });
            dgvdata.Location = new Point(440, 90);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(750, 420);
            dgvdata.TabIndex = 20;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
            // 
            // btnseleccionar
            // 
            btnseleccionar.HeaderText = "";
            btnseleccionar.MinimumWidth = 6;
            btnseleccionar.Name = "btnseleccionar";
            btnseleccionar.ReadOnly = true;
            btnseleccionar.Text = "";
            btnseleccionar.UseColumnTextForButtonValue = true;
            btnseleccionar.Width = 30;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Código";
            Codigo.MinimumWidth = 6;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Width = 80;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 150;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripción";
            Descripcion.MinimumWidth = 6;
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            Descripcion.Width = 150;
            // 
            // IdCategoria
            // 
            IdCategoria.HeaderText = "IdCategoria";
            IdCategoria.MinimumWidth = 6;
            IdCategoria.Name = "IdCategoria";
            IdCategoria.ReadOnly = true;
            IdCategoria.Visible = false;
            IdCategoria.Width = 125;
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoría";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // Stock
            // 
            Stock.HeaderText = "Stock";
            Stock.MinimumWidth = 6;
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.Width = 60;
            // 
            // PrecioCompra
            // 
            PrecioCompra.HeaderText = "P. Compra";
            PrecioCompra.MinimumWidth = 6;
            PrecioCompra.Name = "PrecioCompra";
            PrecioCompra.ReadOnly = true;
            PrecioCompra.Width = 80;
            // 
            // PrecioVenta
            // 
            PrecioVenta.HeaderText = "P. Venta";
            PrecioVenta.MinimumWidth = 6;
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            PrecioVenta.Width = 80;
            // 
            // EstadoValor
            // 
            EstadoValor.HeaderText = "EstadoValor";
            EstadoValor.MinimumWidth = 6;
            EstadoValor.Name = "EstadoValor";
            EstadoValor.ReadOnly = true;
            EstadoValor.Visible = false;
            EstadoValor.Width = 125;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            Estado.Width = 80;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(20, 60);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(61, 20);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código:";
            // 
            // txtcodigo
            // 
            txtcodigo.Location = new Point(20, 76);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new Size(100, 27);
            txtcodigo.TabIndex = 1;
            // 
            // lblCodigoBarra
            // 
            lblCodigoBarra.AutoSize = true;
            lblCodigoBarra.Location = new Point(130, 60);
            lblCodigoBarra.Name = "lblCodigoBarra";
            lblCodigoBarra.Size = new Size(100, 20);
            lblCodigoBarra.TabIndex = 2;
            lblCodigoBarra.Text = "Código Barra:";
            // 
            // txtCodigoBarra
            // 
            txtCodigoBarra.Location = new Point(130, 76);
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new Size(150, 27);
            txtCodigoBarra.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 102);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre:";
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(20, 118);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(380, 27);
            txtnombre.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 144);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtdescripcion
            // 
            txtdescripcion.Location = new Point(20, 160);
            txtdescripcion.Name = "txtdescripcion";
            txtdescripcion.Size = new Size(380, 27);
            txtdescripcion.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(20, 186);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(77, 20);
            lblCategoria.TabIndex = 8;
            lblCategoria.Text = "Categoría:";
            // 
            // cbocategoria
            // 
            cbocategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbocategoria.FormattingEnabled = true;
            cbocategoria.Location = new Point(20, 202);
            cbocategoria.Name = "cbocategoria";
            cbocategoria.Size = new Size(180, 28);
            cbocategoria.TabIndex = 9;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(220, 186);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 20);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado:";
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(220, 202);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(120, 28);
            cboestado.TabIndex = 11;
            // 
            // lblPrecioCompra
            // 
            lblPrecioCompra.AutoSize = true;
            lblPrecioCompra.Location = new Point(20, 228);
            lblPrecioCompra.Name = "lblPrecioCompra";
            lblPrecioCompra.Size = new Size(110, 20);
            lblPrecioCompra.TabIndex = 12;
            lblPrecioCompra.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Location = new Point(20, 244);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(100, 27);
            txtPrecioCompra.TabIndex = 13;
            txtPrecioCompra.Text = "0";
            // 
            // lblDescuentoDistri
            // 
            lblDescuentoDistri.AutoSize = true;
            lblDescuentoDistri.Location = new Point(130, 228);
            lblDescuentoDistri.Name = "lblDescuentoDistri";
            lblDescuentoDistri.Size = new Size(121, 20);
            lblDescuentoDistri.TabIndex = 14;
            lblDescuentoDistri.Text = "Descuento Distri:";
            // 
            // txtDescuentoDistri
            // 
            txtDescuentoDistri.Location = new Point(130, 244);
            txtDescuentoDistri.Name = "txtDescuentoDistri";
            txtDescuentoDistri.Size = new Size(100, 27);
            txtDescuentoDistri.TabIndex = 15;
            txtDescuentoDistri.Text = "0";
            // 
            // lblPuntoReposicion
            // 
            lblPuntoReposicion.AutoSize = true;
            lblPuntoReposicion.Location = new Point(20, 270);
            lblPuntoReposicion.Name = "lblPuntoReposicion";
            lblPuntoReposicion.Size = new Size(127, 20);
            lblPuntoReposicion.TabIndex = 16;
            lblPuntoReposicion.Text = "Punto Reposición:";
            // 
            // txtPuntoReposicion
            // 
            txtPuntoReposicion.Location = new Point(20, 286);
            txtPuntoReposicion.Name = "txtPuntoReposicion";
            txtPuntoReposicion.Size = new Size(100, 27);
            txtPuntoReposicion.TabIndex = 17;
            // 
            // chkControlaStock
            // 
            chkControlaStock.AutoSize = true;
            chkControlaStock.Checked = true;
            chkControlaStock.CheckState = CheckState.Checked;
            chkControlaStock.Location = new Point(130, 288);
            chkControlaStock.Name = "chkControlaStock";
            chkControlaStock.Size = new Size(128, 24);
            chkControlaStock.TabIndex = 18;
            chkControlaStock.Text = "Controla Stock";
            chkControlaStock.UseVisualStyleBackColor = true;
            // 
            // btnguardar
            // 
            btnguardar.BackColor = Color.ForestGreen;
            btnguardar.ForeColor = Color.White;
            btnguardar.Location = new Point(20, 320);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(90, 30);
            btnguardar.TabIndex = 19;
            btnguardar.Text = "Guardar";
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click;
            // 
            // btnlimpiar
            // 
            btnlimpiar.BackColor = Color.RoyalBlue;
            btnlimpiar.ForeColor = Color.White;
            btnlimpiar.Location = new Point(120, 320);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(90, 30);
            btnlimpiar.TabIndex = 20;
            btnlimpiar.Text = "Limpiar";
            btnlimpiar.UseVisualStyleBackColor = false;
            btnlimpiar.Click += btnlimpiar_Click;
            // 
            // btneliminar
            // 
            btneliminar.BackColor = Color.Firebrick;
            btneliminar.ForeColor = Color.White;
            btneliminar.Location = new Point(220, 320);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(90, 30);
            btneliminar.TabIndex = 21;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
            // 
            // btnPrecios
            // 
            btnPrecios.BackColor = Color.DarkOrange;
            btnPrecios.ForeColor = Color.White;
            btnPrecios.Location = new Point(320, 320);
            btnPrecios.Name = "btnPrecios";
            btnPrecios.Size = new Size(90, 30);
            btnPrecios.TabIndex = 22;
            btnPrecios.Text = "Precios";
            btnPrecios.UseVisualStyleBackColor = false;
            btnPrecios.Click += btnPrecios_Click;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(440, 63);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(82, 20);
            lblBusqueda.TabIndex = 23;
            lblBusqueda.Text = "Buscar por:";
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(510, 60);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(120, 28);
            cbobusqueda.TabIndex = 24;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(640, 60);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.Size = new Size(200, 27);
            txtbusqueda.TabIndex = 25;
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(850, 58);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(60, 24);
            btnbuscar.TabIndex = 26;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = true;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // btnlimpiarbuscador
            // 
            btnlimpiarbuscador.Location = new Point(920, 58);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(60, 24);
            btnlimpiarbuscador.TabIndex = 27;
            btnlimpiarbuscador.Text = "Limpiar";
            btnlimpiarbuscador.UseVisualStyleBackColor = true;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
            // 
            // btnexportar
            // 
            btnexportar.BackColor = Color.SeaGreen;
            btnexportar.ForeColor = Color.White;
            btnexportar.Location = new Point(1000, 58);
            btnexportar.Name = "btnexportar";
            btnexportar.Size = new Size(80, 30);
            btnexportar.TabIndex = 28;
            btnexportar.Text = " Exportar";
            btnexportar.UseVisualStyleBackColor = false;
            btnexportar.Click += btnexportar_Click;
            // 
            // txtid
            // 
            txtid.Location = new Point(20, 20);
            txtid.Name = "txtid";
            txtid.Size = new Size(50, 27);
            txtid.TabIndex = 29;
            txtid.Text = "0";
            txtid.Visible = false;
            // 
            // txtindice
            // 
            txtindice.Location = new Point(80, 20);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(50, 27);
            txtindice.TabIndex = 30;
            txtindice.Text = "-1";
            txtindice.Visible = false;
            // 
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            ClientSize = new Size(1220, 553);
            Controls.Add(txtindice);
            Controls.Add(txtid);
            Controls.Add(btnexportar);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(btnbuscar);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(lblBusqueda);
            Controls.Add(btnPrecios);
            Controls.Add(btneliminar);
            Controls.Add(btnlimpiar);
            Controls.Add(btnguardar);
            Controls.Add(chkControlaStock);
            Controls.Add(txtPuntoReposicion);
            Controls.Add(lblPuntoReposicion);
            Controls.Add(txtDescuentoDistri);
            Controls.Add(lblDescuentoDistri);
            Controls.Add(txtPrecioCompra);
            Controls.Add(lblPrecioCompra);
            Controls.Add(cboestado);
            Controls.Add(lblEstado);
            Controls.Add(cbocategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtdescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtnombre);
            Controls.Add(lblNombre);
            Controls.Add(txtCodigoBarra);
            Controls.Add(lblCodigoBarra);
            Controls.Add(txtcodigo);
            Controls.Add(lblCodigo);
            Controls.Add(dgvdata);
            Name = "frmProducto";
            Text = "Gestión de Productos";
            Load += frmProducto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPuntoReposicion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label lblCodigoBarra;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cbocategoria;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblDescuentoDistri;
        private System.Windows.Forms.TextBox txtDescuentoDistri;
        private System.Windows.Forms.Label lblPuntoReposicion;
        private System.Windows.Forms.NumericUpDown txtPuntoReposicion;
        private System.Windows.Forms.CheckBox chkControlaStock;
        
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnPrecios;
        
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Button btnlimpiarbuscador;
        private System.Windows.Forms.Button btnexportar;
        
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtindice;
    }
}
