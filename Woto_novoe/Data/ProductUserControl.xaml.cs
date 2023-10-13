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
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl(Product product)
        {
            InitializeComponent();

            // ProductImage. = new BitmapImage(new Uri(""));
            // RatingText.Text = product.

            ProductNameText.Text = product.Title;
            CostWDiscountText.Text = product.GetDiscountCost;
            CostText.Text = product.Cost.ToString("0₽");
            CostText.Visibility = product.CostVisibility;
            
           // RatingText.Text = product.Feedback.ToList().Count().ToString();
            RatingText.Text = product.GetAverageFeedback;
            RatingText.Visibility = product.FeedbackVisibility;
            ReviewAmountText.Text = product.GetFeedbackAmount;
            DiscountImageText.Text = $"-{product.Discount.ToString()}%";
            DiscountImageText.Visibility = product.DiscountVisibility;
        }
    }
}
