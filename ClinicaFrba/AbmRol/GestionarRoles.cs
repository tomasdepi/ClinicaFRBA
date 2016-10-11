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
    public partial class GestionarRoles : Form
    {
        public GestionarRoles()
        {
            InitializeComponent();
        }

        private void grdRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AgregarRol_Click(object sender, EventArgs e)
        {
            var agregarRol = new AgregarRol {StartPosition = FormStartPosition.CenterParent};
            agregarRol.ShowDialog();
        }

        private void GestionarRoles_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}
