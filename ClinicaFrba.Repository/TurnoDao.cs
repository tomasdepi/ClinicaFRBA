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
    

        public List<TurnoYUsuario> GetTurnos(int idDoctor)
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

        public void ActualizarTurnoCompletado (TurnoYUsuario turno)
        {   

           String query = "UPDATE dbo.Consulta SET varSintomas = '"+turno.Sintomas.ToString()+
                          "', varEnfermedad = '"+turno.Diagnostico.ToString() +
                          "' where intIdTurno = "+turno.IdTurno.ToString()+";" ;
            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }


        public void GuardarTurnoCancelado(TurnoCancelado turno)
        {
            string query = "INSERT INTO dbo.TurnoCancelado (intIdTurno, varMotivo, varTipo) VALUES (@id, @motivo, @turno)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = turno.NumeroDeTurno;
            this.Command.Parameters.Add("@motivo", SqlDbType.VarChar, 50).Value = turno.motivo;
            this.Command.Parameters.Add("@turno", SqlDbType.VarChar, 50).Value = turno.tipo;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

            String query2 = "DELETA FROM Turno WHERE intIdTurno = @id";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = turno.NumeroDeTurno;
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        //funcionalidad del profesional 
        public void CancelarTurnosPorRangoDeFechas(String fechaDesde, string fechaHasta, string motivo, string tipo)
        {
            String query = "INSERT INTO TurnoCancelado (intIdTurno, varMotivo, varTipo) " +
               " SELECT intIdTurno, @motivo, @tipoCancelacion FROM Turno where CONVERT(date, datFechaTurno) > @fechaDesde and CONVERT(date, datFechaTurno) < @fechaHasta";


            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@fechaDesde", SqlDbType.VarChar, 20).Value = fechaDesde;
            this.Command.Parameters.Add("@fechaDesde", SqlDbType.VarChar, 20).Value = fechaDesde;
            this.Command.Parameters.Add("@motivo", SqlDbType.VarChar, 100).Value = motivo;
            this.Command.Parameters.Add("@tipoCancelacion", SqlDbType.VarChar, 40).Value = tipo;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

            String query2 = "DELETE FROM Turno WHERE CONVERT(date, datFechaTurno) > @fechaDesde and CONVERT(date, datFechaTurno) < @fechaHasta";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public List<TurnoYUsuario> turnosDeAfiliado(int id)
        {
            List<TurnoYUsuario> turnos = new List<TurnoYUsuario>();

            string query = "SELECT t.intIdTurno id, t.datFechaTurno fecha, u.varNombre nombre, u.varApellido apellido from Turno  t inner join Usuario u on t.intIdDoctor = u.intIdUsuario where t.intIdPaciente = @id and CONVERT(date, t.datFechaTurno) > GETDATE()" ;
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            this.Connector.Open();
            SqlDataReader dataTurnos = this.Command.ExecuteReader();

            while (dataTurnos.Read())
            {
                //si bien usuario creo que hacia refencia al afiliado, uso la entidad para traer datos del medico
                TurnoYUsuario turno = new TurnoYUsuario();
                turno.IdTurno = Int32.Parse(dataTurnos["id"].ToString());
                turno.FechaTurno = DateTime.Parse(dataTurnos["fecha"].ToString());
                turno.Nombre = dataTurnos["nombre"].ToString();
                turno.Apellido = dataTurnos["apellido"].ToString();

                turnos.Add(turno);
            }


            this.Connector.Close();

            return turnos;
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
