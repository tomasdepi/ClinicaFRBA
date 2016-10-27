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
            this.Afiliado.EstadoCivil = this.txtEstadoCivil.Text;
            this.Afiliado.Apellido = this.txtApellido.Text;
            this.Afiliado.Nombre = this.txtNombre.Text;
            this.Afiliado.Direccion = this.txtDireccion.Text;
            this.Afiliado.FechaNacimiento = Convert.ToDateTime(this.txtFacNac.Text);
            this.Afiliado.TipoDocumento = this.txtTipoDoc.Text;
            this.Afiliado.NroDocumento = Convert.ToInt32(this.txtNroDoc.Text);
            this.Afiliado.Sexo = this.txtSexo.Text;
            this.Afiliado.Mail = this.txtMail.Text;
            this.Afiliado.Telefono = Convert.ToInt32(this.txtTelefono.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Usuario Afiliado { get; set; }
    }
}
