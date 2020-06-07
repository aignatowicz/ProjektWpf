using System;
using System.Collections.Generic;
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

namespace ProjektWpf
{
    /// <summary>
    /// Logika interakcji dla klasy Ksiazka1.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        private Book bookToEdit;


        public BookDetailsWindow()
        {
            InitializeComponent();
        }

        public BookDetailsWindow(Book book)
        {
            InitializeComponent();
            this.bookToEdit = book;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (!titleTextBox.Text.Equals("") && !authorTextBox.Text.Equals("") && !yearTextBox.Text.Equals(""))
            {
                DialogResult = true;
                Close();
            } else
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bookToEdit != null)
            {
                titleTextBox.Text = bookToEdit.Title;
                authorTextBox.Text = bookToEdit.Author;
                yearTextBox.Text = bookToEdit.PublishYear.ToString();
            }
        }
    }
}