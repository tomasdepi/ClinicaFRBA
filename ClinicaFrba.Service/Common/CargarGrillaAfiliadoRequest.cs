﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Service.Common
{
    public class CargarGrillaAfiliadoRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? CodigoPlan { get; set; }
        public bool? EstadoActual { get; set; }
    }

}
