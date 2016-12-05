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

        }

        private void lblEspecialidad_Click(object sender, EventArgs e)
        {

        }

        private void cBoxEspecilidad_Click(object sender, EventArgs e)
        {
            TurnoFunciones turno = new TurnoFunciones();

            List<String> especialidades = turno.getEspecialidadesDB();

            especialidades.ForEach(esp => cBoxEspecilidad.Items.Add(esp));

            // cBoxEspecilidad.SelectedItem = cBoxEspecilidad.Items[0];
            if (cBoxEspecilidad.SelectedItem != null)
            {
                List<Usuario> usuarios = turno.getProfesionalesPorEspecialidad(cBoxEspecilidad.SelectedItem.ToString());

                for (int i = 0; i < usuarios.Count(); i++)
                {
                    Usuario user = new Usuario();
                    user = usuarios[i];

                    gridProfesionales.Rows.Add(user.Nombre, user.Apellido, cBoxEspecilidad.Text);
                }
            }
        }

/*       private void cBoxEspecilidad_TextChanged(object sender, EventArgs e)
        {
            TurnoFunciones turno = new TurnoFunciones();
            List<Usuario> usuarios = turno.getProfesionalesPorEspecialidad(cBoxEspecilidad.SelectedItem.ToString());

            for(int i = 0; i < usuarios.Count(); i++)
            {
                Usuario user = new Usuario();
                user = usuarios[i];

                gridProfesionales.Rows.Add(user.Nombre, user.Apellido,cBoxEspecilidad.Text);               
            }            


        }*/
    }
}
