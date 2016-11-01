using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
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
            List<Funcionalidad> pepe = depi.getFuncionalidadesEditar(lblNombreRol.Text);

            for (int i = 0; i < pepe.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell nombre = new DataGridViewTextBoxCell();
                DataGridViewCheckBoxCell estado = new DataGridViewCheckBoxCell();
                nombre.Value = pepe[i].nombreFuncionalidad;
                estado.Value = pepe[i].habilitado ? estado.TrueValue : estado.FalseValue;

                row.Cells.Add(nombre);
                row.Cells.Add(estado);

                this.grdFuncionalidades.Rows.Add(row);
            }
        }
    }
}
