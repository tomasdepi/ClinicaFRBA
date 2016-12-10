using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class InfoParaListado
    {
        public string Plan { get; set; }
        public string Especialidad { get; set; }
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public int Mes { get; set; }
    }
}