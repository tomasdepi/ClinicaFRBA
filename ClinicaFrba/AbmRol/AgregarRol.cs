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
            this.grdFuncionalidades.Rows.Add("ABM Rol");
            this.grdFuncionalidades.Rows.Add("Registro de Usuario");
            this.grdFuncionalidades.Rows.Add("ABM Afiliado");
            this.grdFuncionalidades.Rows.Add("ABM Profesional");
            this.grdFuncionalidades.Rows.Add("ABM Especialidades medicas");
            this.grdFuncionalidades.Rows.Add("ABM Planes");
            this.grdFuncionalidades.Rows.Add("Registar agenda del medico");
            this.grdFuncionalidades.Rows.Add("Comprar bonos");
            this.grdFuncionalidades.Rows.Add("Pedir turnos");
            this.grdFuncionalidades.Rows.Add("Registro de llegada para atencion medica");
            this.grdFuncionalidades.Rows.Add("Registrar resultado para atencion medica");
            this.grdFuncionalidades.Rows.Add("Cancelar atencion medica");
            this.grdFuncionalidades.Rows.Add("Listado estadistico");

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
            var funcionalidadesSeleccionadas = grdFuncionalidades.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToBoolean(row.Cells["Agregar"].Value) == true).ToList();
        }
    }
}
