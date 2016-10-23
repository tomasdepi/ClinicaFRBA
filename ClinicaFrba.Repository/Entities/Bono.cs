using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Bono
    {
        public int Id { get; set; }
        public int Codigo_Plan { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public DateTime Fecha_Impresion { get; set; }
        public int Id_Afiliado_Compro { get; set; }
        public int Id_Afukuado_Utilizo { get; set; }
        public int Numero_Consulta_Medica { get; set; }
    }
}
