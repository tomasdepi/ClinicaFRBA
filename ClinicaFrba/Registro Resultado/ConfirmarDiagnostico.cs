using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class ConfirmarDiagnostico : Form
    {
        private string apellidoPaciente;
        private string horaTurno;
        private string nombrePaciente;

        public ConfirmarDiagnostico()
        {
            InitializeComponent();
        }

        public ConfirmarDiagnostico(string hora, string nombre, string apellido)
        {
            InitializeComponent();
            apellidoPaciente = apellido;
            nombrePaciente = nombre;
            horaTurno = hora;
            lblDatos.Text = "Turno para :" +this.nombrePaciente + "," + this.apellidoPaciente + ". A las: " +this.horaTurno;
            
        }

        private void ConfirmarDiagnostico_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxDiagnostico_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDatos_Click(object sender, EventArgs e)
        {

        }
    }
}
