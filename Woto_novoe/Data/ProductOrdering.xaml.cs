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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Woto_novoe.Data
{
    /// <summary>
    /// Логика взаимодействия для ProductOrdering.xaml
    /// </summary>
    public partial class ProductOrdering : UserControl
    {
        Product_Order product_order;
        decimal? currentCost;
        public ProductOrdering(Product_Order product_order)
        {
            InitializeComponent();
            this.product_order = product_order;
            DataContext = this.product_order;

            CountText.Text = product_order.Count.ToString();
            RefreshCost();
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(CountText.Text) < 99)
                CountText.Text = (int.Parse(CountText.Text) + 1).ToString();
            RefreshCost();
        }

        private void DecrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(CountText.Text) > 1)
                CountText.Text = (int.Parse(CountText.Text) - 1).ToString();
            RefreshCost();
        }

        private void RefreshCost()
        {
            currentCost = product_order.Product.Cost;
            currentCost *= int.Parse(CountText.Text);
            TotalCostPerProductText.Text = $"{currentCost:0}₽";
        }
    }
}
