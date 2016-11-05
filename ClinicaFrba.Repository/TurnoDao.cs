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
            List<TurnoYUsuario> vRetorno = new List<TurnoYUsuario>();
            DateTime thisDay = DateTime.Today;
            String query = "SELECT vanNombre AS nombre, varApellido AS apellido, varFechaTurno AS fecha" + 
                "FROM dbo.Turno AS t INNER JOIN dbo.Afiliado AS af on t.intIdPaciente = af.intIdUsuario WHERE DAY(t.datFechaTurno) = " + thisDay.Date.ToString("d");
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
                        vRetorno.Add(turno);
                    }

            }
           
            this.Connector.Close();

            return vRetorno;

        }

    }
}
