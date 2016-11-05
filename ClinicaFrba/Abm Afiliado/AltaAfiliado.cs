using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            List<Usuario> afiliados = new List<Usuario>();

            var afiliado = new Usuario()
            {
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                NroDocumento = Convert.ToInt32(this.txtNroDoc.Text),
                NroAfiliado = Convert.ToInt32(this.txtNroAfiliado.Text),
                TipoDocumento = this.txtTipoDoc.Text,
                FechaNacimiento = Convert.ToDateTime(this.dtpFechaNacimiento.Text),
                Mail = this.txtMail.Text,
                EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString(),
                Direccion = this.txtDireccion.Text,
                Telefono = Convert.ToInt32(this.txtTelefono.Text),
                Sexo = this.txtSexo.Text

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

            MessageBox.Show("El registro del afiliado se guardo correctamente");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gboxDatosFundamentales_Enter(object sender, EventArgs e)
        {

        }

        private void AltaAfiliado_Load(object sender, EventArgs e)
        {
            this.ConfigurarFormatoFechaDeNacimiento();
            this.CargarComboEstadoCivil();
        }

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

        private void ConfigurarFormatoFechaDeNacimiento()
        {
            this.dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.CustomFormat = "dd-MM-yyyy";
        }
            
    }
}
