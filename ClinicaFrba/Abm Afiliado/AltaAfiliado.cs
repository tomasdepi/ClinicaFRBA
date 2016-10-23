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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();

            service.GuardarAfiliado(new Afiliado()
            {
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                NroDocumento = Convert.ToInt32(this.txtNroDoc.Text),
                NroAfiliado = Convert.ToInt32(this.txtNroAfiliado.Text),
                TipoDocumento = this.txtTipoDoc.Text,
                FechaNacimiento = Convert.ToDateTime(this.txtFacNac.Text),
                Mail = this.txtMail.Text,
                EstadoCivil = this.txtEstadoCivil.Text,
                Direccion = this.txtDireccion.Text,
                Telefono = Convert.ToInt32(this.txtTelefono.Text),
                Sexo = this.txtSexo.Text

            });

            MessageBox.Show("El afiliado se guardo correctamente");
        }

        private void AltaAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void lblNroAfiliado_Click(object sender, EventArgs e)
        {

        }

        private void gboxDatosFundamentales_Enter(object sender, EventArgs e)
        {

        }

        private void txtTipoDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
