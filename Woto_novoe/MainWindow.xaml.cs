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
using Woto_novoe.Comps;
using Woto_novoe.Navigation;

namespace Woto_novoe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.mainWindow = this;
            Navigation.Navigation.Navigate(new PageParticulars("Главная", new ProductList()));
            //var path = @"C:\Users\212119\Desktop\.pics";
            /*foreach (var item in App.db.Product.ToArray())
            {
                item.MainImage = File.ReadAllBytes(item.ImagePath);
            }
            App.db.SaveChanges();*/
        }

        private void LogInAsModeratorButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.Navigate(Constants.pages[0]);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.NavigateAndPop();
        }

        private void LogOutAsModeratorButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.DropHistory();
            Navigation.Navigation.Navigate(Constants.pages[1]);
        }

        private void GoToOrder_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.Navigate(new PageParticulars("Корзина", new OrderList()));
        }
    }
}
