using DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Tables;
using static Tables.Publisher;

namespace DataAccess
{
    public class PublisherRepository
    {
        public void publishersNumberOfRows(string command)
        {
           
            var connection = ConnectionManager.GetConnection();
            connection.Open();
            try
            {
                
                SqlCommand commandQuery = new SqlCommand(command, connection);
                var commandScalar = commandQuery.ExecuteScalar();
                Console.WriteLine(commandScalar);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                
            }
            connection.Close();
           
        }
        public List<Tables.Publisher> Top10Publishers(string query)
        {
            List<Tables.Publisher> publishers = new List<Tables.Publisher>();
            var connection = ConnectionManager.GetConnection();
            connection.Open();
            try
            {
                SqlCommand comm = new SqlCommand(query, connection);
                var dataReader = comm.ExecuteReader();
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    Tables.Publisher publisher = new Tables.Publisher();
                    publisher.PublisherId = (int)currentRow["PublisherId"];
                    publisher.Name = currentRow["Name"].ToString();
                    publishers.Add(publisher);
                }

            }
            catch (SqlException e)
            {

                Console.WriteLine(e.Message);
            }
            
            connection.Close();
            return publishers;
        }

    }
}
