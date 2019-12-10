using DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tables;

namespace DataAccess
{
    public class NumberOfBooksPerPublisherRepository
    {
        public List<NumberOfBooksPerPublisher> booksForPublisher(string query)
        {
            var connection = ConnectionManager.GetConnection();
            connection.Open();
            List<NumberOfBooksPerPublisher> publishersBooks = new List<NumberOfBooksPerPublisher>();
            
            try
            {
                SqlCommand comm = new SqlCommand(query, connection);
                var dataReader = comm.ExecuteReader();
               
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    NumberOfBooksPerPublisher publisherBook = new NumberOfBooksPerPublisher();
                    publisherBook.PublisherName = currentRow["Name"].ToString();
                    publisherBook.priceForBooks = currentRow["bookPrice"] as Decimal? ?? default(int);
                    publisherBook.NoOfBooks = currentRow["bookCount"] as int? ?? 0;
                    
                    publishersBooks.Add(publisherBook);
                }

            }
            catch (SqlException e)
            {

                Console.WriteLine(e.Message);
            }

            connection.Close();
           
            return publishersBooks;
        }
    }
}
