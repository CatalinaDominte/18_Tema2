using DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tables.Books;

namespace DataAccess
{
    public class BookRepository
    {
        public List<Book> SummaryBook(string query)
        {
            
            var connection = ConnectionManager.GetConnection();
            connection.Open();
            List<Book> books = new List<Book>();

            try
            {

                SqlCommand command = new SqlCommand(query, connection);
                

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var currentRow = dataReader;

                    Book book = new Book();

                    book.BookId = (int)currentRow["BookId"];
                    book.Title = currentRow["Title"].ToString();
                    book.PublisherId = currentRow["PublisherId"] as int? ?? 0;
                    book.Year = currentRow["Year"] as int? ?? default(int);
                    book.Price = currentRow["Price"] as decimal? ?? default(decimal);

                    books.Add(book);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            
            connection.Close();

            return books;
        }
    }
}

