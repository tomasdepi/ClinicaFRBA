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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class DiasDisponibles : Form
    {
        public DiasDisponibles()
        {
            InitializeComponent();
        }

        public int NroDocumento { get; set; }

        public DiasDisponibles(int nroDocumento)
        {
            NroDocumento = nroDocumento;
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TurnoFunciones turno = new TurnoFunciones();
            DateTime dia = new DateTime();
            dia = Convert.ToDateTime(this.dateTimePicker1.Text);

            List<string> horarios = turno.getHorariosDisponibles(this.NroDocumento, dia.DayOfWeek.ToString());
            //List<string> horarios = turno.getHorariosDisponibles(1465925,"lunes");

            TimeSpan horaInicio = TimeSpan.Parse(horarios.First());
            TimeSpan horaFin = TimeSpan.Parse(horarios.Last());

            var veces = horaFin.Subtract(horaInicio);

            TimeSpan mediaHora = new TimeSpan(0, 30, 0);

            List<string> rangoHorario = new List<string>();

            rangoHorario.Add(horaInicio.ToString());

            for (int i = 0; i < (veces.TotalHours*2)-1; i++)
            {
                rangoHorario.Add(horaInicio.Add(mediaHora).ToString());
                horaInicio = horaInicio.Add(mediaHora);
            }

            foreach (var hora in rangoHorario)
            {
                this.dataGridView1.Rows.Add(hora);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
