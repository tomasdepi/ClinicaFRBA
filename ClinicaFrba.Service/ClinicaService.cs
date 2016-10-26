using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Service
{
    public class ClinicaService
    {
        public void GuardarAfiliado(Usuario afiliado)
        {

            try
            {
                var repo = new AfiliadoDao();

                if (afiliado != null)
                {
                    repo.Add(afiliado);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
