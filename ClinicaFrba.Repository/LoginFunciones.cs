﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    

    public class LoginFunciones
    {


        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset { get; set; }
        public SqlCommand Command { get; set; }

        public LoginFunciones()
        {
            Connector = new SqlConnection("server=localhost\\SQLSERVER;" +
                                           "Trusted_Connection=yes;" +
                                           "database=GD2C2016; " +
                                           "connection timeout=10");
        }


        public List<String> logearse(String user, String pass)
        {
            int intUser = Int32.Parse(user);
            List<String> roles = new List<string>();

            String query = "select varNombreRol from dbo.UsuarioXRol rol inner join  dbo.Usuario us on rol.intIdUsuario = us.intIdUsuario where us.intIdUsuario = @user and nvarPassword = HASHBYTES('SHA2_256', @pass) and us.intIntentosLogin < 3";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@user", SqlDbType.Int).Value = intUser;
            this.Command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();

            while (resultado.Read()) roles.Add(resultado[0].ToString());

            this.Connector.Close();

            return roles;
        }

        public void intentoFallido(String user)
        {
            String query = "exec dbo.actualizarIntentoLogin @user";

            this.Command.Parameters.Add("@user", SqlDbType.Int).Value = user;

            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }
    
    }
}
