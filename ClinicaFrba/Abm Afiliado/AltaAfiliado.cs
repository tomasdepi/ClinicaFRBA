﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository.Entities;
using ClinicaFrba.Service;
using static System.Windows.Forms.MessageBox;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaAfiliado : Form
    {
        public AltaAfiliado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Comportamiento del botón Guardar, en el caso de que el afiliado sea casado o viva en concubinato
        /// se le ofrece la posibilidad de asociarlo, ademas permite agregar tantos miembros familiares como desee 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();
            if (DatosValidos())
            {
                int codPlan = service.GetCodigoPlanByDescripcion(this.cboPlanes.SelectedItem.ToString());

                List<Usuario> afiliados = new List<Usuario>();

                var afiliado = new Usuario()
                {
                    Nombre = this.txtNombre.Text,
                    Apellido = this.txtApellido.Text,
                    NroDocumento = Convert.ToInt32(this.txtNroDoc.Text),
                    NroAfiliado = Convert.ToInt32(this.txtNroDoc.Text),
                    TipoDocumento = this.txtTipoDoc.Text,
                    FechaNacimiento = Convert.ToDateTime(this.dtpFechaNacimiento.Value),
                    Mail = this.txtMail.Text,
                    EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString(),
                    Direccion = this.txtDireccion.Text,
                    Telefono = Convert.ToInt32(this.txtTelefono.Text),
                    Sexo = this.cboSexo.SelectedItem.ToString(),
                    CodigoPlanMedico = codPlan
                };

                afiliados.Add(afiliado);

                if (service.EsCasadoOViveEnConcubinato(afiliado))
                {
                    if ((MessageBox.Show("¿Desea afiliar a su cónyuge?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        this.AfiliarIntegranteFamilia(afiliados);
                    }
                }

                while ((MessageBox.Show("¿Desea afiliar algun otro miembro de su familia?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    this.AfiliarIntegranteFamilia(afiliados);
                }

                service.GuardarRegistroAfiliado(afiliados);

                MessageBox.Show("El registro del afiliado se guardó correctamente");
            }
            else
            {
                MessageBox.Show("Alguno de los datos ingresados no son correctos. Intente de nuevo.");
            }
        }


        /// <summary>
        /// Abre el formulario de alta de integrante familiar, luego este
        /// devuelve un objeto del tipo Usuario con las properties seteadas y lo agrega 
        /// a la lista de la familia de la afiliado en cuestión.
        /// </summary>
        /// <param name="users">Familiares del Afiliado</param>
        private void AfiliarIntegranteFamilia(List<Usuario> users)
        {
            using (var integranteFamilia = new AltaIntegranteFamiliaAfiliado())
            {
                var resultado = integranteFamilia.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    users.Add(integranteFamilia.Afiliado);
                }
            }
        }

        /// <summary>
        /// Carga inicial del formulario AltaAfiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AltaAfiliado_Load(object sender, EventArgs e)
        {
            this.ConfigurarFormatoFechaDeNacimiento();
            this.CargarComboEstadoCivil();
            this.CargarComboPlanesMedicos();
            this.CargarComboSexo();
        }


        /// <summary>
        /// Completa el combo de estado civil 
        /// </summary>
        private void CargarComboEstadoCivil()
        {
            this.cboEstadoCivil.DisplayMember = "Text";
            this.cboEstadoCivil.ValueMember = "Value";

            this.cboEstadoCivil.Items.Add("Soltero");
            this.cboEstadoCivil.Items.Add("Casado");
            this.cboEstadoCivil.Items.Add("Concubinato");
            this.cboEstadoCivil.Items.Add("Divorciado");
            this.cboEstadoCivil.Items.Add("Viudo");
        }

        /// <summary>
        /// Configura el formato de la fecha del DateTimePicker
        /// </summary>
        private void ConfigurarFormatoFechaDeNacimiento()
        {
            this.dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.CustomFormat = "dd-MM-yyyy";
        }

        /// <summary>
        /// Carga el combo de planes medicos segun los que se encuentren en la base datos
        /// </summary>
        private void CargarComboPlanesMedicos()
        {
            var service = new ClinicaService();

            var response = service.ObtenerListadoDePlanes();

            foreach (var descPlan in response.DescPlanes)
            {
                this.cboPlanes.Items.Add(descPlan);
            }
        }

        /// <summary>
        /// Carga el combo de sexo
        /// </summary>
        private void CargarComboSexo()
        {
            this.cboSexo.Items.Add("M");
            this.cboSexo.Items.Add("F");
        }

        /// <summary>
        /// Comportamiento del botón cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valida cada uno de los datos, de los TextBox del formulario
        /// </summary>
        /// <returns></returns>
        private bool DatosValidos()
        {
            if (this.cboEstadoCivil.SelectedItem.ToString() == null) { return false; }
            if (!Regex.IsMatch(this.txtApellido.Text, @"^[a-zA-Z]+$")) { return false; }
            if (!Regex.IsMatch(this.txtNombre.Text, @"^[a-zA-Z]+$")) { return false; }
            if (!Regex.IsMatch(this.txtDireccion.Text, @"^[a-zA-Z]+$")) { return false; }
            if (Convert.ToDateTime(this.dtpFechaNacimiento.Text) == null) { return false; }
            if (!Regex.IsMatch(this.txtTipoDoc.Text, @"^[a-zA-Z]+$")) { return false; }
            if (!Regex.IsMatch(this.txtNroDoc.Text, @"^[0-9]+$")) { return false; }
            if (Convert.ToDateTime(this.cboSexo.SelectedItem.ToString()) == null) { return false; }
            if (!Regex.IsMatch(this.txtMail.Text, "^[a-zA-Z0-9]+(@)[a-zA-Z0-9]+(.com)$")) { return false; }
            if (!Regex.IsMatch(this.txtTelefono.Text, @"^[0-9]+$")) { return false; }
            return true;
        }
    }
}
