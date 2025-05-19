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
using WpfApp1.data;
using WpfApp1.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для OrdersToDelete.xaml
    /// </summary>
    public partial class OrdersToDelete : Window
    {
        private List<Order> Order { get; set; }
        private ApplicationContext Context { get; set; }
        public OrdersToDelete(List<Order> order, ApplicationContext context)
        {
            InitializeComponent();
            Order = order;
            orderList.ItemsSource = Order;
            Context = context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in orderList.SelectedItems)
            {
                var orders = i as Order;
                Context.orders.Remove(orders);
                Context.SaveChanges();
             }
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
