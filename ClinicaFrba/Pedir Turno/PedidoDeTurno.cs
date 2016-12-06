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
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedidoDeTurno : Form
    {
        public PedidoDeTurno()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarComboEspecialidades();
        }

        private void lblEspecialidad_Click(object sender, EventArgs e)
        {

        }

        private void CargarComboEspecialidades()
        {
            TurnoFunciones turno = new TurnoFunciones();

            List<String> especialidades = turno.getEspecialidadesDB();

            especialidades.ForEach(esp => cBoxEspecilidad.Items.Add(esp));

        }

        private void cBoxEspecilidad_TextChanged(object sender, EventArgs e)
        {
            this.gridProfesionales.Rows.Clear();

            TurnoFunciones turno = new TurnoFunciones();
            List<Usuario> usuarios = turno.getProfesionalesPorEspecialidad(cBoxEspecilidad.SelectedItem.ToString());

            for (int i = 0; i < usuarios.Count(); i++)
            {
                Usuario user = new Usuario();
                user = usuarios[i];

                gridProfesionales.Rows.Add(user.Nombre, user.Apellido, cBoxEspecilidad.Text);
            }


        }
    }
}
