namespace ClinicaFrba.AbmRol
{
    partial class EditarRol
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFuncionalidades = new System.Windows.Forms.Label();
            this.grdFuncionalidades = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(287, 326);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(368, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFuncionalidades
            // 
            this.lblFuncionalidades.AutoSize = true;
            this.lblFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncionalidades.Location = new System.Drawing.Point(45, 52);
            this.lblFuncionalidades.Name = "lblFuncionalidades";
            this.lblFuncionalidades.Size = new System.Drawing.Size(113, 15);
            this.lblFuncionalidades.TabIndex = 9;
            this.lblFuncionalidades.Text = "Funcionalidades";
            // 
            // grdFuncionalidades
            // 
            this.grdFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Agregar});
            this.grdFuncionalidades.Location = new System.Drawing.Point(48, 78);
            this.grdFuncionalidades.Name = "grdFuncionalidades";
            this.grdFuncionalidades.Size = new System.Drawing.Size(395, 237);
            this.grdFuncionalidades.TabIndex = 8;
            this.grdFuncionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFuncionalidades_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 250;
            // 
            // Agregar
            // 
            this.Agregar.HeaderText = "";
            this.Agregar.Name = "Agregar";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(113, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(330, 20);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(45, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 15);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre:";
            // 
            // EditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 370);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblFuncionalidades);
            this.Controls.Add(this.grdFuncionalidades);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "EditarRol";
            this.Text = "EditarRol";
            this.Load += new System.EventHandler(this.EditarRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFuncionalidades;
        private System.Windows.Forms.DataGridView grdFuncionalidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Agregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
    }
}