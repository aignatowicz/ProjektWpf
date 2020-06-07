using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektWpf
{
    public class Book
    {
        private string title { get; set; }
        private string author { get; set; }
        private int publishYear { get; set; }


        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public int PublishYear
        {
            get
            {
                return publishYear;
            }

            set
            {
                publishYear = value;
            }
        }


        public Book()
        {

        }


        public override string ToString()
        {
            return title + " " + author+ " " + publishYear;
        }
    }
}