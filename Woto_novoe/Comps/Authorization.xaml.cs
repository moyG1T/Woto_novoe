using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Woto_novoe.Navigation;

namespace Woto_novoe.Comps
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthBox.Text == "000")
            {
                App.isModerator = true;
                AuthBox.Text = "";
                Navigation.Navigation.NavigateAsModer(new PageParticulars("Главная", new ProductList()));
            }
            else
            {
                ErrorText.Text = "Неправильно";
                await Task.Delay(5000);
                ErrorText.Text = "";
            }
        }
    }
}
