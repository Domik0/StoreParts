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
    /// Interaction logic for MainСategoryPage.xaml
    /// </summary>
    public partial class MainСategoryPage : System.Windows.Controls.Page
    {
        public MainСategoryPage()
        {
            InitializeComponent();
            CategoryListView.ItemsSource = App.db.Devices.ToList();
            NewPartsListView.ItemsSource = App.db.Parts.OrderByDescending(p => p.Id).Take(10).ToList();
            if (App.User.BasketParts.Count > 0)
            {
                BasketPartsListView.ItemsSource = App.User.BasketParts;
            }
            else
            {
                BasketPartsListView.Visibility = Visibility.Hidden;
                NotKnowBox.Visibility = Visibility.Visible;
            }
        }

        private void SelectCategoryClick(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new PageListParts(CategoryListView.SelectedItem as Device));
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
