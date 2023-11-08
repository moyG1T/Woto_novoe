using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Woto_novoe.Comps;
using Woto_novoe.Data;

namespace Woto_novoe.Navigation
{
    internal class Navigation
    {
        private static List<PageParticulars> history = new List<PageParticulars>();

        public static void Navigate(PageParticulars page)
        {
            history.Add(page);
            RefreshPageParticularts(page);
        }

        public static void NavigateAndPop()
        {
            if (history.Count >= 2)
            {
                history.RemoveAt(history.Count - 1);
                RefreshPageParticularts(history[history.Count - 1]);
            }
        }
        public static void NavigateAsModer(PageParticulars page)
        {
            history.Clear();
            Navigate(page);
        }

        private static void RefreshPageParticularts(PageParticulars page)
        {
            App.mainWindow.ModeratorModeText.Text = App.isModerator ? "Режим модератора активен" : "Режим модератора не активен";
            App.mainWindow.GoBackButton.Visibility = history.Count > 1 ? Visibility.Visible : Visibility.Hidden;
            App.mainWindow.LogInAsModeratorButton.Visibility = App.isModerator ? Visibility.Collapsed: Visibility.Visible;

            App.mainWindow.ModeratorModeText.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;
            App.mainWindow.LogOutAsModeratorButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Hidden;

            App.productList.AddProductButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;
            App.productList.ProductActionListText.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;
            App.productList.AddProductButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;

            App.mainWindow.Title = page.Title;
            App.mainWindow.ScreenTitleText.Text = page.Title;
            App.mainWindow.MainFrame.Navigate(page.Page);
        }

        public static void DropHistory()
        {
            App.isModerator = false;
            history.Clear();
        }
    }
}
