using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class ConfirmarDiagnostico : Form
    {
        private string apellidoPaciente;
        private string horaTurno;
        private string nombrePaciente;
        private int idTurno;


        public ConfirmarDiagnostico(string hora, string nombre, string apellido, int id)
        {
            InitializeComponent();
            apellidoPaciente = apellido;
            nombrePaciente = nombre;
            horaTurno = hora;
            idTurno = id;
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

        private void txtBoxSintomas_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSintomas_Click(object sender, EventArgs e)
        {

        }

        private void lblDiagnostico_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("^[a-zA-Z]+(@)[a-zA-Z]+$");
            if (r.IsMatch(txtBoxSintomas.Text))
            {
                MessageBox.Show("No se describiasdasdor", "Error" , MessageBoxButtons.OK);
                return;
            }

                if (string.IsNullOrWhiteSpace(txtBoxSintomas.Text))
            {
                MessageBox.Show("No se describieron los sintomas", "Error", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBoxDiagnostico.Text))
                {
                MessageBox.Show("No se describió el diagnostico", "Error", MessageBoxButtons.OK);
                return;
            }  

            TurnoYUsuario turno = new TurnoYUsuario();
            turno.Apellido = this.apellidoPaciente;
            turno.Diagnostico = this.txtBoxDiagnostico.Text;
            turno.Nombre = this.nombrePaciente;
            turno.Sintomas = this.txtBoxSintomas.Text;
            turno.IdTurno = this.idTurno;

        //    TurnoDao turnoCompleato = new TurnoDao();
        //    turnoCompleato.actualizarTurnoCompletado(turno);

            MessageBox.Show("Se completaron los datos correctamente", "Aviso", MessageBoxButtons.OK);

            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
