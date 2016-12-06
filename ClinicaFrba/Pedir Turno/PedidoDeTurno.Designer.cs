namespace ClinicaFrba.Pedir_Turno
{
    partial class PedidoDeTurno
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
            this.gridProfesionales = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgenda = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cBoxEspecilidad = new System.Windows.Forms.ComboBox();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.txBoxNumeroAfiliado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProfesionales
            // 
            this.gridProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Especialidad,
            this.btnAgenda});
            this.gridProfesionales.Location = new System.Drawing.Point(12, 102);
            this.gridProfesionales.Name = "gridProfesionales";
            this.gridProfesionales.Size = new System.Drawing.Size(444, 148);
            this.gridProfesionales.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            // 
            // btnAgenda
            // 
            this.btnAgenda.HeaderText = "Agenda";
            this.btnAgenda.Name = "btnAgenda";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(8, 58);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(120, 13);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "Especialidad buscada : ";
            this.lblEspecialidad.Click += new System.EventHandler(this.lblEspecialidad_Click);
            // 
            // cBoxEspecilidad
            // 
            this.cBoxEspecilidad.FormattingEnabled = true;
            this.cBoxEspecilidad.Location = new System.Drawing.Point(134, 55);
            this.cBoxEspecilidad.Name = "cBoxEspecilidad";
            this.cBoxEspecilidad.Size = new System.Drawing.Size(121, 21);
            this.cBoxEspecilidad.TabIndex = 2;
            this.cBoxEspecilidad.TextChanged += new System.EventHandler(this.cBoxEspecilidad_TextChanged);
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(25, 15);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(99, 13);
            this.lblNumeroAfiliado.TabIndex = 5;
            this.lblNumeroAfiliado.Text = "Número de Afiliado:";
            // 
            // txBoxNumeroAfiliado
            // 
            this.txBoxNumeroAfiliado.Location = new System.Drawing.Point(134, 12);
            this.txBoxNumeroAfiliado.Name = "txBoxNumeroAfiliado";
            this.txBoxNumeroAfiliado.Size = new System.Drawing.Size(100, 20);
            this.txBoxNumeroAfiliado.TabIndex = 6;
            // 
            // PedidoDeTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 275);
            this.Controls.Add(this.txBoxNumeroAfiliado);
            this.Controls.Add(this.lblNumeroAfiliado);
            this.Controls.Add(this.cBoxEspecilidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.gridProfesionales);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "PedidoDeTurno";
            this.Text = "Pedido de Turno";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewButtonColumn btnAgenda;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cBoxEspecilidad;
        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.TextBox txBoxNumeroAfiliado;

    }
}