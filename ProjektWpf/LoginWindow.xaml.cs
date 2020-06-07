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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektWpf
{
    /// <summary>
    /// Logika interakcji dla klasy WyborUzytkownika.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            //Window window = adminRadioButton.IsChecked ? new AdminPanelWindow() : new UserPanelWindow
            Window window;

            if (adminRadioButton.IsChecked == true)
            {
                window = new AdminPanelWindow();
            } else
            {
                window = new UserPanelWindow();
            }

            App.Current.MainWindow = window;
            this.Close();
            window.Show();
        }
    }
}