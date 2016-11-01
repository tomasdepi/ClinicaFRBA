using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository;

namespace ClinicaFrba.AbmRol
{
    public partial class AgregarRol : Form
    {
        public AgregarRol()
        {
            InitializeComponent();
        }

        private void AgregarRol_Load(object sender, EventArgs e)
        {
            var lstFuncionalidades = new List<string>();
            CargarListaFuncionalidades();
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Carga la grdFuncionalidades con las funcionalidades fijas que tiene el sistema
        /// </summary>
        private void CargarListaFuncionalidades()
        {
            ABMRolesFunciones depi = new ABMRolesFunciones();
            List<String> pepe = depi.getFuncionalidades();

            for(int i=0; i < pepe.Count; i++)
            {
                this.grdFuncionalidades.Rows.Add(pepe[i]);
            }
        }

        /// <summary>
        /// Cierra la ventana descartando los cambios y vuelve a gestionar Roles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Se insertan los datos correspondientes en las tablas de Roles y Funcionalidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<String> funcionalidades = new List<string>();
            var funcionalidadesSeleccionadas = grdFuncionalidades.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToBoolean(row.Cells["Agregar"].Value) == true).ToList();

            funcionalidadesSeleccionadas.ForEach(row => funcionalidades.Add(row.Cells[0].Value.ToString()));
            ABMRolesFunciones depi = new ABMRolesFunciones();
            depi.guardarRol(txtNombre.Text, funcionalidades);

        
        }
    }
}
