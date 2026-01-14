namespace CapaPresentacion
{
    partial class frmCategoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEliminarC = new FontAwesome.Sharp.IconButton();
            this.btnLimiparC = new FontAwesome.Sharp.IconButton();
            this.btnGuardarc = new FontAwesome.Sharp.IconButton();
            this.txtcategorias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlimpiarbuscadorC = new FontAwesome.Sharp.IconButton();
            this.btnbuscarc = new FontAwesome.Sharp.IconButton();
            this.txtNombrec = new System.Windows.Forms.TextBox();
            this.cmbBuscarc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstadoC = new System.Windows.Forms.ComboBox();
            this.txtIndicec = new System.Windows.Forms.TextBox();
            this.txtIdC = new System.Windows.Forms.TextBox();
            this.btnseleccionarc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbuscar
            // 
            this.btnbuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.Black;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(32697, 905);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(1680, 425);
            this.btnbuscar.TabIndex = 53;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Descripcion,
            this.EstadoValor,
            this.Estado});
            this.dgvdata.Location = new System.Drawing.Point(11040, 2012);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersWidth = 102;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(33640, 6905);
            this.dgvdata.TabIndex = 47;
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
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 12;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 150;
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
            this.btnlimpiarbuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 18;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(32697, 905);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(1680, 425);
            this.btnlimpiarbuscador.TabIndex = 54;
            this.btnlimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbusqueda.Location = new System.Drawing.Point(32697, 942);
            this.txtbusqueda.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(5924, 38);
            this.txtbusqueda.TabIndex = 52;
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(29200, 923);
            this.cbobusqueda.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(4484, 39);
            this.cbobusqueda.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(26520, 997);
            this.label11.Margin = new System.Windows.Forms.Padding(120, 0, 120, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 32);
            this.label11.TabIndex = 50;
            this.label11.Text = "Buscar por:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(7360, 812);
            this.txtid.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(844, 38);
            this.txtid.TabIndex = 49;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11040, 609);
            this.label10.Margin = new System.Windows.Forms.Padding(120, 0, 120, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(33562, 1017);
            this.label10.TabIndex = 48;
            this.label10.Text = "Lista de Categorias:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtindice
            // 
            this.txtindice.Location = new System.Drawing.Point(6120, 812);
            this.txtindice.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(844, 38);
            this.txtindice.TabIndex = 55;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
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
            this.btneliminar.Location = new System.Drawing.Point(1280, 3895);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(7680, 425);
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
            this.btnlimpiar.Location = new System.Drawing.Point(1280, 3360);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(7680, 425);
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
            this.btnguardar.Location = new System.Drawing.Point(1280, 2825);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(7680, 425);
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
            this.label8.Location = new System.Drawing.Point(1160, 1809);
            this.label8.Margin = new System.Windows.Forms.Padding(120, 0, 120, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 32);
            this.label8.TabIndex = 42;
            this.label8.Text = "Estado:";
            // 
            // cboestado
            // 
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(1280, 2105);
            this.cboestado.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(7524, 39);
            this.cboestado.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(727, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(2239, 133);
            this.label2.TabIndex = 58;
            this.label2.Text = "Lista de Categorías:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCategoria
            // 
            this.dgvCategoria.AllowUserToAddRows = false;
            this.dgvCategoria.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionarc,
            this.idcategoria,
            this.CategoriaD,
            this.Estadoc,
            this.EstadoValorC});
            this.dgvCategoria.Location = new System.Drawing.Point(727, 232);
            this.dgvCategoria.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgvCategoria.MultiSelect = false;
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.ReadOnly = true;
            this.dgvCategoria.RowHeadersWidth = 102;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCategoria.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCategoria.RowTemplate.Height = 28;
            this.dgvCategoria.Size = new System.Drawing.Size(2243, 887);
            this.dgvCategoria.TabIndex = 57;
            this.dgvCategoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategoria_CellContentClick);
            this.dgvCategoria.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCategoria_CellPainting);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(693, 2108);
            this.label3.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(73, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(437, 58);
            this.label9.TabIndex = 59;
            this.label9.Text = "Detalle Categorías";
            // 
            // btnEliminarC
            // 
            this.btnEliminarC.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarC.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarC.ForeColor = System.Drawing.Color.White;
            this.btnEliminarC.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminarC.IconColor = System.Drawing.Color.White;
            this.btnEliminarC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarC.IconSize = 16;
            this.btnEliminarC.Location = new System.Drawing.Point(83, 596);
            this.btnEliminarC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnEliminarC.Name = "btnEliminarC";
            this.btnEliminarC.Size = new System.Drawing.Size(512, 55);
            this.btnEliminarC.TabIndex = 62;
            this.btnEliminarC.Text = "Eliminar";
            this.btnEliminarC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarC.UseVisualStyleBackColor = false;
            // 
            // btnLimiparC
            // 
            this.btnLimiparC.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLimiparC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimiparC.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimiparC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimiparC.ForeColor = System.Drawing.Color.White;
            this.btnLimiparC.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimiparC.IconColor = System.Drawing.Color.White;
            this.btnLimiparC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimiparC.IconSize = 18;
            this.btnLimiparC.Location = new System.Drawing.Point(83, 527);
            this.btnLimiparC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnLimiparC.Name = "btnLimiparC";
            this.btnLimiparC.Size = new System.Drawing.Size(512, 55);
            this.btnLimiparC.TabIndex = 61;
            this.btnLimiparC.Text = "Limpiar";
            this.btnLimiparC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimiparC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimiparC.UseVisualStyleBackColor = false;
            // 
            // btnGuardarc
            // 
            this.btnGuardarc.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardarc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardarc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarc.ForeColor = System.Drawing.Color.White;
            this.btnGuardarc.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardarc.IconColor = System.Drawing.Color.White;
            this.btnGuardarc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardarc.IconSize = 16;
            this.btnGuardarc.Location = new System.Drawing.Point(83, 458);
            this.btnGuardarc.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGuardarc.Name = "btnGuardarc";
            this.btnGuardarc.Size = new System.Drawing.Size(512, 55);
            this.btnGuardarc.TabIndex = 60;
            this.btnGuardarc.Text = "Guardar";
            this.btnGuardarc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarc.UseVisualStyleBackColor = false;
            this.btnGuardarc.Click += new System.EventHandler(this.btnGuardarc_Click);
            // 
            // txtcategorias
            // 
            this.txtcategorias.Location = new System.Drawing.Point(99, 269);
            this.txtcategorias.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtcategorias.Name = "txtcategorias";
            this.txtcategorias.Size = new System.Drawing.Size(505, 38);
            this.txtcategorias.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 32);
            this.label1.TabIndex = 63;
            this.label1.Text = "Categorias productos:";
            // 
            // btnlimpiarbuscadorC
            // 
            this.btnlimpiarbuscadorC.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscadorC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscadorC.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscadorC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscadorC.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscadorC.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscadorC.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscadorC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscadorC.IconSize = 18;
            this.btnlimpiarbuscadorC.Location = new System.Drawing.Point(2483, 102);
            this.btnlimpiarbuscadorC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnlimpiarbuscadorC.Name = "btnlimpiarbuscadorC";
            this.btnlimpiarbuscadorC.Size = new System.Drawing.Size(112, 55);
            this.btnlimpiarbuscadorC.TabIndex = 69;
            this.btnlimpiarbuscadorC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscadorC.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscadorC.Click += new System.EventHandler(this.btnlimpiarbuscadorC_Click);
            // 
            // btnbuscarc
            // 
            this.btnbuscarc.BackColor = System.Drawing.Color.White;
            this.btnbuscarc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscarc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarc.ForeColor = System.Drawing.Color.Black;
            this.btnbuscarc.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnbuscarc.IconColor = System.Drawing.Color.Black;
            this.btnbuscarc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarc.IconSize = 16;
            this.btnbuscarc.Location = new System.Drawing.Point(2355, 102);
            this.btnbuscarc.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnbuscarc.Name = "btnbuscarc";
            this.btnbuscarc.Size = new System.Drawing.Size(112, 55);
            this.btnbuscarc.TabIndex = 68;
            this.btnbuscarc.UseVisualStyleBackColor = false;
            this.btnbuscarc.Click += new System.EventHandler(this.btnbuscarc_Click);
            // 
            // txtNombrec
            // 
            this.txtNombrec.Location = new System.Drawing.Point(1928, 107);
            this.txtNombrec.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtNombrec.Name = "txtNombrec";
            this.txtNombrec.Size = new System.Drawing.Size(399, 38);
            this.txtNombrec.TabIndex = 67;
            // 
            // cmbBuscarc
            // 
            this.cmbBuscarc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarc.FormattingEnabled = true;
            this.cmbBuscarc.Location = new System.Drawing.Point(1603, 104);
            this.cmbBuscarc.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbBuscarc.Name = "cmbBuscarc";
            this.cmbBuscarc.Size = new System.Drawing.Size(303, 39);
            this.cmbBuscarc.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1424, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 32);
            this.label4.TabIndex = 65;
            this.label4.Text = "Buscar por:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(91, 347);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 32);
            this.label5.TabIndex = 71;
            this.label5.Text = "Estado:";
            // 
            // cmbEstadoC
            // 
            this.cmbEstadoC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoC.FormattingEnabled = true;
            this.cmbEstadoC.Location = new System.Drawing.Point(99, 386);
            this.cmbEstadoC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbEstadoC.Name = "cmbEstadoC";
            this.cmbEstadoC.Size = new System.Drawing.Size(505, 39);
            this.cmbEstadoC.TabIndex = 70;
            // 
            // txtIndicec
            // 
            this.txtIndicec.Location = new System.Drawing.Point(492, 147);
            this.txtIndicec.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIndicec.Name = "txtIndicec";
            this.txtIndicec.Size = new System.Drawing.Size(60, 38);
            this.txtIndicec.TabIndex = 73;
            this.txtIndicec.Text = "-1";
            this.txtIndicec.Visible = false;
            // 
            // txtIdC
            // 
            this.txtIdC.Location = new System.Drawing.Point(575, 147);
            this.txtIdC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIdC.Name = "txtIdC";
            this.txtIdC.Size = new System.Drawing.Size(60, 38);
            this.txtIdC.TabIndex = 72;
            this.txtIdC.Text = "0";
            this.txtIdC.Visible = false;
            // 
            // btnseleccionarc
            // 
            this.btnseleccionarc.HeaderText = "";
            this.btnseleccionarc.MinimumWidth = 12;
            this.btnseleccionarc.Name = "btnseleccionarc";
            this.btnseleccionarc.ReadOnly = true;
            this.btnseleccionarc.Width = 30;
            // 
            // idcategoria
            // 
            this.idcategoria.HeaderText = "IdCategoria";
            this.idcategoria.MinimumWidth = 12;
            this.idcategoria.Name = "idcategoria";
            this.idcategoria.ReadOnly = true;
            this.idcategoria.Width = 250;
            // 
            // CategoriaD
            // 
            this.CategoriaD.HeaderText = "Categoria";
            this.CategoriaD.MinimumWidth = 12;
            this.CategoriaD.Name = "CategoriaD";
            this.CategoriaD.ReadOnly = true;
            this.CategoriaD.Width = 150;
            // 
            // Estadoc
            // 
            this.Estadoc.HeaderText = "Estado";
            this.Estadoc.MinimumWidth = 12;
            this.Estadoc.Name = "Estadoc";
            this.Estadoc.ReadOnly = true;
            this.Estadoc.Width = 250;
            // 
            // EstadoValorC
            // 
            this.EstadoValorC.HeaderText = "EstadoValorC";
            this.EstadoValorC.MinimumWidth = 12;
            this.EstadoValorC.Name = "EstadoValorC";
            this.EstadoValorC.ReadOnly = true;
            this.EstadoValorC.Visible = false;
            this.EstadoValorC.Width = 250;
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(3844, 2108);
            this.Controls.Add(this.txtIndicec);
            this.Controls.Add(this.txtIdC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEstadoC);
            this.Controls.Add(this.btnlimpiarbuscadorC);
            this.Controls.Add(this.btnbuscarc);
            this.Controls.Add(this.txtNombrec);
            this.Controls.Add(this.cmbBuscarc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcategorias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarC);
            this.Controls.Add(this.btnLimiparC);
            this.Controls.Add(this.btnGuardarc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCategoria);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(120, 55, 120, 55);
            this.Name = "frmCategoria";
            this.Text = "frmCategoria";
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
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
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnguardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btnEliminarC;
        private FontAwesome.Sharp.IconButton btnLimiparC;
        private FontAwesome.Sharp.IconButton btnGuardarc;
        private System.Windows.Forms.TextBox txtcategorias;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscadorC;
        private FontAwesome.Sharp.IconButton btnbuscarc;
        private System.Windows.Forms.TextBox txtNombrec;
        private System.Windows.Forms.ComboBox cmbBuscarc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEstadoC;
        private System.Windows.Forms.TextBox txtIndicec;
        private System.Windows.Forms.TextBox txtIdC;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionarc;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValorC;
    }
}