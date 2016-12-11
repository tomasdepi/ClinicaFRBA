using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClinicaFrba.Repository.Entities;


namespace ClinicaFrba.Repository
{
    public class TurnoFunciones
    {
        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset { get; set; }
        public SqlCommand Command { get; set; }

        public TurnoFunciones()
        {
            Connector = new SqlConnection("server=localhost\\SQLSERVER;" +
                               "Trusted_Connection=yes;" +
                               "database=GD2C2016; " +
                               "connection timeout=10");
        }

        public List<String> getEspecialidadesDB()
        {
            List<String> especialidades = new List<string>();

            String query = "SELECT DISTINCT e.varDescripcion FROM [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad p, [INTERNAL_SERVER_ERROR].Especialidad e WHERE e.intEspecialidadCodigo = p.intEspecialidadCodigo;";

            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();

            while (resultado.Read()) especialidades.Add(resultado[0].ToString());

            this.Connector.Close();

            return especialidades;
        }

        public List<Usuario> getProfesionalesPorEspecialidad(string especialidad)
        {
            List<Usuario> profesionales = new List<Usuario>();
            string query2 = "SELECT u.varNombre nombre,u.varApellido apellido,u.intIdUsuario id FROM [INTERNAL_SERVER_ERROR].Usuario u INNER JOIN (SELECT intIdUsuario FROM [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad WHERE intEspecialidadCodigo = (SELECT intEspecialidadCodigo FROM [INTERNAL_SERVER_ERROR].Especialidad WHERE varDescripcion = @especialidad)) p ON p.intIdUsuario = u.intIdUsuario;";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = especialidad;
            this.Connector.Open();

            SqlDataReader resu = Command.ExecuteReader();
            while (resu.Read())
            {
                Usuario user = new Usuario();
                user.Nombre = resu["nombre"].ToString();
                user.Apellido = resu["apellido"].ToString();
                user.NroDocumento = Convert.ToInt32(resu["id"]);
                profesionales.Add(user);
            } 

            this.Connector.Close();
            return profesionales;
        }

        public List<string> getHorariosDisponibles(int idProfesional, string dia)
        {
            List<string> horarios = new List<string>();
            string query2 = "select timeHoraInicio,timeHoraFin from [INTERNAL_SERVER_ERROR].Agenda where intIdProfesional = @idProfesional and charDia = @dia;";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@idProfesional", SqlDbType.Int).Value = idProfesional;
            this.Command.Parameters.Add("@dia", SqlDbType.Char).Value = dia;
            this.Connector.Open();

            SqlDataReader resu = Command.ExecuteReader();
            while (resu.Read())
            {
                horarios.Add(resu["timeHoraInicio"].ToString());
                horarios.Add(resu["timeHoraFin"].ToString());
            }

            this.Connector.Close();
            return horarios;
        }


        public List<Especialidad> getIdEspecialidadesDB()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            String query = "SELECT DISTINCT e.varDescripcion as des, e.intEspecialidadCodigo as cod FROM [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad p, [INTERNAL_SERVER_ERROR].Especialidad e WHERE e.intEspecialidadCodigo = p.intEspecialidadCodigo;";

            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();

            while (resultado.Read()) 
                {
                Especialidad esp = new Especialidad();
                esp.Codigo = Convert.ToInt32(resultado["cod"]);
                esp.Descripcion = resultado["des"].ToString();
                especialidades.Add(esp);
                }

            this.Connector.Close();

            return especialidades;
        }

        public List<string> GetDisponibilidadDelProfesional(int idProfesional, DateTime fecha)
        {
            List<string> horarios = new List<string>();
            string query = "  SELECT datFechaTurno FROM [INTERNAL_SERVER_ERROR].Turno WHERE intIdDoctor = @idProfesional AND CAST(datFechaTurno AS DATE) = @diaReserva AND bitEstado = 1";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@idProfesional", SqlDbType.Int).Value = idProfesional;
            this.Command.Parameters.Add("@diaReserva", SqlDbType.VarChar).Value = fecha.ToShortDateString();

            this.Connector.Open();

            SqlDataReader resu = Command.ExecuteReader();

            while (resu.Read())
            {
                horarios.Add(resu["datFechaTurno"].ToString());
            }

            this.Connector.Close();
            return horarios;
        }

        public void ReservarNuevoTurno(int idProfesional, int idAfiliado, DateTime fechaTurno)
        {
            const string query =
                "INSERT INTO [INTERNAL_SERVER_ERROR].[Turno] ([datFechaTurno],[intIdPaciente],[intIdDoctor],[bitEstado]) " +
                "VALUES (@datFechaTurno, @intIdPaciente, @intIdDoctor, @bitEstado)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@datFechaTurno", SqlDbType.DateTime).Value = fechaTurno;
            this.Command.Parameters.Add("@intIdPaciente", SqlDbType.Int).Value = idAfiliado;
            this.Command.Parameters.Add("@intIdDoctor", SqlDbType.Int).Value = idProfesional;
            this.Command.Parameters.Add("@bitEstado", SqlDbType.Bit).Value = 1;
        
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }
        
    }
}
