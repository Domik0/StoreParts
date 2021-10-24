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

namespace StoreParts.Page
{
    /// <summary>
    /// Interaction logic for StartPageScreen.xaml
    /// </summary>
    public partial class StartPageScreen : System.Windows.Controls.Page
    {
        public StartPageScreen()
        {
            InitializeComponent();
            NewPartsListView.ItemsSource = App.db.Parts.OrderByDescending(p => p.Id).Take(10).ToList();
            if (App.User.Parts.Count > 0)
            {
                BasketPartsListView.ItemsSource = App.User.Parts;
            }
            else
            {
                BasketPartsListView.Visibility = Visibility.Hidden;
                NotKnowBox.Visibility = Visibility.Visible;
            }
        }

        private void SelectNewPartsClick(object sender, SelectionChangedEventArgs e)
        {
            if (NewPartsListView.SelectedItem != null)
            {
                NavigationService.Navigate(new PartPage(NewPartsListView.SelectedItem as Part));
                NewPartsListView.SelectedItem = null;
            }
        }

        private void SelectBasketPartsClick(object sender, SelectionChangedEventArgs e)
        {
            if (BasketPartsListView.SelectedItem != null)
            {
                NavigationService.Navigate(new PartPage(BasketPartsListView.SelectedItem as Part));
                BasketPartsListView.SelectedItem = null;
            }
        }
    }
}
