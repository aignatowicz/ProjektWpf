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
    public partial class Ksiazka1 : Window
    {
        public Ksiazka1()
        {
            InitializeComponent();
        }
        public int flag = 0;
    

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TytulTBox.Text) || !string.IsNullOrEmpty(AutorTBox.Text) || !string.IsNullOrEmpty(RokTBox.Text))
            {

                ((PozycjeKsiegarni)Application.Current.MainWindow).BoxList.Items.Add(new Ksiazka { Tytul = TytulTBox.Text, Autor = AutorTBox.Text, RokWydania = RokTBox.Text });

                ((PozycjeKsiegarni)Application.Current.MainWindow).UpdateLayout();
                Close();
            }
            else MessageBox.Show("Błąd! Puste pola w formularzu.");

            if (flag == 1)
            {
                ((PozycjeKsiegarni)Application.Current.MainWindow).BoxList.Items.Remove(((PozycjeKsiegarni)Application.Current.MainWindow).BoxList.SelectedItem);
            }
            flag = 0;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void TytulTBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AutorTBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RokTBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
