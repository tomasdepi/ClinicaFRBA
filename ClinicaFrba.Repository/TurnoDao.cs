using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Repository
{
    public class TurnoDao : BaseDao<TurnoYUsuario> 
    {
     
        public TurnoDao() : base()
        {
                
        }
    

        public List<TurnoYUsuario> getTurnos()
        {
            string date = "01/01/2015";
            DateTime dt = Convert.ToDateTime(date); 
            List<TurnoYUsuario> vRetorno = new List<TurnoYUsuario>();
            DateTime thisDay = DateTime.Today;
            String query = "SELECT u.varNombre, u.varApellido, t.intIdTurno AS idTurno, t.datFechaTurno AS fecha" +
            "FROM dbo.Turno AS t INNER JOIN dbo.Afiliado AS af  on t.intIdPaciente = af.intIdUsuario INNER JOIN dbo.Usuario as u on u.intIdUsuario = af.intIdUsuario" +
            "WHERE DAY(t.datFechaTurno) =  DAY(2015/01/01);" + dt.Date.ToString("d");
            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            TurnoYUsuario turno = null;
            
            if (resultado.HasRows)
            {
                     turno = new TurnoYUsuario();
                     while (resultado.Read())
                    {
                        turno.Nombre = resultado["nombre"].ToString();
                        turno.Apellido = resultado["apellido"].ToString();
                        DateTime fechaBuscada = DateTime.Parse(resultado ["fecha"].ToString());
                        turno.FechaTurno = fechaBuscada;
                        turno.IdTurno = Int32.Parse(resultado["idTurno"].ToString());
                        vRetorno.Add(turno);
                    }

            }
           
            this.Connector.Close();

            return vRetorno;

        }


        public override void Add(TurnoYUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Update(TurnoYUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override TurnoYUsuario GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
