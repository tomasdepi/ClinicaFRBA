using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Afiliado
    {
        public int Id { get; set; }
        public string Nombre  { get; set; }
        public string Apellido { get; set; }
        public int NroAfiliado { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public string EstadoCivil  { get; set; }

    }
}
