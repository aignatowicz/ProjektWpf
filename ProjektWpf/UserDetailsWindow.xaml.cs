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
    /// Logika interakcji dla klasy UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow()
        {
            InitializeComponent();
        }


        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (!firstnameTextBox.Text.Equals("") && !lastNameTextBox.Text.Equals("") && !emailTextBox.Text.Equals(""))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
