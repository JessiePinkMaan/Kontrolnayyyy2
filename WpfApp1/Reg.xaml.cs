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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        ApplicationContext context;
        public Reg()
        {
            InitializeComponent();
            context = new ApplicationContext();
        }
        private bool IsValidUser(string login)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.users.FirstOrDefault(u => u.login == login);
                return user == null; 
            }
        }
        private void registr()
        {
            string Login = login.Text;
            string Password = password.Text;

            // Проверка на null или пустые строки
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.");
                return;  
            }

            if (IsValidUser(Login))
            {
                User user = new User() { login = Login, password = Password };
                context.users.Add(user);
                context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!");
            }
            else
            {
                MessageBox.Show("Такой пользователь уже есть.");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            registr();
            this.DialogResult = true;
        }
    }
}
