﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Plan
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int PrecioBonoConsulta { get; set; }
        public int PrecioBonoFarmacia { get; set; }
    }
}
