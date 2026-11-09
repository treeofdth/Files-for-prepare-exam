using LR4__2.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLog.Text.Trim();
            string pass = tbPass.Password;
            string f_name = tbFirstName.Text.Trim();
            string l_name = tbLastName.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(f_name) || string.IsNullOrEmpty(l_name))
            {
                MessageBox.Show("Full all fields!");
                return;
            }

            using var db = new BeautySalonDbContext();

            if (db.Users.Any(l => l.Login == login))
            {
                MessageBox.Show("User with this login is exists, alter your login!");
            }

            var user = new User
            {
                Login = login,
                Password = pass,
                FirstName = f_name,
                LastName = l_name,
                Role = "User"
            };

            db.Users.Add(user);
            db.SaveChanges();

            MessageBox.Show("Registration has successful");

            NavigationService?.Navigate(new Brands());
        }

        private void btnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login());
        }
    }
}
