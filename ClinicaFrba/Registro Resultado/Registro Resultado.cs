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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grdResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
                grdResultado.Rows.Add(row);
            }
        }

    }
}
