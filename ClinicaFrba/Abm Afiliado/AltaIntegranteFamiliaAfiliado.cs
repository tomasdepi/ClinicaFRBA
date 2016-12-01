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
using System.Text.RegularExpressions;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaIntegranteFamiliaAfiliado : Form
    {
        public AltaIntegranteFamiliaAfiliado()
        {
            InitializeComponent();
        }

        private void AltaIntegranteFamiliaAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos()) { 
            this.Afiliado = new Usuario();

            this.Afiliado.EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString();
            this.Afiliado.Apellido = this.txtApellido.Text;
            this.Afiliado.Nombre = this.txtNombre.Text;
            this.Afiliado.Direccion = this.txtDireccion.Text;
            this.Afiliado.FechaNacimiento = Convert.ToDateTime(this.dtpFechaDeNacimiento.Text);
            this.Afiliado.TipoDocumento = this.txtTipoDoc.Text;
            this.Afiliado.NroDocumento = Convert.ToInt32(this.txtNroDoc.Text);
            this.Afiliado.Sexo = this.cboSexo.SelectedItem.ToString();
            this.Afiliado.Mail = this.txtMail.Text;
            this.Afiliado.Telefono = Convert.ToInt32(this.txtTelefono.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Usuario Afiliado { get; set; }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFacNac_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarComboSexo()
        {
            this.cboSexo.Items.Add("M");
            this.cboSexo.Items.Add("F");
        }

        private void comboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private bool DatosValidos()
        {
            if(this.cboEstadoCivil.SelectedItem.ToString()== null) { return false; }
            if (!Regex.IsMatch(this.txtApellido.Text, @"^[a-zA-Z]+$")) { return false; }
            if(!Regex.IsMatch(this.txtNombre.Text, @"^[a-zA-Z]+$")) { return false; }
            if (!Regex.IsMatch(this.txtDireccion.Text, @"^[a-zA-Z]+$")) { return false; }
            if(Convert.ToDateTime(this.dtpFechaDeNacimiento.Text) == null) { return false; }
            if (!Regex.IsMatch(this.txtTipoDoc.Text, @"^[a-zA-Z]+$")) { return false; }
            if (!Regex.IsMatch(this.txtNroDoc.Text, @"^[0-9]+$")) { return false; }
            if (Convert.ToDateTime(this.cboSexo.SelectedItem.ToString()) == null) { return false; }
            if (!Regex.IsMatch(this.txtMail.Text, "^[a-zA-Z0-9]+(@)[a-zA-Z0-9]+(.com)$")) { return false; }
            if (!Regex.IsMatch(this.txtTelefono.Text, @"^[0-9]+$")) { return false; }
            return true;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
