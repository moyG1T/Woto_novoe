using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Woto_novoe.Data
{
    public partial class Product
    {
        public string GetDiscountCost
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return $"{Cost:0}₽";
                else
                    return $"{Cost - (Cost * (decimal)Discount) / 100:0}₽";
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
    }
}
