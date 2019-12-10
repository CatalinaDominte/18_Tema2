using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Tables.Books;

namespace SerializeObject
{
    public static class Xml
    {
        public static void SerializeObject(this List<Book> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }
    }
}
