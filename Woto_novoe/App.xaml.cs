using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Woto_novoe.Comps;
using Woto_novoe.Data;

namespace Woto_novoe
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShop_woto_novoeEntities db = new HardwareShop_woto_novoeEntities();
        public static bool isModerator = true;

        public static MainWindow mainWindow;
        public static ProductList productList;
    }
}
