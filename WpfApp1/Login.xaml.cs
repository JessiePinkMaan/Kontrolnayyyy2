using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ApplicationContext Context;
        cooke cookies;
        public Login()
        {
            InitializeComponent();
            Context = new ApplicationContext();
            cookies = new cooke();
        }

        private bool IsValidUser(string login, string password)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.users.FirstOrDefault(u => u.login == login && u.password == password);
                return user != null; // Если пользователь найден, возвращаем true
            }
        }
        private User SearchUser(string login)
        {
            foreach (var i in Context.users.ToList())
            {
                if (i.login == login )
                {
                    
                    return i;
                }
               
            }
                    return null;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = login.Text;
            string Password = password.Text;

            // Проверка на null или пустые строки
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.");
                return; 
            }

            if (IsValidUser(Login, Password))
            {
               
                cookies.RememberUser(SearchUser(Login));

                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("НЕВЕРНЫЕ ДАННЫЕ");
            }

        }

        public cooke Cooke
        {
            get { return cookies; }
        }
        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
           
            if (reg.ShowDialog() == true)
            {

                MessageBox.Show("регестрация успешна");
              
            }
            else
            {
                MessageBox.Show("регестрация не  успешна");

            }

        }
    }
}
