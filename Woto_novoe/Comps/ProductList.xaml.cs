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
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        public ProductList()
        {
            InitializeComponent();

            App.productList = this;

            CostSortCombo.SelectedIndex = 0;
            DiscountSortCombo.SelectedIndex = 0;

            RefreshFilters();
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigation.Navigate(new Navigation.PageParticulars("Добавление продукта", new EditProduct(new Product())));
        }

        private void RefreshFilters()
        {
            IEnumerable<Product> productsList = App.db.Product;

            if (CostSortCombo.SelectedIndex != 0)
            {
                if (CostSortCombo.SelectedIndex == 1)
                    productsList = productsList.OrderBy(x => x.GetDiscountCost);
                else if (CostSortCombo.SelectedIndex == 2)
                    productsList = productsList.OrderByDescending(x => x.GetDiscountCost);
            }

            if (DiscountSortCombo.SelectedIndex != 0)
            {
                if (DiscountSortCombo.SelectedIndex == 1)
                    productsList = productsList.Where(x => x.Discount <= 15);
                else if (DiscountSortCombo.SelectedIndex == 2)
                    productsList = productsList.Where(x => x.Discount >= 15 && x.Discount <= 50);
                else if (DiscountSortCombo.SelectedIndex == 3)
                    productsList = productsList.Where(x => x.Discount >= 50);
            }

            if (SearchBox.Text != "" || SearchBox.Text != null)
            {
                productsList = productsList.Where(x =>
                x.Title.ToLower().Contains(SearchBox.Text.ToLower()) ||
                x.Description.ToLower().Contains(SearchBox.Text.ToLower()));
            }

            ProductWrap.Children.Clear();
            foreach (Product item in productsList)
                ProductWrap.Children.Add(new ProductUserControl(item));
        }

        private void CostSortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => RefreshFilters();

        private void DiscountSortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => RefreshFilters();

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
            => RefreshFilters();

        private void ClearSearchTextButton_Click(object sender, RoutedEventArgs e)
        { 
            SearchBox.Text = "";
            RefreshFilters();
        }

        private void ClearEachFilter_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            CostSortCombo.SelectedIndex = 0;
            DiscountSortCombo.SelectedIndex = 0;
            RefreshFilters();
        }

    }
}
