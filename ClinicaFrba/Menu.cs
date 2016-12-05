using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Abm_Especialidades_Medicas;
using ClinicaFrba.Abm_Planes;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Cancelar_Atencion;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Listados;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Registro_Llegada;
using ClinicaFrba.Registro_Resultado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class Menu : Form
    {

        List<String> funcionalidades;

        public Menu()
        {
            InitializeComponent();

            // this.funcionalidades = funcs;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            var distY = 50;

            for (int i = 0; i < funcionalidades.Count(); i++)
            {

                Button boton = crearBoton(distY, funcionalidades[i]);
                this.Controls.Add(boton);

                distY += 50;
            }

        }

        Button crearBoton(int distY, String func)
        {
            Button boton = new Button();
            boton.Left = 100;
            boton.Top = distY;
            boton.Text = func;
            switch (func)
            {
                case "AMB Rol":
                    boton.Click += new EventHandler(this.lanzarABMRol);
                    break;
                case "AMB Afiliado":
                    boton.Click += new EventHandler(this.lanzarABMAfiliado);
                    break;
                case "AMB Profesional":
                    boton.Click += new EventHandler(this.lanzarABMProfesional);
                    break;
                case "AMB Esp Medicas":
                    boton.Click += new EventHandler(this.lanzarABMEspecialidades);
                    break;
                case "AMB Planes":
                    boton.Click += new EventHandler(this.lanzarABMPlanes);
                    break;
                case "Registrar Agenda":
                    boton.Click += new EventHandler(this.lanzarRegistrarAgenda);
                    break;
                case "Comprar Bonos":
                    boton.Click += new EventHandler(this.lanzarComprarBonos);
                    break;
                case "Pedir Turnos":
                    boton.Click += new EventHandler(this.lanzarPedirTurnos);
                    break;
                case "Registro Llegada Atencion Medica":
                    boton.Click += new EventHandler(this.lanzarLlegadaAtencion);
                    break;
                case "Registro Resultada Atencion Medica":
                    boton.Click += new EventHandler(this.lanzarResultadoAtencion);
                    break;
                case "Cancelar Atencion Medica":
                    boton.Click += new EventHandler(this.lanzarCancelarAtencion);
                    break;
                case "Listado Estadistico":
                    boton.Click += new EventHandler(this.lanzarListadoEstadistico);
                    break;
            }
            
            return boton;
        }

        private void lanzarABMRol(object sender, EventArgs e)
        {
            new GestionarRoles().Show();
            this.Close();
        }

        private void lanzarABMAfiliado(object sender, EventArgs e)
        {
            new GestionarAfiliados().Show();
            this.Close();
        }

        private void lanzarABMProfesional(object sender, EventArgs e)
        {
            new GestionarProfesional().Show();
            this.Close();
        }

        private void lanzarABMEspecialidades(object sender, EventArgs e)
        {
            new GestionarEspecialidades().Show();
            this.Close();
        }

        private void lanzarABMPlanes(object sender, EventArgs e)
        {
            new GestionarPlanes().Show();
            this.Close();
        }

        private void lanzarRegistrarAgenda(object sender, EventArgs e)
        {
            new RegistrarAgenda().Show();
            this.Close();
        }

        private void lanzarComprarBonos(object sender, EventArgs e)
        {
            new VentanaIntermedioAdministrativo().Show();
            this.Close();
        }

        private void lanzarPedirTurnos(object sender, EventArgs e)
        {
            new PedidoDeTurno().Show();
            this.Close();
        }

        private void lanzarLlegadaAtencion(object sender, EventArgs e)
        {
            new RegistroLlegadaBono().Show();
            this.Close();
        }

        private void lanzarResultadoAtencion(object sender, EventArgs e)
        {
            new ConfirmarLlegada().Show();
            this.Close();
        }

        private void lanzarCancelarAtencion(object sender, EventArgs e)
        {
            new CancelarTurno().Show();
            this.Close();
        }

        private void lanzarListadoEstadistico(object sender, EventArgs e)
        {
            new GenerarListado().Show();
            this.Close();
        }





    }
}
