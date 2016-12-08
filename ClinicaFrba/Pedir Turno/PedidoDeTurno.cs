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

        public int NroAfiliado { get; set; }

        public PedidoDeTurno(int nroAfiliado)
        {
            NroAfiliado = nroAfiliado;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CargarComboEspecialidades();
            this.txBoxNumeroAfiliado.Text = NroAfiliado.ToString();
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

                gridProfesionales.Rows.Add(user.NroDocumento,user.Nombre, user.Apellido, cBoxEspecilidad.Text);
            }


        }

        private void gridProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string nroDocumento = this.gridProfesionales.Rows[e.RowIndex].Cells["NroDocumento"].Value.ToString();

                DiasDisponibles f2 = new DiasDisponibles(Convert.ToInt32(nroDocumento), NroAfiliado);

                f2.ShowDialog();
            }
        }
    }
}
