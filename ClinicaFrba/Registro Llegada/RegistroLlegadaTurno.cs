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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegadaTurno : Form
    {
        int idProfesional;

        public RegistroLlegadaTurno(int idProfesional)
        {
            InitializeComponent();
            this.idProfesional = idProfesional;
        }

        List<int> idsUsuario;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var rowTurno = dgvTurno.SelectedRows[0].Index;
            int id = idsUsuario.GetRange(rowTurno, 1).First();

            new RegistroLlegadaBono(id).Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            dgvTurno.MultiSelect = false;

            idsUsuario = new List<int>();

            TurnoDao dao = new TurnoDao();
            List<TurnoYUsuario> turnos = dao.turnosDeHoy(idProfesional);

            for (int i = 0; i < turnos.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell fecha = new DataGridViewTextBoxCell();
                fecha.Value = turnos[i].FechaTurno;
                DataGridViewCell afiliado = new DataGridViewTextBoxCell();
                afiliado.Value = turnos[i].Nombre + " " + turnos[i].Apellido;
                idsUsuario.Add(turnos[i].idUsuario);

                row.Cells.Add(fecha);
                row.Cells.Add(afiliado);

                dgvTurno.Rows.Add(row);
            }

        }
    }
}
