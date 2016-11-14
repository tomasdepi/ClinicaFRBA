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

namespace ClinicaFrba.Listados
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCuatrimestre_Click(object sender, EventArgs e)
        {

        }

        private void lblmes_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHacerListado_Click(object sender, EventArgs e)
        {
            if(todasLasComboBoxesCompletas())
            {
                if (cboListado.Text == "Especialidades con más cancelaciones")
                {
                    ListadoEspecialidadesDao list = new ListadoEspecialidadesDao();
                    this.generarTabla(list.getEspecialidadesMasCanceladas());
                    return;
                }

                if (cboListado.Text == "Profecionales más consultados")
                {
                    ListadoUsuarioDao list = new ListadoUsuarioDao();
                    this.generarTabla(list.getProfesionalesMasConsultados());
                    return;
                }

                if (cboListado.Text == "Profesional con menos horas trabajadas")
                {
                    ListadoUsuarioDao list = new ListadoUsuarioDao();
                    this.generarTabla(list.getProfesionalesConMenosHorasTrabajadas());
                    return;
                }

                if (cboListado.Text == "Afiliados que más bonos compraron")
                {
                    ListadoUsuarioDao list = new ListadoUsuarioDao();
                    this.generarTabla(list.getAfiliadosQueCompraronMasBonos());
                    return;
                }

                if (cboListado.Text == "Especialidades más consultadas")
                {
                    ListadoEspecialidadesDao list = new ListadoEspecialidadesDao();
                    this.generarTabla(list.getEspecialidadesMasConsultadas());
                    return;
                }

                MessageBox.Show("Por favor, chequee que la lista seleccionada sea válida", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void generarTabla(List<string> id)
        {
            return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarComboBoxes()
        {
            this.cboListado.Items.Add("Especialidades con más cancelaciones");
            this.cboListado.Items.Add("Profecionales más consultados");
            this.cboListado.Items.Add("Profesional con menos horas trabajadas");
            this.cboListado.Items.Add("Afiliados que más bonos compraron");
            this.cboListado.Items.Add("Especialidades más consultadas");

            this.cboMes.Items.Add("Enero");
            this.cboMes.Items.Add("Febrero");
            this.cboMes.Items.Add("Marzo");
            this.cboMes.Items.Add("Abril");
            this.cboMes.Items.Add("Mayo");
            this.cboMes.Items.Add("Junio");
            this.cboMes.Items.Add("Julio");
            this.cboMes.Items.Add("Agosto");
            this.cboMes.Items.Add("Septiembre");
            this.cboMes.Items.Add("Octubre");
            this.cboMes.Items.Add("Noviembre");
            this.cboMes.Items.Add("Diciembre");

            this.cboSemestre.Items.Add("Primer semestre");
            this.cboSemestre.Items.Add("Segundo semestre");

      //      List<String> años = añosConRegistros();

        }

        private void CargarTurnosDelDia(int idDoctor)
        {


        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool todasLasComboBoxesCompletas()
        {
            if (cboAño.Text == null)
            {
                MessageBox.Show("No se seleccionó un Año para la búsqueda", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (cboListado.Text == null)
            {
                MessageBox.Show("No se seleccionó un tipo de Listado", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (cboSemestre.Text == null)
            {
                MessageBox.Show("No se seleccionó un Semestre para la búsqueda", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (cboListado.Text == "Profesional con menos horas trabajadas")
            {
                if(cboPlan.Text == null)
                {
                    MessageBox.Show("No se seleccionó un Plan para la búsqueda", "Error", MessageBoxButtons.OK);
                    return false;
                }
                if (cboEspecialidad.Text == null)
                {
                    MessageBox.Show("No se seleccionó una Especialidad para la búsqueda", "Error", MessageBoxButtons.OK);
                    return false;
                }
            }

            return true;
        }
    }
}
