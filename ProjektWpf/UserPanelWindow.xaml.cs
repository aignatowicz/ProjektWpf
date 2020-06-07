using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml;
using System.Xml.Serialization;

namespace ProjektWpf
{
    /// <summary>
    /// Logika interakcji dla klasy UserPanelWindow.xaml
    /// </summary>
    public partial class UserPanelWindow : Window
    {
        private List<Book> books;
        private List<Book> booksInBasket;


        public UserPanelWindow()
        {
            InitializeComponent();
            books = new List<Book>();
            booksInBasket = new List<Book>();
            bookList.ItemsSource = books;
            loadBooks();
        }   


        private void loadBooks()
        {
            String filename = "books.xml";

            if (File.Exists(filename))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookRepository));

                using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                {
                    BookRepository bookRepository = (BookRepository) xmlSerializer.Deserialize(fileStream);

                    foreach (Book book in bookRepository.GetBooks())
                    {
                        books.Add(book);
                    }

                    bookList.Items.Refresh();
                }
            }
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            App.Current.MainWindow = loginWindow;
            this.Close();
            loginWindow.Show();
        }

        private void showBasketButtonClick(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWindow = new BasketWindow(booksInBasket);
            basketWindow.ShowDialog();
            bookList.Items.Refresh();
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = (Book) bookList.SelectedItem;

            if (selectedBook != null)
            {
                addToBasketButton.IsEnabled = true;
            }
            else
            {
                addToBasketButton.IsEnabled = false;
            }
        }

        private void AddToBasketButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book) bookList.SelectedItem;

            if (booksInBasket.Contains(selectedBook) == false)
            {
                booksInBasket.Add(selectedBook);
            }
        }
    }
}