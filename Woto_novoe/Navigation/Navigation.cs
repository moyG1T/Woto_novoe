using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static void NavigateAndPop()
        {
            if (history.Count > 1)
            {
                history.RemoveAt(history.Count - 1);
                RefreshPageParticularts(history[history.Count - 1]);
            }
        }

        private static void RefreshPageParticularts(PageParticulars page)
        {
            mainWindow.Title = page.Title;
            mainWindow.MainFrame.Navigate(page.Page);
            mainWindow.ModeratorModeText.Text = App.isModerator ? "Режим модератора активен" : "Режим модератора не активен";
            mainWindow.ModeratorModeText.Visibility = App.isModerator ? Visibility.Visible : Visibility.Hidden;
        }

        public static void DropHistory()
        {
            App.isModerator = false;
            history.Clear();
        }
    }
}
