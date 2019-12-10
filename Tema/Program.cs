using DataAccess;
using Newtonsoft.Json;
using SerializeObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Tables;
using static Tables.Books;

namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            // All the books that are published in 2010


            List<Book> books10 = bookRepository.SummaryBook("select * from[Book] where[Year] = 2010");
            foreach (var book in books10)
            {
                Console.WriteLine($"{book.Title} - {book.Year}");
            }

             //The book that is published in the max year(can use multiple commands)
             List<Book> booksMaxYear = bookRepository.SummaryBook("select * from [Book] where [Year]=(select max([Year]) from [Book]) ");
             foreach (var book in booksMaxYear)
             {
                 Console.WriteLine($"{book.Title} - {book.Year}");
             }

             //Top 10 books(Title, Year, Price)
             List<Book> booksTop10 = bookRepository.SummaryBook("select top 10* from [Book] ");
             foreach (var book in booksTop10)
             {
                 Console.WriteLine($"{book.Title} - {book.Year} - {book.Price}");
             }

            //2Create a new console app named SummaryPublisherApp. Here print to console:
            //Number of rows from the Publisher table(Execute scalar)

            PublisherRepository PublisherRepository = new PublisherRepository();
            PublisherRepository.publishersNumberOfRows("Select count([PublisherId]) from[Publisher]");

            //Top 10 publishers (Id, Name) (SQL Data Reader)
           List<Tables.Publisher> publishers = PublisherRepository.Top10Publishers("select Top 10 * from [Publisher]");
            foreach (var publisher in publishers)
            {
                Console.WriteLine($"{publisher.Name} - {publisher.PublisherId}");
            }

            //3. Number of books and publisher name (Number of books for each publisher (Publiher Name, Number of Books)
            NumberOfBooksPerPublisherRepository BooksPerPublisher = new NumberOfBooksPerPublisherRepository();
            string getName = "SELECT  [Name],SUM([Price]) as bookPrice, COUNT([BookId]) as bookCount FROM  [Publisher]   LEFT JOIN [Book] ON [Publisher].[PublisherId] =[Book].[PublisherId] GROUP BY[Name]";

            List<NumberOfBooksPerPublisher> publishersBooks = BooksPerPublisher.booksForPublisher(getName);
            foreach (var item in publishersBooks)
            {
                Console.WriteLine($"{item.NoOfBooks} - {item.PublisherName} - {item.priceForBooks}");
            }
            //The total price for books for a publisher
            foreach (var item in publishersBooks)
            {
                Console.WriteLine($"{item.priceForBooks} - {item.PublisherName}");
            }
            //4. Load data from a table (author, books, etc.) into a list (List<Book> or List<Author) and serialize all lines from that table in xml and json into two files.
            Xml.SerializeObject(books10, @"F:\1CSharp\18_Tema2_ADO\books10.xml");

            File.WriteAllText(@"F:\1CSharp\18_Tema2_ADO\books10.json", JsonConvert.SerializeObject(books10));

            Console.ReadLine();
        }

    }
}
