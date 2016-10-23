using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    class Plan
    {
        public int Codigo { get; set; }
        public String Descripcion { get; set; }
        public int Precio_Bono_Consulta { get; set; }
        public int Precio_Bono_Farmacia { get; set; }
    }
}
