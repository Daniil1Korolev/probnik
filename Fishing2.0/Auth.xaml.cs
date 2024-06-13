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

namespace Fishing2._0
{
    public partial class Auth : Window
    {
        private AuthService _authService = new AuthService();

        public Auth()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Text;

            bool isAuthenticated = _authService.Authenticate(login, password);

            if (isAuthenticated)
            {
                MessageBox.Show("Вход выполнен успешно!");
                Actives Actives = new Actives();
                Actives.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль.");
            }
        }
    }
}