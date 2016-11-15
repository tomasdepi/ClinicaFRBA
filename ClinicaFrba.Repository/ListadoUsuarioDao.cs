using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class ListadoUsuarioDao : BaseDao<Usuario>
    {

        public List<string> GetProfesionalesMasConsultados()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProfesionalesConMenosHorasTrabajadas()
        {
            throw new NotImplementedException();
        }
        public List<string> GetAfiliadosQueCompraronMasBonos()
        {
            throw new NotImplementedException();
        }



        public override void Add(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Usuario entidad)
        {
            throw new NotImplementedException();
        }

    }
}
