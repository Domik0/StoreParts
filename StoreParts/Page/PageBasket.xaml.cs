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
    /// Interaction logic for PageBasket.xaml
    /// </summary>
    public partial class PageBasket : System.Windows.Controls.Page
    {
        private User user = App.User;
        private double? SumBasket
        {
            get
            {
                double? sum = 0.0;
                foreach (var item in user.BasketParts)
                {
                    sum += item.RetailPrice;
                }
                return sum;
            }
            set
            {
                SumBasket = value;
            }
        }

        public PageBasket()
        {
            InitializeComponent();
            CountPartInBasket.DataContext = user.BasketParts.Count;
            SummPartInBasket.DataContext = SumBasket;
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

        private void ButtonOnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainСategoryPage());
        }

        private void ButtonOrder_Click(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void SelectBasketPartsClick(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
