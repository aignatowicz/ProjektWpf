using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ProjektWpf
{
    /// <summary>
    /// Logika interakcji dla klasy BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        private List<Book> books;


        public BasketWindow(List<Book> books)
        {
            InitializeComponent();
            this.books = books;
            bookList.ItemsSource = books;

            if (books.Count() > 0)
            {
                makeOrder.IsEnabled = true;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = (Book) bookList.SelectedItem;

            if (selectedBook != null)
            {
                removeFromBasketButton.IsEnabled = true;
            }
            else
            {
                removeFromBasketButton.IsEnabled = false;
            }
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow();
            userDetailsWindow.ShowDialog();

            if (userDetailsWindow.DialogResult == true)
            {
                List<Order> orders = new List<Order>();

                foreach (Book book in books)
                {
                    User user = new User
                    {
                        FirstName = userDetailsWindow.firstnameTextBox.Text,
                        LastName = userDetailsWindow.lastNameTextBox.Text,
                        Email = userDetailsWindow.emailTextBox.Text
                    };

                    Order order = new Order
                    {
                        User = user,
                        Book = book
                    };

                    orders.Add(order);
                    bookList.Items.Refresh();
                }

                saveOrders(orders);
                books.Clear();
                bookList.Items.Refresh();
            }
        }

        private void saveOrders(List<Order> orders)
        {
            OrderRepository orderRepository = new OrderRepository(orders);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderRepository));

            using (TextWriter writer = new StreamWriter("orders.xml"))
            {
                xmlSerializer.Serialize(writer, orderRepository);
                writer.Flush();
            }
        }

        private void RemoveFromBasketButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book) bookList.SelectedItem;
            books.Remove(selectedBook);
            bookList.Items.Refresh();
        }
    }
}