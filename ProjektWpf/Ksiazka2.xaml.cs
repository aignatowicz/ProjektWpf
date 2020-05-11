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
    /// Logika interakcji dla klasy Ksiazka2.xaml
    /// </summary>
    public partial class Ksiazka2 : Window
    {
        public Ksiazka2()
        {
            InitializeComponent();
        }
      
            private void ButtonOK_Click(object sender, RoutedEventArgs e)
            {
                Hide();
            }
        
    }
}
