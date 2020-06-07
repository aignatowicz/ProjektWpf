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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace ProjektWpf
{
    /// <summary>
    /// Logika interakcji dla klasy PozycjeKsiegarni.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        //[XmlArray("Books"), XmlArrayItem(typeof(Book), ElementName = "Book")]
        public List<Book> books;
        //private BookRepository bookRepository;
        private XmlSerializer serializer;


        public AdminPanelWindow()
        {
            InitializeComponent();

            books = new List<Book>();
            bookList.ItemsSource = books;
            loadBooks();
            serializer = new XmlSerializer(typeof(Book));
        }

        private void loadBooks()
        {
            String filename = "books.xml";

            if (File.Exists(filename))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookRepository));

                using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                {
                    BookRepository bookRepository = (BookRepository)xmlSerializer.Deserialize(fileStream);

                    foreach (Book book in bookRepository.GetBooks())
                    {
                        books.Add(book);
                    }

                    bookList.Items.Refresh();
                }
            }
        }


        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddBookButtonClick(object sender, RoutedEventArgs e)
        {
            BookDetailsWindow bookDetailsWindow = new BookDetailsWindow();
            bookDetailsWindow.ShowDialog();

            if (bookDetailsWindow.DialogResult == true)
            {
                String title = bookDetailsWindow.titleTextBox.Text;
                String author = bookDetailsWindow.authorTextBox.Text;
                int year = int.Parse(bookDetailsWindow.yearTextBox.Text);

                Book book = new Book {
                    Title = title,
                    Author = author,
                    PublishYear = year
                };

                books.Add(book);
                bookList.Items.Refresh();
            }
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = (Book) bookList.SelectedItem;

            if (selectedBook != null)
            {
                deleteBookButton.IsEnabled = true;
                editBookButton.IsEnabled = true;
            } else
            {
                deleteBookButton.IsEnabled = false;
                editBookButton.IsEnabled = false;
            }
        }

        private void ShowOrdersButtonClick(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.ShowDialog();
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book) bookList.SelectedItem;
            books.Remove(selectedBook);

            bookList.Items.Refresh();
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            saveBooks();

            LoginWindow loginWindow = new LoginWindow();
            App.Current.MainWindow = loginWindow;
            this.Close();
            loginWindow.Show();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            Book bookToEdit = (Book) bookList.SelectedItem;
            BookDetailsWindow bookDetailsWindow = new BookDetailsWindow(bookToEdit);
            bookDetailsWindow.ShowDialog();

            if (bookDetailsWindow.DialogResult == true)
            {
                bookToEdit.Title = bookDetailsWindow.titleTextBox.Text;
                bookToEdit.Author = bookDetailsWindow.authorTextBox.Text;
                bookToEdit.PublishYear = int.Parse(bookDetailsWindow.yearTextBox.Text);

                bookList.Items.Refresh();
            }
        }

        private void saveBooks()
        {
            BookRepository bookRepository = new BookRepository(books);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookRepository));

            using (TextWriter textWriter = new StreamWriter("books.xml")) 
            {
                xmlSerializer.Serialize(textWriter, bookRepository);
                textWriter.Flush();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveBooks();
        }
    }
}