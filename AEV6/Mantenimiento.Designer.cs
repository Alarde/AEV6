namespace AEV6
{
    partial class mantenimientoForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mantenimientoForm));
			this.btnSalir = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnInformes = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.dgvMantenimiento = new System.Windows.Forms.DataGridView();
			this.errorMantenimiento = new System.Windows.Forms.ErrorProvider(this.components);
			this.grpDataGrid = new System.Windows.Forms.GroupBox();
			this.btnActualizar = new System.Windows.Forms.Button();
			this.txtbuscar = new System.Windows.Forms.TextBox();
			this.lblBuscar = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.lblnif = new System.Windows.Forms.Label();
			this.txtNif = new System.Windows.Forms.TextBox();
			this.lblNombre = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblApellido = new System.Windows.Forms.Label();
			this.txtApellido = new System.Windows.Forms.TextBox();
			this.lblAdmin = new System.Windows.Forms.Label();
			this.chkAdmin = new System.Windows.Forms.CheckBox();
			this.lblClave = new System.Windows.Forms.Label();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.lblTimer = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.columnanif = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.admin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.columnaClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvMantenimiento)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorMantenimiento)).BeginInit();
			this.grpDataGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSalir
			// 
			this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnSalir.Location = new System.Drawing.Point(595, 362);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(109, 44);
			this.btnSalir.TabIndex = 0;
			this.btnSalir.Text = "Salir \r\nMantenimiento";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// btnAgregar
			// 
			this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnAgregar.Location = new System.Drawing.Point(12, 370);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(94, 36);
			this.btnAgregar.TabIndex = 1;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnEliminar.Location = new System.Drawing.Point(112, 370);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(94, 36);
			this.btnEliminar.TabIndex = 2;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// btnInformes
			// 
			this.btnInformes.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnInformes.Location = new System.Drawing.Point(607, 24);
			this.btnInformes.Name = "btnInformes";
			this.btnInformes.Size = new System.Drawing.Size(75, 23);
			this.btnInformes.TabIndex = 3;
			this.btnInformes.Text = "Informes";
			this.btnInformes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnInformes.UseVisualStyleBackColor = true;
			this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnCerrar.Location = new System.Drawing.Point(480, 362);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(109, 44);
			this.btnCerrar.TabIndex = 4;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
			// 
			// dgvMantenimiento
			// 
			this.dgvMantenimiento.AllowUserToAddRows = false;
			this.dgvMantenimiento.AllowUserToDeleteRows = false;
			this.dgvMantenimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvMantenimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMantenimiento.Location = new System.Drawing.Point(9, 53);
			this.dgvMantenimiento.Name = "dgvMantenimiento";
			this.dgvMantenimiento.ReadOnly = true;
			this.dgvMantenimiento.Size = new System.Drawing.Size(673, 196);
			this.dgvMantenimiento.TabIndex = 11;
			this.dgvMantenimiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMantenimiento_CellContentClick);
			// 
			// errorMantenimiento
			// 
			this.errorMantenimiento.ContainerControl = this;
			// 
			// grpDataGrid
			// 
			this.grpDataGrid.Controls.Add(this.btnActualizar);
			this.grpDataGrid.Controls.Add(this.txtbuscar);
			this.grpDataGrid.Controls.Add(this.lblBuscar);
			this.grpDataGrid.Controls.Add(this.btnBuscar);
			this.grpDataGrid.Controls.Add(this.dgvMantenimiento);
			this.grpDataGrid.Controls.Add(this.btnInformes);
			this.grpDataGrid.Location = new System.Drawing.Point(12, 3);
			this.grpDataGrid.Name = "grpDataGrid";
			this.grpDataGrid.Size = new System.Drawing.Size(692, 257);
			this.grpDataGrid.TabIndex = 7;
			this.grpDataGrid.TabStop = false;
			// 
			// btnActualizar
			// 
			this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnActualizar.Location = new System.Drawing.Point(400, 24);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(84, 23);
			this.btnActualizar.TabIndex = 10;
			this.btnActualizar.Text = "Actualizar";
			this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnActualizar.UseVisualStyleBackColor = true;
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			// 
			// txtbuscar
			// 
			this.txtbuscar.Font = new System.Drawing.Font("Century Gothic", 10F);
			this.txtbuscar.Location = new System.Drawing.Point(118, 24);
			this.txtbuscar.Multiline = true;
			this.txtbuscar.Name = "txtbuscar";
			this.txtbuscar.Size = new System.Drawing.Size(195, 23);
			this.txtbuscar.TabIndex = 9;
			// 
			// lblBuscar
			// 
			this.lblBuscar.AutoSize = true;
			this.lblBuscar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBuscar.Location = new System.Drawing.Point(4, 26);
			this.lblBuscar.Name = "lblBuscar";
			this.lblBuscar.Size = new System.Drawing.Size(114, 20);
			this.lblBuscar.TabIndex = 8;
			this.lblBuscar.Text = "Buscar por NIF";
			// 
			// btnBuscar
			// 
			this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
			this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(319, 23);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(56, 24);
			this.btnBuscar.TabIndex = 7;
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.UseVisualStyleBackColor = false;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// lblnif
			// 
			this.lblnif.AutoSize = true;
			this.lblnif.Font = new System.Drawing.Font("Century Gothic", 11F);
			this.lblnif.Location = new System.Drawing.Point(37, 266);
			this.lblnif.Name = "lblnif";
			this.lblnif.Size = new System.Drawing.Size(36, 20);
			this.lblnif.TabIndex = 0;
			this.lblnif.Text = "NIF:";
			// 
			// txtNif
			// 
			this.txtNif.Font = new System.Drawing.Font("Century Gothic", 10F);
			this.txtNif.Location = new System.Drawing.Point(120, 267);
			this.txtNif.Multiline = true;
			this.txtNif.Name = "txtNif";
			this.txtNif.Size = new System.Drawing.Size(195, 23);
			this.txtNif.TabIndex = 6;
			this.txtNif.TextChanged += new System.EventHandler(this.TxtNif_TextChanged);
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11F);
			this.lblNombre.Location = new System.Drawing.Point(37, 300);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(72, 20);
			this.lblNombre.TabIndex = 7;
			this.lblNombre.Text = "Nombre:";
			// 
			// txtNombre
			// 
			this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 10F);
			this.txtNombre.Location = new System.Drawing.Point(120, 299);
			this.txtNombre.Multiline = true;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(195, 23);
			this.txtNombre.TabIndex = 8;
			// 
			// lblApellido
			// 
			this.lblApellido.AutoSize = true;
			this.lblApellido.Font = new System.Drawing.Font("Century Gothic", 11F);
			this.lblApellido.Location = new System.Drawing.Point(37, 334);
			this.lblApellido.Name = "lblApellido";
			this.lblApellido.Size = new System.Drawing.Size(73, 20);
			this.lblApellido.TabIndex = 9;
			this.lblApellido.Text = "Apellido:";
			// 
			// txtApellido
			// 
			this.txtApellido.Font = new System.Drawing.Font("Century Gothic", 10F);
			this.txtApellido.Location = new System.Drawing.Point(120, 334);
			this.txtApellido.Multiline = true;
			this.txtApellido.Name = "txtApellido";
			this.txtApellido.Size = new System.Drawing.Size(195, 23);
			this.txtApellido.TabIndex = 10;
			// 
			// lblAdmin
			// 
			this.lblAdmin.AutoSize = true;
			this.lblAdmin.Font = new System.Drawing.Font("Century Gothic", 11F);
			this.lblAdmin.Location = new System.Drawing.Point(347, 266);
			this.lblAdmin.Name = "lblAdmin";
			this.lblAdmin.Size = new System.Drawing.Size(59, 20);
			this.lblAdmin.TabIndex = 11;
			this.lblAdmin.Text = "Admin:";
			this.lblAdmin.Click += new System.EventHandler(this.lblAdmin_Click);
			// 
			// chkAdmin
			// 
			this.chkAdmin.AutoSize = true;
			this.chkAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAdmin.Location = new System.Drawing.Point(412, 267);
			this.chkAdmin.Name = "chkAdmin";
			this.chkAdmin.Size = new System.Drawing.Size(40, 22);
			this.chkAdmin.TabIndex = 13;
			this.chkAdmin.Text = "Sí";
			this.chkAdmin.UseVisualStyleBackColor = true;
			this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
			// 
			// lblClave
			// 
			this.lblClave.AutoSize = true;
			this.lblClave.Font = new System.Drawing.Font("Century Gothic", 11F);
			this.lblClave.Location = new System.Drawing.Point(347, 302);
			this.lblClave.Name = "lblClave";
			this.lblClave.Size = new System.Drawing.Size(58, 20);
			this.lblClave.TabIndex = 14;
			this.lblClave.Text = "Clave:";
			// 
			// txtClave
			// 
			this.txtClave.Font = new System.Drawing.Font("Century Gothic", 10F);
			this.txtClave.Location = new System.Drawing.Point(412, 300);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(138, 24);
			this.txtClave.TabIndex = 15;
			// 
			// lblTimer
			// 
			this.lblTimer.AutoSize = true;
			this.lblTimer.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimer.Location = new System.Drawing.Point(602, 273);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new System.Drawing.Size(86, 23);
			this.lblTimer.TabIndex = 16;
			this.lblTimer.Text = "00:00:00";
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(586, 295);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(59, 23);
			this.lblDate.TabIndex = 17;
			this.lblDate.Text = "Date";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// columnanif
			// 
			this.columnanif.Name = "columnanif";
			// 
			// nombre
			// 
			this.nombre.Name = "nombre";
			// 
			// apellido
			// 
			this.apellido.Name = "apellido";
			// 
			// admin
			// 
			this.admin.Name = "admin";
			// 
			// columnaClave
			// 
			this.columnaClave.Name = "columnaClave";
			// 
			// mantenimientoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 418);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblTimer);
			this.Controls.Add(this.txtApellido);
			this.Controls.Add(this.chkAdmin);
			this.Controls.Add(this.lblApellido);
			this.Controls.Add(this.lblAdmin);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.txtClave);
			this.Controls.Add(this.lblNombre);
			this.Controls.Add(this.lblClave);
			this.Controls.Add(this.txtNif);
			this.Controls.Add(this.lblnif);
			this.Controls.Add(this.grpDataGrid);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.btnSalir);
			this.Name = "mantenimientoForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mantenimiento";
			this.Load += new System.EventHandler(this.Mantenimiento_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvMantenimiento)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorMantenimiento)).EndInit();
			this.grpDataGrid.ResumeLayout(false);
			this.grpDataGrid.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvMantenimiento;
        private System.Windows.Forms.ErrorProvider errorMantenimiento;
		private System.Windows.Forms.GroupBox grpDataGrid;
		private System.Windows.Forms.TextBox txtbuscar;
		private System.Windows.Forms.Label lblBuscar;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Button btnActualizar;
		private System.Windows.Forms.TextBox txtApellido;
		private System.Windows.Forms.CheckBox chkAdmin;
		private System.Windows.Forms.Label lblApellido;
		private System.Windows.Forms.Label lblAdmin;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblClave;
		private System.Windows.Forms.TextBox txtNif;
		private System.Windows.Forms.Label lblnif;
		private System.Windows.Forms.Label lblTimer;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnanif;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewCheckBoxColumn admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaClave;
    }
}