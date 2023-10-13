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
            var productList = App.db.Product.ToList();
            var feedbackList = App.db.Feedback.ToList();

            foreach (var item in productList)
            {
                ProductWrap.Children.Add(new ProductUserControl(item));
            }
        }

    }
}
