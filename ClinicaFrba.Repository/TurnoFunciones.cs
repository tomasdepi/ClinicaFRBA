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
            Connector = new SqlConnection("server=localhost\\SQLSERVER2012;" +
                               "Trusted_Connection=yes;" +
                               "database=GD2C2016; " +
                               "connection timeout=10");
        }

        public List<String> getEspecialidadesDB()
        {
            List<String> especialidades = new List<string>();

            String query = "SELECT DISTINCT e.varDescripcion FROM ProfesionalXEspecialidad p, Especialidad e WHERE e.intEspecialidadCodigo = p.intEspecialidadCodigo;";

            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();

            while (resultado.Read()) especialidades.Add(resultado[0].ToString());

            this.Connector.Close();

            return especialidades;
        }

        public List<Usuario> getProfesionalesPorEspecialidad(String especialidad)
        {
            List<Usuario> profesionales = new List<Usuario>();
            String query2 = "SELECT u.varNombre nombre,u.varApellido apellido FROM Usuario u INNER JOIN (SELECT intIdUsuario FROM ProfesionalXEspecialidad WHERE intEspecialidadCodigo = (SELECT intEspecialidadCodigo FROM Especialidad WHERE varDescripcion = @especialidad)) p ON p.intIdUsuario = u.intIdUsuario;";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = especialidad;
            this.Connector.Open();

            SqlDataReader resu = Command.ExecuteReader();
            while (resu.Read())
            {
                Usuario user = new Usuario();
                user.Nombre = resu["nombre"].ToString();
                user.Apellido = resu["apellido"].ToString();
                profesionales.Add(user);
            } 

            this.Connector.Close();
            return profesionales;
        }
    }
}
