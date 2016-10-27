using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using ClinicaFrba.Repository.Entities;
using System.Security.Cryptography;

namespace ClinicaFrba.Repository
{
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
    }
}
