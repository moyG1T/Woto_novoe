using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woto_novoe.Data
{
    public partial class Product_Order
    {
        public decimal GetTotalCost
        {
            get
            {
                return (decimal)Count * Product.GetDiscountCost;
            }
        }
    }
}
