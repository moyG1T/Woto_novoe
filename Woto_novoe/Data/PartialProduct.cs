using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Woto_novoe.Data;

namespace Woto_novoe.Data
{
    public partial class Product
    {
        public string GetAverageFeedback
        {
            get
            {
                double avg = 0;
                if (Feedback.Count() == 0)
                {
                    return "Оценок нет";
                }
                else
                {
                    foreach (var item in Feedback)
                        avg += item.Evaluation;

                    return $"★ {avg / Feedback.Count():f1}";
                }
            }
        }
        public string GetFeedbackAmount
        {
            get
            {
                if (Feedback.Count() == 0)
                    return "Отзывов нет"; 
                if (Feedback.Count() == 1)
                    return $"{Feedback.Count()} отзыв";
                else if (Feedback.Count() > 1 && Feedback.Count() < 5)
                    return $"{Feedback.Count()} отзыва";
                else
                    return $"{Feedback.Count()} отзывов";
            }
        }
        public Visibility FeedbackVisibility
        {
            get
            {
                if (Feedback.Count() == 0)
                    return Visibility.Collapsed;
                else 
                    return Visibility.Visible;
            }
        }

        public decimal GetDiscountCost
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return (decimal)Cost;
                else
                    return (decimal)Cost - ((decimal)Cost * (decimal)Discount) / 100;
            }
        }

        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public Visibility DiscountVisibility
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
        }
    }
}
