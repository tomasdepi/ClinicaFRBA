using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    class Consulta
    {
        public int Numero_de_Turno { get; set; }
        public DateTime Fecha_Y_Hora { get; set; }
        public String Sintoma { get; set; }
        public String Diagnostico { get; set; }
    }
}
