using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    class Turno
    {
        public int Numero_de_Turno { get; set; }
        public DateTime Fecha_Turno { get; set; }
        public int ID_Paciente { get; set; }
        public int ID_Doctor { get; set; }
        public bool Estado_Turno { get; set; }
    }
}
