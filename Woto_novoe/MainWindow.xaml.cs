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

            MainFrame.Navigate(new ProductList());

            //var path = @"C:\Users\212119\Desktop\.pics";
            /*foreach (var item in App.db.Product.ToArray())
            {
                item.MainImage = File.ReadAllBytes(item.ImagePath);
            }
            App.db.SaveChanges();*/
        }
    }
}
