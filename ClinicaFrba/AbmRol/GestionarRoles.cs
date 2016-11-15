using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class GestionarRoles : Form
    {
        public GestionarRoles()
        {
            InitializeComponent();
            
        }


        private void grdRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdRoles.Columns[2].Index && e.RowIndex >= 0)
            {
                DataGridViewTextBoxCell rolCell = (DataGridViewTextBoxCell)grdRoles.Rows[e.RowIndex].Cells[0];
                String rol = (String)rolCell.Value;

                DataGridViewTextBoxCell estadoCell = (DataGridViewTextBoxCell)grdRoles.Rows[e.RowIndex].Cells[1];
                int estado = (String)rolCell.Value == "Habilitado" ? 1 : 0;

                EditarRol ventanaEditar = new EditarRol(rol, estado);
                ventanaEditar.Show();
            }
        }

        private void AgregarRol_Click(object sender, EventArgs e)
        {
            var agregarRol = new AgregarRol {StartPosition = FormStartPosition.CenterParent};
            agregarRol.ShowDialog();
        }

        private void GestionarRoles_Load(object sender, EventArgs e)
        {
            RolFuncionalidadDao func = new RolFuncionalidadDao();
            List<Rol> roles = func.GetRoles();

            for (int i = 0; i < roles.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell estado = new DataGridViewTextBoxCell();
                DataGridViewButtonCell boton = new DataGridViewButtonCell();
                boton.Value = "Editar";
                estado.Value = roles[i].EstadoRol == true ? "Habilitado" : "Deshabilitado";
                DataGridViewCell text = new DataGridViewTextBoxCell();
                text.Value = roles[i].NombreRol;
                
                row.Cells.Add(text);
                row.Cells.Add(estado);
                row.Cells.Add(boton);

                grdRoles.Rows.Add(row);

                estado.ReadOnly = true;
                text.ReadOnly = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}
