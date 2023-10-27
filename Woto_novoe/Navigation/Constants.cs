using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woto_novoe.Comps;

namespace Woto_novoe.Navigation
{
    internal class Constants
    {
        static public PageParticulars LOGIN_SCREEN = new PageParticulars("Авторизация", new Authorization());
        static public PageParticulars PRODUCT_LIST_SCREEN = new PageParticulars("Главная", new ProductList());
    }
}
