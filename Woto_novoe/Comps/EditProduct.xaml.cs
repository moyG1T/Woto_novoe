using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Woto_novoe.Data;

namespace Woto_novoe.Comps
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        private Product product;
        public EditProduct(Product product)
        {
            InitializeComponent();
            this.product = product;
            DataContext = this.product;
        }

        private void SelectPicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|All files (*.*)|*.*"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                product.MainImage = File.ReadAllBytes(openFile.FileName);
                EditingProductImage.Source = new BitmapImage(new Uri(openFile.FileName)); ;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Title.Text) && !string.IsNullOrEmpty(Cost.Text) && !string.IsNullOrEmpty(Discount.Text))
            {
                if (product.Id != 0)
                {
                    App.db.SaveChanges();
                    Navigation.Navigation.Navigate(new Navigation.PageParticulars("Главная", new ProductList()));
                    MessageBox.Show("Сохранено");

                }
                else if (product.Id == 0)
                {
                    App.db.Product.Add(product);
                    App.db.SaveChanges();
                    Navigation.Navigation.Navigate(new Navigation.PageParticulars("Главная", new ProductList()));
                    MessageBox.Show("Добавлено");
                }
            }
            else
                MessageBox.Show("Что-то пошло не так");
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
