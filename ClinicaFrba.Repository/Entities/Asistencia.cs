using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    class Asistencia
    {
        public int Numero_de_Turno { get; set; }
        public DateTime Fecha_Y_Hora{ get; set; }
        public int Numero_Bono { get; set; }
        public bool Atendido { get; set; }
    }
}
