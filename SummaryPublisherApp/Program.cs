using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Tables.Books;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherRepository PublisherRepository = new PublisherRepository();
            PublisherRepository.publishers("Select count([PublisherId]) from[Publisher]");
            //Select count([PublisherId]) from [Publisher]
            //List<Publisher> publishers = PublisherRepository.publishers("");
            Console.ReadLine();

        }
    }
}
