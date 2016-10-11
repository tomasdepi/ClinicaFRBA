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

namespace ClinicaFrba.Repository
{
    public class AfiliadoDao
    {

        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset  { get; set; }
        public SqlCommand Command  { get; set; }

        public AfiliadoDao()
        {
           // ConfigurationManager.ConnectionStrings["cn"].ConnectionsString;
           Connector = new SqlConnection("Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2016;User ID=gd;Password=***********");
        }

    }
}
