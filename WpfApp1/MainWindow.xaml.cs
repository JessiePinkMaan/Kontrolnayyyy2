using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.data;
using WpfApp1.Data;

namespace WpfApp1
{
  
    public partial class MainWindow : Window
    {
        ApplicationContext context;
        public MainWindow()
        {
            InitializeComponent();
            Login login = new Login();
            if (login.ShowDialog() == true)
            {

                context = new ApplicationContext();
                orderList.ItemsSource = context.orders.ToList();

            }
            else
            {

                Application.Current.Shutdown();
            }

            
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrders addOrders = new AddOrders();
            addOrders.ShowDialog();
            if (addOrders.DialogResult == true)
            {

                orderList.ItemsSource = context.orders.ToList();
                MessageBox.Show("заказ добавлен");


            }
            else
            {
                MessageBox.Show("отмена");
            }
        }

        private void Dell_Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrdersToDelete ordersToDelete = new OrdersToDelete(context.orders.ToList(), context);
            ordersToDelete.ShowDialog();
            if (ordersToDelete.DialogResult == true)
            {
                orderList.ItemsSource = context.orders.ToList();
                MessageBox.Show("заказ удален");
            }
            else
            {
                MessageBox.Show("отмена");
            }
        }

        private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Order> SelectetOrder = new ObservableCollection<Order> { };
            int Id = 0;
            foreach (var item in orderList.SelectedItems)
            {
                var order = item as Order;
                Id = order.Id;
                SelectetOrder.Add(order);
                Debug.WriteLine($"Order id: {order.Id}");

            }

            EditOrder editOrder = new EditOrder(SelectetOrder, Id);
            editOrder.ShowDialog();

            if (editOrder.DialogResult == true)
            {
                context.SaveChanges();
                orderList.ItemsSource = context.orders.ToList();

                MessageBox.Show("заказ добавлен");

            }
            else
            {
                MessageBox.Show("отмена");
            }
        }

        private void Add_user_Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserToAdd addUser = new UserToAdd(context.orders.ToList(), context.users.ToList(), context);
            addUser.ShowDialog();
            if (addUser.DialogResult == true)
            {
                orderList.ItemsSource = context.orders.ToList();
                MessageBox.Show("пользователь был привязан");
            }
            else
            {
                MessageBox.Show("отмена");
            }
        }
    }
}