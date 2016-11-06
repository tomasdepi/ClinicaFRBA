using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class TurnoYUsuario
    {
        public DateTime FechaTurno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTurno { get; set; }
        public String Sintomas { get; set; }
        public String Diagnostico { get; set; }

        public String getHora()
        {
            String var = FechaTurno.ToString("HH:mm"); 
            return var;
        }

        public String getNombre()
        {
            return Nombre;
        }

        public String getApellido()
        {
            return Apellido;
        }

        public int getIdTurno()
        {
            return IdTurno;
        }

        public String getSintomas()
        {
            return Sintomas;
        }

        public String getDiagnostico()
        {
            return Diagnostico;
        }
    }
   
}
