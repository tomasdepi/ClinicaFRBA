using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Service
{
    public class ClinicaService
    {

        /// <summary>
        /// Toma al afiliado principal calcula la cantidad de familiares a cargo y luego procesa los afiliados 
        /// restantes que esten asociados seteando el nro de Afiliado de manera incremental
        /// </summary>
        /// <param name="afiliados"></param>
        public void GuardarRegistroAfiliado(List<Usuario> afiliados)
        {
            try
            { 
                if (afiliados != null)
                {
                    var repo = new AfiliadoDao();
                   
                    afiliados[0].CantidadFamiliaresACargo = afiliados.Count - 1;
                    repo.Add(afiliados[0]);
                    var nroAfiliado = afiliados[0].NroAfiliado;
                    afiliados.Remove(afiliados[0]);

                    var i = 2;

                    foreach (var afiliado in afiliados)
                    {
                        afiliado.NroAfiliado = Convert.ToInt32(nroAfiliado + "0" + i.ToString());
                        afiliado.CantidadFamiliaresACargo = 0;
                        repo.Add(afiliado);
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// Devuelve true si el afiliado es casado o vive en concubinato
        /// </summary>
        /// <param name="afiliado">Afiliado</param>
        /// <returns></returns>
        public bool EsCasadoOViveEnConcubinato(Usuario afiliado)
        {
            return afiliado.EstadoCivil == "Casado" || afiliado.EstadoCivil == "Concubinato";
        }

        
    }
}
