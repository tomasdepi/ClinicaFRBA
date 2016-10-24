using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    class Especialidad
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Codigo_Tipo { get; set; }
        public string  Descripcion_Codigo_Tipo { get; set; }
    }
}
