﻿using System;
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

namespace ClinicaFrba.Compra_Bono
{
    public partial class VentanaIntermedioAdministrativo : Form
    {
        public VentanaIntermedioAdministrativo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var numAfiliado = txBoxNumeroAfiliado.Text;

            try { 
                Int32.Parse(numAfiliado);
            }catch(Exception exp){
                resu.Visible = true;
                resu.Text = "Número de Afiliado Invalido";

                return;
            }


            compraBonoFunciones f = new compraBonoFunciones();
            Usuario usuario = f.existeAfiliado(numAfiliado);

            if (usuario.Equals(null))
            {
                resu.Visible = true;
                resu.Text = "Número de Afiliado Invalido";
            }
            else
            {
                CompraBono formCompraBono = new CompraBono(usuario);
                formCompraBono.Show();
            }

        }

        private void VentanaIntermedioAdministrativo_Load(object sender, EventArgs e)
        {

        }

        private void txBoxNumeroAfiliado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
