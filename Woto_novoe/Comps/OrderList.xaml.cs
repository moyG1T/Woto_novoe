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
using System.Windows.Threading;
using Woto_novoe.Data;

namespace Woto_novoe.Comps
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        private int cost;
        private Order lastOrder;


        public OrderList()
        {
            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            lastOrder = App.db.Order.OrderByDescending(x => x.Id).FirstOrDefault();
            IEnumerable<Product_Order> product_orders = App.db.Product_Order.Where(x => x.OrderId == lastOrder.Id && lastOrder.StatusName == "Не выполнено");


            foreach (Product_Order item in product_orders)
            {
                cost += (int)(item.Product.GetDiscountCost * item.Count);
                OrderListWrapPanel.Children.Add(new ProductOrdering(item));
            };
            TotalCostText.Text = $"{cost:0}₽" ;
        }

        private void DoOrder_Click(object sender, RoutedEventArgs e)
        {
            App.db.Order.OrderByDescending(x => x.Id).FirstOrDefault().StatusName = "Выполнено";
            App.db.SaveChanges();

            Navigation.Navigation.Navigate(new Navigation.PageParticulars("Главная", new ProductList()));
            MessageBox.Show("Заказ выполнен");
        }
    }
}
