using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class ListadoEspecialidadesDao : BaseDao<Especialidad>
    {
        
        public List<string> getEspecialidadesMasCanceladas()
        {
            List<string> vRetorno = new List<string>();
            this.Connector.Open();

            String query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as desertores " +
                "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo "+
                "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario "+
                "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor "+
                "where t.bitEstado = 0 " +
                "group by e.varDescripcion " +
                "order by desertores desc;";
            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                vRetorno.Add(resultado["descripcion"].ToString());
            }


            this.Connector.Close();

            return vRetorno;

        }

        public List<string> getEspecialidadesMasConsultadas()
        {

        }





        public override void Add(Especialidad entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Especialidad GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Especialidad entidad)
        {
            throw new NotImplementedException();
        }
    }
}
