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
            this.grdResultado = new System.Windows.Forms.DataGridView();
            this.colHoraTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cofirmarLlegada = new System.Windows.Forms.DataGridViewButtonColumn();
            this.confimarDiagnostico = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblNombreProfesional = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // grdResultado
            // 
            this.grdResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoraTurno,
            this.nombreAfiliado,
            this.apellidoAfiliado,
            this.cofirmarLlegada,
            this.confimarDiagnostico});
            this.grdResultado.Location = new System.Drawing.Point(15, 72);
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.Size = new System.Drawing.Size(553, 282);
            this.grdResultado.TabIndex = 0;
            this.grdResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResultado_CellContentClick);
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
            // lblNombreProfesional
            // 
            this.lblNombreProfesional.AutoSize = true;
            this.lblNombreProfesional.Location = new System.Drawing.Point(12, 26);
            this.lblNombreProfesional.Name = "lblNombreProfesional";
            this.lblNombreProfesional.Size = new System.Drawing.Size(69, 13);
            this.lblNombreProfesional.TabIndex = 1;
            this.lblNombreProfesional.Text = "-aca va algo-";
            this.lblNombreProfesional.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 371);
            this.Controls.Add(this.lblNombreProfesional);
            this.Controls.Add(this.grdResultado);
            this.Name = "Form1";
            this.Text = "Registro Turnos del Día";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoAfiliado;
        private System.Windows.Forms.DataGridViewButtonColumn cofirmarLlegada;
        private System.Windows.Forms.DataGridViewButtonColumn confimarDiagnostico;
        private System.Windows.Forms.Label lblNombreProfesional;
    }
}