namespace ClinicaFrba.Registro_Resultado
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.colHoraTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cofirmarLlegada = new System.Windows.Forms.DataGridViewButtonColumn();
            this.confimarDiagnostico = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoraTurno,
            this.nombreAfiliado,
            this.apellidoAfiliado,
            this.cofirmarLlegada,
            this.confimarDiagnostico});
            this.dataGridView1.Location = new System.Drawing.Point(15, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(553, 282);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // colHoraTurno
            // 
            this.colHoraTurno.HeaderText = "Hora Turno";
            this.colHoraTurno.Name = "colHoraTurno";
            // 
            // nombreAfiliado
            // 
            this.nombreAfiliado.HeaderText = "Nombre Afiliado";
            this.nombreAfiliado.Name = "nombreAfiliado";
            // 
            // apellidoAfiliado
            // 
            this.apellidoAfiliado.HeaderText = "Apellido Afiliado";
            this.apellidoAfiliado.Name = "apellidoAfiliado";
            // 
            // cofirmarLlegada
            // 
            this.cofirmarLlegada.HeaderText = "Cofirmar Llegada";
            this.cofirmarLlegada.Name = "cofirmarLlegada";
            this.cofirmarLlegada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cofirmarLlegada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // confimarDiagnostico
            // 
            this.confimarDiagnostico.HeaderText = "Cofirmar Diagnostico";
            this.confimarDiagnostico.Name = "confimarDiagnostico";
            this.confimarDiagnostico.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.confimarDiagnostico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Registro Turnos del Día";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoAfiliado;
        private System.Windows.Forms.DataGridViewButtonColumn cofirmarLlegada;
        private System.Windows.Forms.DataGridViewButtonColumn confimarDiagnostico;
        private System.Windows.Forms.Label label1;
    }
}