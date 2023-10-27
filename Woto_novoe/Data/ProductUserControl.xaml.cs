﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace Woto_novoe.Data
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        Product product;
        public ProductUserControl(Product product)
        {
            this.product = product;
            InitializeComponent();

            Navigation.Navigation.productUserControl = this;

            ProductImage.Source = GetImage(product.MainImage);
            ProductNameText.Text = product.Title;
            CostWDiscountText.Text = $"{product.GetDiscountCost:0}₽";
            CostText.Text = $"{product.Cost:0}₽";
            CostText.Visibility = product.CostVisibility;
            
            RatingText.Text = product.GetAverageFeedback;
            RatingText.Visibility = product.FeedbackVisibility;
            ReviewAmountText.Text = product.GetFeedbackAmount;
            DiscountImageText.Text = $"-{product.Discount}%";
            DiscountImageText.Visibility = product.DiscountVisibility;
            EditProductButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;
        }

        private BitmapImage GetImage(byte[] byteImage)
        {
            if (byteImage != null)
            {
                MemoryStream memoryStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = memoryStream;
                image.EndInit();
                return image;
            }
            else
                return new BitmapImage(new Uri(@"\Resources\zaglushka.png", UriKind.Relative));
        }
    }
}
