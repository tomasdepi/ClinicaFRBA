using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class ProfesionalDao : BaseDao<Usuario>
    {

        public ProfesionalDao() : base()
        {

        }


        public List<Usuario> GetProfesionales()
        {

            List<Usuario> lista = new List<Usuario>();

            String query = "select varNombre, varApellido from Usuario u inner join UsuarioXRol ur on u.intIdUsuario = ur.intIdUsuario where varNombreRol = 'Profesional'";

            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();

            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = reader["varNombre"].ToString();
                usuario.Apellido = reader["varApellido"].ToString();

                lista.Add(usuario);
            }

            this.Connector.Close();

            return lista;
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
