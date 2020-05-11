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
    /// Logika interakcji dla klasy PozycjeKsiegarni.xaml
    /// </summary>
    public partial class PozycjeKsiegarni : Window
    {

            bool flag = false;
            public Ksiazka2 ksiazka22;
            public PozycjeKsiegarni()
            {
                InitializeComponent();
                BoxList.Items.Add(new Ksiazka { Tytul = "ksionszka", Autor = "Zbyszek", RokWydania = "1998" });

            }

            private void ButtonClose_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }

            private void ButtonAdd_Click(object sender, RoutedEventArgs e)
            {
                Ksiazka1 ksiazka1 = new Ksiazka1();
                ksiazka1.Show();
            }

            private void ButtonDelete_Click(object sender, RoutedEventArgs e)
            {
                if (BoxList.SelectedItem != null)
                {
                    MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć ten element?", "Potwierdzenie operacji", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            BoxList.Items.Remove(BoxList.SelectedItem);
                            MessageBox.Show("Element został pomyślnie usunięty!", "Komunikat");
                            break;
                        case MessageBoxResult.No:
                            break;
                    }

                }

            }

            private void ButtonEdit_Click(object sender, RoutedEventArgs e)
            {
                if (BoxList.SelectedItem != null)
                {
                    Ksiazka1 ksiazka1 = new Ksiazka1();
                ksiazka1.flag = 1;
                    Ksiazka ksiazka = (BoxList.SelectedItem as Ksiazka);
                ksiazka1.TytulTBox.Text = ksiazka.Tytul;
                ksiazka1.AutorTBox.Text = ksiazka.Autor;
                ksiazka1.RokTBox.Text = ksiazka.RokWydania;



                ksiazka1.Show();
                }
            }

            private void ButtonShow_Click(object sender, RoutedEventArgs e)
            {
                if (BoxList.SelectedItem != null)
                {
                    if (!flag)
                    {
                    ksiazka22 = new Ksiazka2();
                        flag = true;
                        Ksiazka ksiazka2 = (BoxList.SelectedItem as Ksiazka);
                    ksiazka22.Tbox1.Text = ksiazka2.Tytul;
                    ksiazka22.Tbox2.Text = ksiazka2.Autor;
                    ksiazka22.Tbox3.Text = ksiazka2.RokWydania;
                    ksiazka22.Show();
                    }
                    else
                    {
                        Ksiazka ksiazka2 = (BoxList.SelectedItem as Ksiazka);
                    ksiazka22.Tbox1.Text = ksiazka2.Tytul;
                    ksiazka22.Tbox2.Text = ksiazka2.Autor;
                    ksiazka22.Tbox3.Text = ksiazka2.RokWydania;
                    ksiazka22.Show();

                    }
                }
            }

        }
    }

   