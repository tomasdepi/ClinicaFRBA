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

        public String getHora()
        {
            String var = FechaTurno.Hour.ToString();
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
    }
   
}
