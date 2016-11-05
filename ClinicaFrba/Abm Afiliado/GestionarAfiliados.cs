using ClinicaFrba.Service;
using ClinicaFrba.Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class GestionarAfiliados : Form
    {
        public GestionarAfiliados()
        {
            InitializeComponent();
        }

        private void grdAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gboxFiltrosBusqueda_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Comportamiento del botón Buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();

            var response = service.CargarGrillaAfiliados(new CargarGrillaAfiliadoRequest()
            {
                Apellido = (string.IsNullOrEmpty(this.txtApellido.Text)) ? string.Empty : this.txtApellido.Text,
                Nombre = (string.IsNullOrEmpty(this.txtNombre.Text)) ? string.Empty : this.txtNombre.Text,
                EstadoActual = (cboEstadoActual.SelectedItem.ToString() == "Habilitado") ? true : false,
                DescripcionPlan = string.IsNullOrEmpty(this.cboPlanes.SelectedItem.ToString()) ?  string.Empty : this.cboPlanes.SelectedItem.ToString()
            });

            // Agregar TODOS los atributos a la grdAfiliados en la UI para que funcione
            var source = new BindingSource();
            source.DataSource = response.Usuarios;
            this.grdAfiliados.DataSource = source;

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

        private void CargarComboEstadoActual()
        {
            this.cboEstadoActual.Items.Add("Habilitado");
            this.cboEstadoActual.Items.Add("Deshabilitado");
        }

        private void GestionarAfiliados_Load(object sender, EventArgs e)
        {
            this.CargarComboPlanesMedicos();
            this.CargarComboEstadoActual();
        }
    }
}
