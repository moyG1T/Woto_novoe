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
        //public static PC7_Entities db = new PC7_Entities();
        public static Home_Entities db = new Home_Entities();
        public static bool isModerator = false;

        public static MainWindow mainWindow;
        public static ProductList productList;
    }
}
