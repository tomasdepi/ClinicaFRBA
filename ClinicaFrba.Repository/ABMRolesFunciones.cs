﻿using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class ABMRolesFunciones
    {
        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset { get; set; }
        public SqlCommand Command { get; set; }

        public ABMRolesFunciones()
        {
 //           var connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            Connector = new SqlConnection("server=localhost\\SQLSERVER2012;" +
                                           "Trusted_Connection=yes;" +
                                           "database=GD2C2016; " +
                                           "connection timeout=10");
        }

        public List<String> getFuncionalidades()
        {
            String query = "select distinct varFuncionalidad FROM dbo.Funcionalidad ";
            this.Command = new SqlCommand(query, this.Connector);

            List<String> listaFuncionalidads = new List<string>();

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            
            for(; resultado.Read();)
            {
                listaFuncionalidads.Add(resultado[0].ToString());
            }

            this.Connector.Close();


            return listaFuncionalidads;
        }

        public void guardarRol(String nombre, List<String> funcionalidades)
        {

            List<int> posiciones = new List<int>();
            this.Connector.Open();
            for (var i = 0; i < funcionalidades.Count; i++)
            {
                String query2 = "select distinct intIdFuncionalidad FROM dbo.Funcionalidad where varFuncionalidad =  '"+funcionalidades[i]+"'";
                this.Command = new SqlCommand(query2, this.Connector);
                SqlDataReader resultado = Command.ExecuteReader();
                resultado.Read();
                posiciones.Add(Int32.Parse(resultado["intIdFuncionalidad"].ToString()));

                resultado.Close();
            }
            String query4 = "INSERT INTO dbo.Rol (varNombreRol,bitHabilitado) " +
                     "VALUES('" + nombre + "',1)";

            this.Command = new SqlCommand(query4, this.Connector);
            this.Command.ExecuteNonQuery();

            for (var j = 0; j < posiciones.Count; j++)
            {
                String query3 = "INSERT INTO dbo.FuncionalidadXRol (intIdFuncionalidad,varNombreRol) " +
                                     "VALUES('" + posiciones[j] + "','" + nombre + "')";

                this.Command = new SqlCommand(query3, this.Connector);
                this.Command.ExecuteNonQuery();
            }

            this.Connector.Close();
        }

        public List<Rol> getRoles()
        {
            List<Rol> roles = new List<Rol>();
            this.Connector.Open();
            String query2 = "select distinct * FROM dbo.Rol";
            this.Command = new SqlCommand(query2, this.Connector);
            SqlDataReader resultado = Command.ExecuteReader();
            while (resultado.Read())
            {
                Rol rol = new Rol();
                rol.nombreRol = resultado["varNombreRol"].ToString();
                rol.estadoRol = Int32.Parse(resultado["bitHabilitado"].ToString());
                roles.Add(rol);
            }
            this.Connector.Close();
            return roles;
        }

    }
}
