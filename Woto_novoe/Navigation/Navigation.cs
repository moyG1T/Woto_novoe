using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woto_novoe.Navigation
{
    internal class Navigation
    {
        private static List<PageParticulars> history = new List<PageParticulars>();
        public static MainWindow mainWindow;

        public static void Navigate(PageParticulars page)
        {
            history.Add(page);
            RefreshPageParticularts(page);
        }

        public static void NavigateAndPop(PageParticulars page)
        {
            history.RemoveAt(history.Count - 1);
            RefreshPageParticularts(history[history.Count - 1]);
        }

        private static void RefreshPageParticularts(PageParticulars page)
        {
            mainWindow.Title = page.Title;
            mainWindow.MainFrame.Navigate(page.Page);
        }

        public static void DropHistory()
        {
            App.isModerator = false;
            history.Clear();
        }
    }
}
