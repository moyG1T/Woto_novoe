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
    /// Логика взаимодействия для AllOrders.xaml
    /// </summary>
    public partial class AllOrders : Page
    {
        public AllOrders()
        {
            InitializeComponent();

            OrdersListView.ItemsSource = App.db.Order.OrderByDescending(x => x.Status.StatusName).ToList();

            StatusCombo.SelectedIndex = 0;
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Order> orders = App.db.Order.OrderByDescending(x => x.Status.StatusName).ToList();
            if (StatusCombo.SelectedIndex != 0)
                if (StatusCombo.SelectedIndex == 1)
                    orders = App.db.Order.Where(x => x.Status.StatusName == "Не выполнено").ToList();
                else if (StatusCombo.SelectedIndex == 2)
                    orders = App.db.Order.Where(x => x.Status.StatusName == "Выполнено").ToList();

            OrdersListView.ItemsSource = null;
            OrdersListView.ItemsSource = orders;
        }

        private void StatusCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SetTrueButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersListView.SelectedItem != null)
            {
                (OrdersListView.SelectedItem as Order).StatusName = "Выполнено";
                App.db.SaveChanges();
            }
            Refresh();
        }
    }
}
