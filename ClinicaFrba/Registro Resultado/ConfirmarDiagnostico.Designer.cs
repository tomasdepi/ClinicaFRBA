namespace ClinicaFrba.Registro_Resultado
{
    partial class ConfirmarDiagnostico
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
            this.lblDatos = new System.Windows.Forms.Label();
            this.txtBoxDiagnostico = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Location = new System.Drawing.Point(12, 9);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(35, 13);
            this.lblDatos.TabIndex = 0;
            this.lblDatos.Text = "label1";
            this.lblDatos.Click += new System.EventHandler(this.lblDatos_Click);
            // 
            // txtBoxDiagnostico
            // 
            this.txtBoxDiagnostico.Location = new System.Drawing.Point(12, 49);
            this.txtBoxDiagnostico.Name = "txtBoxDiagnostico";
            this.txtBoxDiagnostico.Size = new System.Drawing.Size(260, 201);
            this.txtBoxDiagnostico.TabIndex = 2;
            this.txtBoxDiagnostico.Text = "";
            this.txtBoxDiagnostico.TextChanged += new System.EventHandler(this.txtBoxDiagnostico_TextChanged);
            // 
            // ConfirmarDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtBoxDiagnostico);
            this.Controls.Add(this.lblDatos);
            this.Name = "ConfirmarDiagnostico";
            this.Text = "Confirmar Diagnostico";
            this.Load += new System.EventHandler(this.ConfirmarDiagnostico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.RichTextBox txtBoxDiagnostico;
    }
}