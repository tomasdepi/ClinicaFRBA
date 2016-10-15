namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class SeleccionarProfecional
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
            this.dataGridViewProfecionales = new System.Windows.Forms.DataGridView();
            this.columnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHorasAcumuladas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfecionales)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProfecionales
            // 
            this.dataGridViewProfecionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProfecionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNombre,
            this.columnApellido,
            this.columnHorasAcumuladas,
            this.columnButton});
            this.dataGridViewProfecionales.Location = new System.Drawing.Point(12, 29);
            this.dataGridViewProfecionales.Name = "dataGridViewProfecionales";
            this.dataGridViewProfecionales.Size = new System.Drawing.Size(445, 232);
            this.dataGridViewProfecionales.TabIndex = 0;
            this.dataGridViewProfecionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // columnNombre
            // 
            this.columnNombre.HeaderText = "Nombre";
            this.columnNombre.Name = "columnNombre";
            // 
            // columnApellido
            // 
            this.columnApellido.HeaderText = "Apellido";
            this.columnApellido.Name = "columnApellido";
            // 
            // columnHorasAcumuladas
            // 
            this.columnHorasAcumuladas.HeaderText = "Horas Acumuladas";
            this.columnHorasAcumuladas.Name = "columnHorasAcumuladas";
            // 
            // columnButton
            // 
            this.columnButton.HeaderText = "Agregar Horario";
            this.columnButton.Name = "columnButton";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(193, 279);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Vovler";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // SeleccionarProfecional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 314);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGridViewProfecionales);
            this.Name = "SeleccionarProfecional";
            this.Text = "SeleccionarProfecional";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfecionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProfecionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHorasAcumuladas;
        private System.Windows.Forms.DataGridViewButtonColumn columnButton;
        private System.Windows.Forms.Button btnVolver;
    }
}