using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Connection
{
    public class ConnectionManager
    {
        private static SqlConnection connection = null;
        private ConnectionManager() { }

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

                //   string connectionString2 = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

                connection = new SqlConnection(connectionString);
                
            }

            return connection;
        }
    }
}
