﻿using ClinicaFrba.Repository.Entities;
using ClinicaFrba.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarTurno : Form
    {
        public CancelarTurno()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var motivo = txBoxMotivo.Text;
            var tipo = cmbBoxTipo.SelectedText;
            int id = Int32.Parse(cmbBoxTurno.SelectedValue.ToString()); //muestro informacion relevante pero en el value tomo el id

            TurnoCancelado turno = new TurnoCancelado();
            turno.NumeroDeTurno = id;
            turno.motivo = motivo;
            turno.tipo = tipo;

            new ClinicaService().GuardarTurnoCancelado(turno);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //agrego tipos de cancelacion, esto lo inventamos nosotros
            cmbBoxTipo.Items.Add("Otro Compomiso");
            cmbBoxTipo.Items.Add("Mejora de Salud");
        }
    }
}
