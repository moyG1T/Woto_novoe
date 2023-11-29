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
using Woto_novoe.Data;

namespace Woto_novoe.Comps
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        private int cost;
        public OrderList()
        {
            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            Order lastOrder = App.db.Order.OrderByDescending(x => x.Id).FirstOrDefault();
            IEnumerable<Product_Order> product_orders = App.db.Product_Order.Where(x => x.OrderId == lastOrder.Id && lastOrder.StatusName == "Не выполнено");


            foreach (Product_Order item in product_orders)
            {
                cost += (int)(item.Product.Cost * item.Count);
                OrderListWrapPanel.Children.Add(new ProductOrdering(item));
            };
            TotalCostText.Text = cost.ToString();
        }
    }
}
