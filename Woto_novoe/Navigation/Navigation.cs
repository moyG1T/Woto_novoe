using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Woto_novoe.Comps;
using Woto_novoe.Data;

namespace Woto_novoe.Navigation
{
    internal class Navigation
    {
        private static List<PageParticulars> history = new List<PageParticulars>();
        public static MainWindow mainWindow;
        public static ProductList productList;
        public static ProductUserControl productUserControl;

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

        private static void RefreshPageParticularts(PageParticulars page)
        {
            mainWindow.ModeratorModeText.Text = App.isModerator ? "Режим модератора активен" : "Режим модератора не активен";

            mainWindow.ModeratorModeText.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;
            mainWindow.LogOutAsModeratorButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Hidden;
            productList.AddProductButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;

            productList.ProductActionListText.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;
            //productList.AddProductButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;

            productUserControl.EditProductButton.Visibility = App.isModerator ? Visibility.Visible : Visibility.Collapsed;

            mainWindow.Title = page.Title;
            mainWindow.ScreenTitleText.Text = page.Title;
            mainWindow.MainFrame.Navigate(page.Page);
        }

        public static void DropHistory()
        {
            App.isModerator = false;
            history.Clear();
            Navigate(Constants.PRODUCT_LIST_SCREEN);
        }
    }
}
