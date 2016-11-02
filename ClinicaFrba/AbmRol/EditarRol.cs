using ClinicaFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class EditarRol : Form
    {
        public EditarRol(String nombreRol, int estado)
        {
            InitializeComponent();
            lblNombreRol.Text = nombreRol;
            cbEstado.Items.Add("Habilitado");
            cbEstado.Items.Add("Deshabilitado");
            cbEstado.SelectedIndex = estado;

            this.CargarListaFuncionalidades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void grdFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditarRol_Load(object sender, EventArgs e)
        {

        }

        private void CargarListaFuncionalidades()
        {
            ABMRolesFunciones depi = new ABMRolesFunciones();
            List<String> pepe = depi.getFuncionalidades();

            for (int i = 0; i < pepe.Count; i++)
            {
                this.grdFuncionalidades.Rows.Add(pepe[i]);
            }
        }
    }
}
