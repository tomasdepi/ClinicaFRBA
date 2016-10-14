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

namespace ClinicaFrba.Repository
{
    public class AfiliadoDao : BaseDao<Afiliado>
    {

        public AfiliadoDao() : base()
        {
                
        }

        public override void Add(Afiliado entidad)
        {
            const string query = "INSERT INTO dbo.AfiliadoTest (varNombre, varApellido, intNroAfiliado, varTipoDocumento, intNroDocumento, datFechaNacimiento, varSexo, varDireccion, intTelefono, varMail, varEstadoCivil) " +
                                 "VALUES (@varNombre, @varApellido, @intNroAfiliado, @varTipoDocumento, @intNroDocumento, @datFechaNacimiento, @varSexo, @varDireccion, @intTelefono, @varMail, @varEstadoCivil ) ";
      
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@varNombre", SqlDbType.VarChar, 50).Value = entidad.Nombre;
            this.Command.Parameters.Add("@varApellido", SqlDbType.VarChar, 50).Value = entidad.Apellido;
            this.Command.Parameters.Add("@intNroAfiliado", SqlDbType.Int).Value = entidad.NroAfiliado;
            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 5).Value = entidad.TipoDocumento;
            this.Command.Parameters.Add("@intNroDocumento", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@datFechaNacimiento", SqlDbType.DateTime).Value = entidad.FechaNacimiento;
            this.Command.Parameters.Add("@varSexo", SqlDbType.VarChar, 15).Value = entidad.Sexo;
            this.Command.Parameters.Add("@varDireccion", SqlDbType.VarChar, 150).Value = entidad.Direccion;
            this.Command.Parameters.Add("@intTelefono", SqlDbType.Int).Value = entidad.Telefono;
            this.Command.Parameters.Add("@varMail", SqlDbType.VarChar, 100).Value = entidad.Mail;
            this.Command.Parameters.Add("@varEstadoCivil", SqlDbType.VarChar, 20).Value = entidad.EstadoCivil;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Update(Afiliado entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Afiliado GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
