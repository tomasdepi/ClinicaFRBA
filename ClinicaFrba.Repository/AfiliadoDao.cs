using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using ClinicaFrba.Repository.Entities;
using System.Security.Cryptography;

namespace ClinicaFrba.Repository
{
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public class AfiliadoDao : BaseDao<Usuario> 
    {

        public AfiliadoDao() : base()
        {
                
        }

        public override void Add(Usuario entidad)
        {
            const string query = "INSERT INTO dbo.Usuario (varNombre, varApellido, varTipoDocumento, intNroDocumento, datFechaNacimiento, varDireccion, intTelefono, varMail,nvarPassword,chrSexo) " +
                                 "VALUES (@varNombre, @varApellido, @varTipoDocumento, @intNroDocumento, @datFechaNacimiento, @varDireccion, @intTelefono, @varMail,@varPassword,@varSexo)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@varNombre", SqlDbType.VarChar, 50).Value = entidad.Nombre;
            this.Command.Parameters.Add("@varApellido", SqlDbType.VarChar, 50).Value = entidad.Apellido;
            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 5).Value = entidad.TipoDocumento;
            this.Command.Parameters.Add("@intNroDocumento", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@datFechaNacimiento", SqlDbType.DateTime).Value = entidad.FechaNacimiento;
            this.Command.Parameters.Add("@varSexo", SqlDbType.VarChar, 15).Value = entidad.Sexo;
            this.Command.Parameters.Add("@varDireccion", SqlDbType.VarChar, 150).Value = entidad.Direccion;
            this.Command.Parameters.Add("@intTelefono", SqlDbType.Int).Value = entidad.Telefono;
            this.Command.Parameters.Add("@varMail", SqlDbType.VarChar, 100).Value = entidad.Mail;
            this.Command.Parameters.Add("@varPassword", SqlDbType.NVarChar, 4000).Value = sha256_hash("afiliado");

            this.Connector.Open();
            this.Command.ExecuteNonQuery();

            const string query2 = "INSERT INTO dbo.Afiliado(intIdUsuario,bitEstadoActual,intCodigoPlan,intNumeroAfiliado,intCantidadFamiliares,intNumeroConsultaMedica)" +
                                  "VALUES (@intId,@bitEstado, @intCodigo,@intNumeroAf,@intCantidadFamiliares,@intNumeroConsulta)";

            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@intId", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@bitEstado", SqlDbType.Bit).Value = 1;
            this.Command.Parameters.Add("@intCodigo", SqlDbType.Int).Value = entidad.CodigoPlanMedico;
            this.Command.Parameters.Add("@intNumeroAf", SqlDbType.Int).Value = entidad.NroAfiliado; 
            this.Command.Parameters.Add("@intCantidadFamiliares", SqlDbType.Int).Value = entidad.CantidadFamiliaresACargo;
            this.Command.Parameters.Add("@intNumeroConsulta", SqlDbType.Int).Value = entidad.NumeroConsultaMedica;
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Update(Usuario entidad)
        {
            const string query =
               "UPDATE [dbo].[Usuario]" +
                "SET" +
                "[intIdUsuario] = @varTipoDocumento" +
                ",[varNombre] = @varNombre" +
                ",[varApellido] = @varApellido" +
                ",[varTipoDocumento] = @varTipoDocumento" +
                ",[intNroDocumento] = @intNroDocumento" +
                ",[intTelefono] = @intTelefono" +
                ",[varDireccion] = @varDireccion" +
                ",[varMail] = @varMail" +
                ",[datFechaNacimiento] = @datFechaNacimiento" +
                ",[chrSexo] = @varSexo" +
                ",[varEstadoCivil] = @varEstadoCivil" +
                "WHERE intIdUsuario = @intNroDocumento";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@varNombre", SqlDbType.VarChar, 50).Value = entidad.Nombre;
            this.Command.Parameters.Add("@varApellido", SqlDbType.VarChar, 50).Value = entidad.Apellido;
            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 5).Value = entidad.TipoDocumento;
            this.Command.Parameters.Add("@intNroDocumento", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@datFechaNacimiento", SqlDbType.DateTime).Value = entidad.FechaNacimiento;
            this.Command.Parameters.Add("@varSexo", SqlDbType.VarChar, 15).Value = entidad.Sexo;
            this.Command.Parameters.Add("@varDireccion", SqlDbType.VarChar, 150).Value = entidad.Direccion;
            this.Command.Parameters.Add("@intTelefono", SqlDbType.Int).Value = entidad.Telefono;
            this.Command.Parameters.Add("@varMail", SqlDbType.VarChar, 100).Value = entidad.Mail;
            this.Command.Parameters.Add("@varEstadoCivil", SqlDbType.VarChar, 100).Value = entidad.EstadoCivil;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();

            const string query2 =
                "UPDATE [dbo].[Afiliado]" +
                "SET" +
                "[intIdUsuario] = @intId" +
                ",[bitEstadoActual] = @bitEstado" +
                ",[intCodigoPlan] = @intCodigo" +
                ",[intNumeroAfiliado] = @intNumeroAf" +
                ",[intCantidadFamiliares] = @intCantidadFamiliares" +
                ",[intNumeroConsultaMedica] = @intNumeroConsulta" +
                "WHERE intIdUsuario = @varTipoDocumento";

            this.Command = new SqlCommand(query2, this.Connector);

            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 5).Value = entidad.TipoDocumento;
            this.Command.Parameters.Add("@intId", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@bitEstado", SqlDbType.Bit).Value = 1;
            this.Command.Parameters.Add("@intCodigo", SqlDbType.Int).Value = entidad.CodigoPlanMedico;
            this.Command.Parameters.Add("@intNumeroAf", SqlDbType.Int).Value = entidad.NroAfiliado;
            this.Command.Parameters.Add("@intCantidadFamiliares", SqlDbType.Int).Value = entidad.CantidadFamiliaresACargo;
            this.Command.Parameters.Add("@intNumeroConsulta", SqlDbType.Int).Value = entidad.NumeroConsultaMedica;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Delete(int id)
        {
            const string query =
                "UPDATE [dbo].[Afiliado]" +
                "SET [bitEstadoActual] = 0" +
                "WHERE intIdUsuario = @varTipoDocumento";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 5).Value = id;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override Usuario GetById(int id)
        {
            const string query =
                "SELECT TOP 1 * FROM Usuario u INNER JOIN Afiliado a ON u.intIdUsuario = a.intIdUsuario WHERE intIdUsuario = @id";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            var user = new Usuario();

            while (reader.Read())
            {
                user = new Usuario
                {
                    NroAfiliado = Convert.ToInt32(reader["intNumeroAfiliado"]),
                    EstadoCivil = Convert.ToString(reader["varEstadoCivil"]),
                    Apellido = Convert.ToString(reader["varApellido"]),
                    Nombre = Convert.ToString(reader["varNombre"]),
                    TipoDocumento = Convert.ToString(reader["varTipoDocumento"]),
                    NroDocumento = Convert.ToInt32(reader["intNroDocumento"]),
                    Telefono = Convert.ToInt32(reader["intTelefono"]),
                    Mail = Convert.ToString(reader["varMail"]),
                    FechaNacimiento = Convert.ToDateTime(reader["datFechaNacimiento"]),
                    Sexo = Convert.ToString(reader["chrSexo"]),
                    CantidadFamiliaresACargo = Convert.ToInt32(reader["intCantidadFamiliares"]),
                    NumeroConsultaMedica = Convert.ToInt32(reader["intNumeroConsultaMedica"]),
                    CodigoPlanMedico = Convert.ToInt32(reader["intCodigoPlan"]),
                    EstadoHabilitacion = Convert.ToInt32(reader["bitEstadoActual"]),
                    Direccion = Convert.ToString(reader["varDireccion"])
                };

            }

            return user;
        }

        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public List<Usuario> ObtenerUsuariosConFiltros(string nombre, string apellido, int? codigoPlan, bool? estadoActual)
        {
            StringBuilder query = new StringBuilder();
                query.Append("SELECT *  Usuario u INNER JOIN Afiliado a ON u.intIdUsuario = a.intIdUsuario WHERE 1 = 1");

            if (!string.IsNullOrEmpty(nombre))
            {
                query.Append("AND u.varNombre LIKE '%" + nombre + "%'");
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                query.Append("AND u.varApellido LIKE '%" + apellido + "%'");
            }

            if (codigoPlan.HasValue)
            {
                query.Append("AND a.intCodigoPlan =" + codigoPlan.Value.ToString() );
            }

            if (estadoActual.HasValue)
            {
                query.Append("AND a.bitEstadoActual =" + estadoActual.Value.ToString());
            }

            this.Command = new SqlCommand(query.ToString(),this.Connector);
            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            List<Usuario> users = new List<Usuario>();

            while (reader.Read())
            {
                var user = new Usuario
                {
                    NroAfiliado = Convert.ToInt32(reader["intNumeroAfiliado"]),
                    EstadoCivil = Convert.ToString(reader["varEstadoCivil"]),
                    Apellido = Convert.ToString(reader["varApellido"]),
                    Nombre = Convert.ToString(reader["varNombre"]),
                    TipoDocumento = Convert.ToString(reader["varTipoDocumento"]),
                    NroDocumento = Convert.ToInt32(reader["intNroDocumento"]),
                    Telefono = Convert.ToInt32(reader["intTelefono"]),
                    Mail = Convert.ToString(reader["varMail"]),
                    FechaNacimiento = Convert.ToDateTime(reader["datFechaNacimiento"]),
                    Sexo = Convert.ToString(reader["chrSexo"]),
                    CantidadFamiliaresACargo = Convert.ToInt32(reader["intCantidadFamiliares"]),
                    NumeroConsultaMedica =  Convert.ToInt32(reader["intNumeroConsultaMedica"]),
                    CodigoPlanMedico =  Convert.ToInt32(reader["intCodigoPlan"]),
                    EstadoHabilitacion = Convert.ToInt32(reader["bitEstadoActual"]),
                    Direccion = Convert.ToString(reader["varDireccion"])
                };

                users.Add(user);
            }

            return users;
        }
    }
}
