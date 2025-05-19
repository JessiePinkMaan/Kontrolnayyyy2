using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        private ObservableCollection<Order> orderForEdit { get; set;}
        private int Id { get; set; }
        ApplicationContext context;
        public EditOrder(ObservableCollection<Order> EditOrder , int id)
        {
            InitializeComponent();
            context = new ApplicationContext();
            orderForEdit = EditOrder;
            Id = id;
            orderList.ItemsSource = orderForEdit ;

        }

    

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
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
