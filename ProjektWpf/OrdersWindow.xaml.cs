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
    /// Logika interakcji dla klasy OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private List<Order> orders;

        public OrdersWindow()
        {
            InitializeComponent();

            orders = new List<Order>();
            orderList.ItemsSource = orders;
            loadOrders();
        }

        private void loadOrders()
        {
            String filename = "orders.xml";

            if (File.Exists(filename))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderRepository));

                using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                {
                    OrderRepository orderRepository = (OrderRepository) xmlSerializer.Deserialize(fileStream);

                    foreach (Order order in orderRepository.Orders)
                    {
                        orders.Add(order);
                    }

                    orderList.Items.Refresh();
                }
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order selectedOrder = (Order) orderList.SelectedItem;

            if (selectedOrder != null)
            {
                finishOrderButton.IsEnabled = true;
            } else
            {
                finishOrderButton.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = (Order) orderList.SelectedItem;
            orders.Remove(order);
            orderList.Items.Refresh();
        }
         private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog()==true)
            {
                printDialog.PrintVisual(orderList, "Trwa drukowanie");
            }
        }
    }
}
