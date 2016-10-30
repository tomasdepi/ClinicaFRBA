﻿namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaAfiliado
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gboxDatosAdicionales = new System.Windows.Forms.GroupBox();
            this.btnSeleccinarPlan = new System.Windows.Forms.Button();
            this.txtPlanMedico = new System.Windows.Forms.TextBox();
            this.txtEstadoCivil = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblPlanMedico = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.gboxDatosFundamentales = new System.Windows.Forms.GroupBox();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.txtFacNac = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lvlSexo = new System.Windows.Forms.Label();
            this.lblFecNac = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.gboxDatosAdicionales.SuspendLayout();
            this.gboxDatosFundamentales.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(437, 433);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(356, 433);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gboxDatosAdicionales
            // 
            this.gboxDatosAdicionales.Controls.Add(this.btnSeleccinarPlan);
            this.gboxDatosAdicionales.Controls.Add(this.txtPlanMedico);
            this.gboxDatosAdicionales.Controls.Add(this.txtEstadoCivil);
            this.gboxDatosAdicionales.Controls.Add(this.txtMail);
            this.gboxDatosAdicionales.Controls.Add(this.txtTelefono);
            this.gboxDatosAdicionales.Controls.Add(this.txtDireccion);
            this.gboxDatosAdicionales.Controls.Add(this.lblPlanMedico);
            this.gboxDatosAdicionales.Controls.Add(this.lblEstadoCivil);
            this.gboxDatosAdicionales.Controls.Add(this.lblMail);
            this.gboxDatosAdicionales.Controls.Add(this.lblDireccion);
            this.gboxDatosAdicionales.Controls.Add(this.lblTelefono);
            this.gboxDatosAdicionales.Location = new System.Drawing.Point(21, 251);
            this.gboxDatosAdicionales.Name = "gboxDatosAdicionales";
            this.gboxDatosAdicionales.Size = new System.Drawing.Size(491, 165);
            this.gboxDatosAdicionales.TabIndex = 11;
            this.gboxDatosAdicionales.TabStop = false;
            this.gboxDatosAdicionales.Text = "Datos Adicionales";
            // 
            // btnSeleccinarPlan
            // 
            this.btnSeleccinarPlan.Location = new System.Drawing.Point(282, 126);
            this.btnSeleccinarPlan.Name = "btnSeleccinarPlan";
            this.btnSeleccinarPlan.Size = new System.Drawing.Size(120, 23);
            this.btnSeleccinarPlan.TabIndex = 15;
            this.btnSeleccinarPlan.Text = "Seleccionar Plan";
            this.btnSeleccinarPlan.UseVisualStyleBackColor = true;
            // 
            // txtPlanMedico
            // 
            this.txtPlanMedico.Location = new System.Drawing.Point(126, 126);
            this.txtPlanMedico.Name = "txtPlanMedico";
            this.txtPlanMedico.Size = new System.Drawing.Size(149, 20);
            this.txtPlanMedico.TabIndex = 13;
            // 
            // txtEstadoCivil
            // 
            this.txtEstadoCivil.Location = new System.Drawing.Point(126, 100);
            this.txtEstadoCivil.Name = "txtEstadoCivil";
            this.txtEstadoCivil.Size = new System.Drawing.Size(149, 20);
            this.txtEstadoCivil.TabIndex = 12;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(126, 75);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(149, 20);
            this.txtMail.TabIndex = 11;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(126, 49);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(149, 20);
            this.txtTelefono.TabIndex = 10;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(126, 22);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(149, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // lblPlanMedico
            // 
            this.lblPlanMedico.AutoSize = true;
            this.lblPlanMedico.Location = new System.Drawing.Point(51, 129);
            this.lblPlanMedico.Name = "lblPlanMedico";
            this.lblPlanMedico.Size = new System.Drawing.Size(69, 13);
            this.lblPlanMedico.TabIndex = 8;
            this.lblPlanMedico.Text = "Plan Medico:";
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Location = new System.Drawing.Point(52, 103);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.lblEstadoCivil.TabIndex = 8;
            this.lblEstadoCivil.Text = "Estado Civil:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(86, 78);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 8;
            this.lblMail.Text = "Mail:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(65, 25);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(65, 52);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Telefono:";
            // 
            // gboxDatosFundamentales
            // 
            this.gboxDatosFundamentales.Controls.Add(this.txtSexo);
            this.gboxDatosFundamentales.Controls.Add(this.txtFacNac);
            this.gboxDatosFundamentales.Controls.Add(this.txtNroDoc);
            this.gboxDatosFundamentales.Controls.Add(this.txtTipoDoc);
            this.gboxDatosFundamentales.Controls.Add(this.txtApellido);
            this.gboxDatosFundamentales.Controls.Add(this.txtNombre);
            this.gboxDatosFundamentales.Controls.Add(this.lvlSexo);
            this.gboxDatosFundamentales.Controls.Add(this.lblFecNac);
            this.gboxDatosFundamentales.Controls.Add(this.lblNombre);
            this.gboxDatosFundamentales.Controls.Add(this.lblApellido);
            this.gboxDatosFundamentales.Controls.Add(this.lblNroDoc);
            this.gboxDatosFundamentales.Controls.Add(this.lblTipoDoc);
            this.gboxDatosFundamentales.Location = new System.Drawing.Point(21, 21);
            this.gboxDatosFundamentales.Name = "gboxDatosFundamentales";
            this.gboxDatosFundamentales.Size = new System.Drawing.Size(491, 224);
            this.gboxDatosFundamentales.TabIndex = 10;
            this.gboxDatosFundamentales.TabStop = false;
            this.gboxDatosFundamentales.Text = "Datos Fundamentales";
            this.gboxDatosFundamentales.Enter += new System.EventHandler(this.gboxDatosFundamentales_Enter);
            // 
            // txtSexo
            // 
            this.txtSexo.Location = new System.Drawing.Point(126, 168);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(149, 20);
            this.txtSexo.TabIndex = 15;
            // 
            // txtFacNac
            // 
            this.txtFacNac.Location = new System.Drawing.Point(126, 142);
            this.txtFacNac.Name = "txtFacNac";
            this.txtFacNac.Size = new System.Drawing.Size(149, 20);
            this.txtFacNac.TabIndex = 14;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(126, 116);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(149, 20);
            this.txtNroDoc.TabIndex = 13;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(126, 90);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(149, 20);
            this.txtTipoDoc.TabIndex = 12;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(126, 64);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(149, 20);
            this.txtApellido.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(126, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(149, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // lvlSexo
            // 
            this.lvlSexo.AutoSize = true;
            this.lvlSexo.Location = new System.Drawing.Point(86, 168);
            this.lvlSexo.Name = "lvlSexo";
            this.lvlSexo.Size = new System.Drawing.Size(34, 13);
            this.lvlSexo.TabIndex = 8;
            this.lvlSexo.Text = "Sexo:";
            // 
            // lblFecNac
            // 
            this.lblFecNac.AutoSize = true;
            this.lblFecNac.Location = new System.Drawing.Point(24, 143);
            this.lblFecNac.Name = "lblFecNac";
            this.lblFecNac.Size = new System.Drawing.Size(96, 13);
            this.lblFecNac.TabIndex = 7;
            this.lblFecNac.Text = "Fecha Nacimiento:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(73, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(73, 67);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(35, 119);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(85, 13);
            this.lblNroDoc.TabIndex = 3;
            this.lblNroDoc.Text = "Nro Documento:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(31, 93);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDoc.TabIndex = 2;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // AltaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 487);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gboxDatosAdicionales);
            this.Controls.Add(this.gboxDatosFundamentales);
            this.Name = "AltaAfiliado";
            this.Text = "AltaAfiliado";
            this.gboxDatosAdicionales.ResumeLayout(false);
            this.gboxDatosAdicionales.PerformLayout();
            this.gboxDatosFundamentales.ResumeLayout(false);
            this.gboxDatosFundamentales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gboxDatosAdicionales;
        private System.Windows.Forms.Button btnSeleccinarPlan;
        private System.Windows.Forms.TextBox txtPlanMedico;
        private System.Windows.Forms.TextBox txtEstadoCivil;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblPlanMedico;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.GroupBox gboxDatosFundamentales;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.TextBox txtFacNac;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lvlSexo;
        private System.Windows.Forms.Label lblFecNac;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
    }
}