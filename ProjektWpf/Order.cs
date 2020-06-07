using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWpf
{
    public class Order
    {
        private User user { get; set; }
        private Book book { get; set; }


        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }
        

        public Book Book
        {
            get
            {
                return book;
            }

            set
            {
                book = value;
            }
        }


        public Order()
        {

        }

        public Order(User user, Book book)
        {
            this.user = user;
            this.book = book;
        }


        public User GetUser()
        {
            return user;
        }

        public Book GetBook()
        {
            return book;
        }

        public override string ToString()
        {
            return user.FirstName + " " + user.LastName + " -> " + book.Author+ " ," + book.Title;
        }
    }
}
