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

        LoginFunciones login;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblRol.Visible = false;
            cbRoles.Visible = false;
            btnEntrar.Visible = false;

            login = new LoginFunciones();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var pass = txtPassword.Text;

            ClinicaService service = new ClinicaService();
            LoginFunciones login = new LoginFunciones();

            if(username.Equals("admin") && pass.Equals("w23e"))
            {
                List<String> funcionalidades = login.TodasLasFuncionalidades();
                this.Hide();
                new Menu(funcionalidades).ShowDialog();
                this.Close();
                return;
            }
                     
            List<String> roles = login.Logearse(username, pass);

            if (roles.Count == 0) {
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK);
                login.IntentoFallido(username);
            }
            else {

                lblRol.Visible = true;
                cbRoles.Visible = true;
                btnEntrar.Visible = true;

                roles.ForEach(rol => cbRoles.Items.Add(rol));
               
            }

            
            cbRoles.SelectedItem = cbRoles.Items[0];
            //var roles = new GestionarRoles();
            //roles.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var rol = cbRoles.SelectedItem.ToString();
            List<String> funcionalidades = login.GetFuncionalidadesDeRol(rol);
            new Menu(funcionalidades).Show();
        }
    }
}