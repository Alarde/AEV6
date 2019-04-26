namespace AEV6
{
    partial class Presencia
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
            this.dgvPresencia = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaentrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMostrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresencia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPresencia
            // 
            this.dgvPresencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.apellidos,
            this.horaentrada});
            this.dgvPresencia.Location = new System.Drawing.Point(124, 74);
            this.dgvPresencia.Name = "dgvPresencia";
            this.dgvPresencia.Size = new System.Drawing.Size(473, 254);
            this.dgvPresencia.TabIndex = 0;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 150;
            // 
            // apellidos
            // 
            this.apellidos.HeaderText = "Apellidos";
            this.apellidos.Name = "apellidos";
            this.apellidos.Width = 150;
            // 
            // horaentrada
            // 
            this.horaentrada.HeaderText = "Hora Entrada";
            this.horaentrada.Name = "horaentrada";
            this.horaentrada.Width = 130;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(512, 379);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 1;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // Presencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 438);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.dgvPresencia);
            this.Name = "Presencia";
            this.Text = "Presencia";
            this.Load += new System.EventHandler(this.Presencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPresencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaentrada;
        private System.Windows.Forms.Button btnMostrar;
    }
}