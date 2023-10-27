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
        public static List<PageParticulars> pages = new List<PageParticulars>
        {
            new PageParticulars("Авторизация", new Authorization()),
            new PageParticulars("Главная", new ProductList())
        };
    }
}
