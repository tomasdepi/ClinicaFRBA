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
using ClinicaFrba.Registro_Resultado;

namespace ClinicaFrba.RegistroResultado
{
    public partial class AccesoPlanillas : Form
    {
        public AccesoPlanillas()
        {
            InitializeComponent();
            CargarTurnosDelDia();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grdResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdResultado.Columns[3].Index && e.RowIndex >= 0)
            {

            }

            if (e.ColumnIndex == grdResultado.Columns[4].Index && e.RowIndex >= 0)
            {
                DataGridViewTextBoxCell horaCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[0];
                String hora = (String)horaCell.Value;

                DataGridViewTextBoxCell nombreCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[1];
                String nombre = (String)nombreCell.Value;

                DataGridViewTextBoxCell apellidoCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[2];
                String apellido = (String)apellidoCell.Value;

                ConfirmarDiagnostico ventanaConfirmar = new ConfirmarDiagnostico(hora, nombre, apellido);
                ventanaConfirmar.Show();
            }
        }
        private void CargarTurnosDelDia()
        {
            TurnoDao dao = new TurnoDao();
            List<TurnoYUsuario> listaTurnos = dao.getTurnos();

            for (int i = 0; i < listaTurnos.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)grdResultado.Rows[0].Clone();
                row.Cells[0].Value = listaTurnos[i].getHora();
                row.Cells[1].Value = listaTurnos[i].getNombre();
                row.Cells[2].Value = listaTurnos[i].getApellido();
                row.Cells[3].Value = listaTurnos[i].getIdTurno();
                grdResultado.Rows.Add(row);
            }

        }

    }
}
