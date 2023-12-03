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
        private Product_Order product_order;

        private decimal? currentCost;
        private int? currentCount;

        private SqlConnection sqlConnection;
        private string connectionString;

        public ProductOrdering(Product_Order product_order)
        {
            InitializeComponent();
            this.product_order = product_order;
            DataContext = this.product_order;

            connectionString = "data source=Welcome\\MYMSSQLSERVER;initial catalog=HardwareShop_woto_novoe;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            currentCount = App.db.Product_Order.Where(x => x.ProductId == product_order.Product.Id).FirstOrDefault().Count;
            CountText.Text = currentCount.ToString();
            currentCost = App.db.Product_Order.Where(x => x.ProductId == product_order.Product.Id).FirstOrDefault().Product.Cost;
            TotalCostPerProductText.Text = $"{currentCost * currentCount:0}";
        }


        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string query = $"DELETE FROM PRODUCT_ORDER " +
                $"WHERE PRODUCTID = {product_order.Product.Id} AND ORDERID = {product_order.OrderId}";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void DecrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentCount > 1)
                currentCount--;
            CountText.Text = currentCount.ToString();

            App.db.Product_Order.Where(x => x.ProductId == product_order.Product.Id && x.OrderId == product_order.OrderId).FirstOrDefault().Count = currentCount;
            App.db.SaveChanges();
            TotalCostPerProductText.Text = $"{currentCost * currentCount:0}";
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentCount < 99)
                currentCount++;
            CountText.Text = currentCount.ToString();

            App.db.Product_Order.Where(x => x.ProductId == product_order.Product.Id && x.OrderId == product_order.OrderId).FirstOrDefault().Count = currentCount;
            App.db.SaveChanges();
            TotalCostPerProductText.Text = $"{currentCost * currentCount:0}";
        }
    }
}
