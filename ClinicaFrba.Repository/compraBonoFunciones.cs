using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClinicaFrba.Repository.Entities;


namespace ClinicaFrba.Repository
{
    public class compraBonoFunciones
    {

        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset { get; set; }
        public SqlCommand Command { get; set; }

        public compraBonoFunciones()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            Connector = new SqlConnection("server=localhost\\SQLSERVER;" +
                                       "Trusted_Connection=yes;" +
                                       "database=GD2C2016; " +
                                       "connection timeout=10");
        }

        public Usuario existeAfiliado(String numAfiliado)
        {
            String query = "select u.varNombre as nombre, u.varApellido as apellido,  af.intCodigoPlan as planMed, u.intIdUsuario as dni " + 
                "from dbo.Usuario as u inner join dbo.Afiliado as af on u.intIdUsuario = af.intIdUsuario where af.intNumeroAfiliado = @intNumeroAfiliado";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@intNumeroAfiliado", SqlDbType.Int).Value = numAfiliado;

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            bool result = resultado.HasRows;
            resultado.Read();
            Usuario usuario = null;
            
            if (result)
            {
                usuario = new Usuario();
                usuario.Nombre = resultado["nombre"].ToString();
                usuario.Apellido = resultado["apellido"].ToString();
                usuario.NroDocumento = Int32.Parse(resultado["dni"].ToString());
                usuario.CodigoPlanMedico = Int32.Parse(resultado["planMed"].ToString());
                usuario.NroAfiliado = Int32.Parse(numAfiliado);
            }
           
            this.Connector.Close();

            return usuario;

        }


        public float getPrecioBono(int numPlan)
        {
            String query = "select monPrecioBonoConsulta as precio from dbo.[Plan] where intCodigoPlan = @plan";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@plan", SqlDbType.Int).Value = numPlan;

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            resultado.Read();
            float precio = float.Parse(resultado["precio"].ToString());
            this.Connector.Close();

            return precio;
        }


        public void confirmarCompraBono(Usuario usuario, int cant)
        {
            String query = "exec dbo.comprarBono @Usuario=@user, @cantidad=@cant, @codigoPlan=@plan";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@plan", SqlDbType.Int).Value = usuario.CodigoPlanMedico;
            this.Command.Parameters.Add("@user", SqlDbType.Int).Value = usuario.NroDocumento;
            this.Command.Parameters.Add("@cant", SqlDbType.Int).Value = cant;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

    }
}
