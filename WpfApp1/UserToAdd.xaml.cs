using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для UserToAdd.xaml
    /// </summary>
    public partial class UserToAdd : Window
    {
        private List<Order> Order { get; set; }
        private List<User> User { get; set; }
        private ApplicationContext Context { get; set; }
        public UserToAdd(List<Order> order, List<User> user, ApplicationContext context)
        {
            InitializeComponent();
            Context = context;
            Order = order;
            User = user;
            orderList.ItemsSource = Order;
            userList.ItemsSource = User;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order selectetOrder = new Order();
            User selectetUser = new User();
            foreach (var i in orderList.SelectedItems)
            {
                selectetOrder = i as Order;
                
            }
            foreach (var i in userList.SelectedItems)
            {
                selectetUser = i as User;

            }
            MakeBinding(selectetOrder, selectetUser);

            Debug.WriteLine(selectetOrder);
            Debug.WriteLine(selectetUser);
            DialogResult = true;
        }

        public void MakeBinding(Order SelectOrder, User SelectUser)
        {
            SelectOrder.user = SelectUser;
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
