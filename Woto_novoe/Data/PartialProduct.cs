using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woto_novoe.Data
{
    public partial class Product
    {
        public string GetCost
        {
            get
            {
                if (Discount != 0 || Discount != null)
                    return $"{Cost - (Cost * (decimal)Discount)}P";
                else
                    return $"{Cost}";
            }
        }
    }
}
