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
        public ProductOrdering(Product_Order product_order)
        {
            InitializeComponent();
            this.product_order = product_order;
            DataContext = this.product_order;
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
