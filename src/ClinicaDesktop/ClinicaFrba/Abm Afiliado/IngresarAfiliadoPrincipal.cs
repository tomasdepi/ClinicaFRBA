using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository.Entities;
using ClinicaFrba.Service;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class IngresarAfiliadoPrincipal : Form
    {
        public IngresarAfiliadoPrincipal()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();

            if (!Regex.IsMatch(this.txtDni.Text, @"^[0-9]+$"))
            {
                Usuario user = service.ValidarExistenciaUsuario(Convert.ToInt32(this.txtDni.Text));

                if (user != null)
                {
                    var integranteFamilia = new AltaIntegranteFamiliaAfiliado(user.CodigoPlanMedico);

                    var resultado = integranteFamilia.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        //usuarios.Add(integranteFamilia.Afiliado);
                        //service.GuardarRegistroAfiliado(usuarios);
                    }
                }
                else
                {
                    MessageBox.Show("No existe afiliado asociado al DNI ingresado");
                }
            }
            else
            {
                MessageBox.Show("El DNI ingresado no es válido");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

            var alta = new AltaAfiliado();

            alta.Show();
        }
    }
}
