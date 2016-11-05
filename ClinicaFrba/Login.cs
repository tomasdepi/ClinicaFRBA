using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Service;
using ClinicaFrba.Repository;

namespace ClinicaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblRol.Visible = false;
            cbRoles.Visible = false;
            btnEntrar.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var pass = txtPassword.Text;

            ClinicaService service = new ClinicaService();
            LoginFunciones login = new LoginFunciones();

            if (!service.esCampoNumerico(username)) MessageBox.Show("Ingrese Campo Valido", "Alerta", MessageBoxButtons.OK);
            else
            {
                List<String> Roles = login.logearse(username, pass);

                if (Roles.Count == 0) {
                    MessageBox.Show("Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK);
                    login.intentoFallido(username);
                }
                else {

                    lblRol.Visible = true;
                    cbRoles.Visible = true;
                    btnEntrar.Visible = true;

                    Roles.ForEach(rol => cbRoles.Items.Add(rol));
               
                }

            }
            
            //var roles = new GestionarRoles();
            //roles.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            LoginFunciones login = new LoginFunciones();

            //login.getFuncionalidadesDeRol();
        }
    }
}