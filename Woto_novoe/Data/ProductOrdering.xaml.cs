using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Data.OleDb;
using System.Data.SqlClient;
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
using System.Configuration;

namespace Woto_novoe.Data
{
    /// <summary>
    /// Логика взаимодействия для ProductOrdering.xaml
    /// </summary>
    public partial class ProductOrdering : UserControl
    {
        Product_Order product_order;
        decimal? currentCost;
        private string connectionString;


        public ProductOrdering(Product_Order product_order)
        {
            InitializeComponent();
            this.product_order = product_order;
            DataContext = this.product_order;

            CountText.Text = product_order.Count.ToString();

            connectionString = "data source=Welcome\\MYMSSQLSERVER;initial catalog=HardwareShop_woto_novoe;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            //RefreshCost();

            //OrderList orderList = new OrderList();
            //orderList.Refresh();
        }


        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string query = $"DELETE FROM PRODUCT_ORDER " +
                $"WHERE PRODUCTID = {product_order.Product.Id} AND ORDERID = {product_order.OrderId}";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(CountText.Text) < 99)
                CountText.Text = (int.Parse(CountText.Text) + 1).ToString();
            OrderList orderList = new OrderList();
            orderList.Refresh();
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
