using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektWpf
{
    [Serializable]
    public class BookRepository
    {
        public List<Book> books { get; set; }


        public BookRepository()
        {
            this.books = new List<Book>();
        }

        public BookRepository(List<Book> books)
        {
            this.books = books;
        }

        public List<Book> GetBooks ()
        {
            return books;
        }
    }
}