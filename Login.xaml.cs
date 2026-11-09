using LR4__2.Models;
using System;
using System.Collections.Generic;
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

namespace LR4__2.Views
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLog.Text.Trim();
            string password = tbPass.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Full all fields!");
                return;
            }

            using var db = new BeautySalonDbContext();

            var user = db.Users.FirstOrDefault(l => l.Login == login && l.Password == password);

            CurrentUser.User = user;

            if (user != null)
            {
                MessageBox.Show($"Welcome! {user.FirstName}");
                NavigationService?.Navigate(new Brands());
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Register());
        }
    }
}
