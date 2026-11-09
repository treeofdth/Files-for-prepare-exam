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
    /// Логика взаимодействия для BrandDetails.xaml
    /// </summary>
    public partial class BrandDetails : Page
    {
        public BrandDetails(Product product)
        {
            InitializeComponent();

            tbTitle.Text = product.Title;
            tbManufacturer.Text = $"Brand: {product.Manufacturer?.Name ?? "Not specified"}";
            tbPrice.Text = $"Price: {product.Cost:N2}";
            tbDescription.Text = product.Description ?? "No descriptions available";

            if (!string.IsNullOrEmpty(product.MainImagePath))
            {
                try
                {
                    imgProd.Source = new BitmapImage(new Uri(product.MainImagePath, UriKind.RelativeOrAbsolute));
                }
                catch
                {

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
