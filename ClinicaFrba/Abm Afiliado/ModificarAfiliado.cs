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
using ClinicaFrba.Service.Common;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        public ModificarAfiliado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();

            var afiliado = new Usuario()
            {
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                NroDocumento = Convert.ToInt32(this.txtNroDoc.Text),
                NroAfiliado = Convert.ToInt32(this.txtNroAfiliado.Text),
                TipoDocumento = this.txtTipoDoc.Text,
                FechaNacimiento = this.dtpFechaDeNacimiento.Value.Date,
                Mail = this.txtMail.Text,
                EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString(),
                Direccion = this.txtDireccion.Text,
                Telefono = Convert.ToInt32(this.txtTelefono.Text),
                Sexo = this.cboSexo.SelectedItem.ToString(),
                CodigoPlanMedico = Convert.ToInt32(this.cboPlanes.SelectedItem)
            };

            service.ModificarDatosDeAfiliado(new ModificarDatosDeAfiliadoRequest(){Afiliado = afiliado});

            MessageBox.Show("Se actualizaron correctamente los datos del afiliado: " + this.txtApellido + " " +
                            this.txtNombre);

        }

  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.dtpFechaDeNacimiento.Format = DateTimePickerFormat.Custom;
            this.dtpFechaDeNacimiento.CustomFormat = "dd-MM-yyyy";
        }

        private void CargarComboPlanesMedicos()
        {
            var service = new ClinicaService();

            var response = service.ObtenerListadoDePlanes();

            foreach (var descPlan in response.DescPlanes)
            {
                this.cboPlanes.Items.Add(descPlan);
            }
        }

        private void CargarComboSexo()
        {
            this.cboSexo.Items.Add("M");
            this.cboSexo.Items.Add("F");
        }

        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {
            this.ConfigurarFormatoFechaDeNacimiento();
            this.CargarComboEstadoCivil();
            this.CargarComboPlanesMedicos();
            this.CargarComboSexo();
        }

        private void CargarDetalleAfiliado()
        {
            var service = new ClinicaService();

            var response = service.CargarDetalleAfiliado(new CargarDetalleAfiliadoRequest() {NroDocumento = 15});

            this.txtNombre.Text = response.Usuario.Nombre ?? string.Empty;
            this.txtApellido.Text = response.Usuario.Apellido ?? string.Empty;
            this.txtNroDoc.Text = response.Usuario.NroDocumento.ToString();
            this.txtNroAfiliado.Text = response.Usuario.NroAfiliado.ToString();
            this.txtTipoDoc.Text = response.Usuario.TipoDocumento ?? string.Empty;
            this.dtpFechaDeNacimiento.Value = response.Usuario.FechaNacimiento;
            this.txtMail.Text = response.Usuario.Mail ?? string.Empty;
            this.cboEstadoCivil.SelectedItem = response.Usuario.EstadoCivil;
            this.txtDireccion.Text = response.Usuario.Direccion ?? string.Empty;
            this.txtTelefono.Text = response.Usuario.Telefono.ToString();
            this.cboSexo.SelectedItem = response.Usuario.Sexo;
            this.cboPlanes.SelectedItem = response.Usuario.CodigoPlanMedico;

        }
    }
}
