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
    

        public List<TurnoYUsuario> getTurnos(int idDoctor)
        { 
            DateTime dt = Convert.ToDateTime(DateTime.Today); 
            List<TurnoYUsuario> vRetorno = new List<TurnoYUsuario>();
            DateTime thisDay = DateTime.Today;
            this.Connector.Open();
            String query = "SELECT u.varNombre AS nombre, u.varApellido AS apellido, t.intIdTurno AS idTurno, t.datFechaTurno AS fecha " +
                "FROM dbo.Turno AS t INNER JOIN dbo.Afiliado AS af  on t.intIdPaciente = af.intIdUsuario INNER JOIN dbo.Usuario as u on u.intIdUsuario = af.intIdUsuario " +
                "WHERE t.intIdDoctor = " + idDoctor + " AND CAST(t.datFechaTurno AS DATE) =  CAST('20150101' AS DATE);" ;
            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();
            
            
            while (resultado.Read())
            {
                  TurnoYUsuario turno = new TurnoYUsuario();
                  turno.Nombre = resultado["nombre"].ToString();
                  turno.Apellido = resultado["apellido"].ToString();
                  DateTime fechaBuscada = DateTime.Parse(resultado ["fecha"].ToString());
                  turno.FechaTurno = fechaBuscada;
                  turno.IdTurno = Int32.Parse(resultado["idTurno"].ToString());
                  vRetorno.Add(turno);
            }

           
            this.Connector.Close();

            return vRetorno;

        }

        public void ConfirmarLlegadaPaciente (int id)
        {
            String idUtilizado = (id.ToString());
            String query = "UPDATE dbo.Asistencia set bitAtendido = 1 where intIdTurno =" + idUtilizado +";" ;
            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void actualizarTurnoCompletado (TurnoYUsuario turno)
        {
           

           String query = "UPDATE dbo.Consulta SET varSintomas = '"+turno.Sintomas.ToString()+
                          "', varEnfermedad = '"+turno.Diagnostico.ToString() +
                          "' where intIdTurno = "+turno.IdTurno.ToString()+";" ;
            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

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
