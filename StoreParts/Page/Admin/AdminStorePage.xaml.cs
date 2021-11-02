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

namespace StoreParts.Page.Admin
{
    /// <summary>
    /// Interaction logic for AdminStorePage.xaml
    /// </summary>
    public partial class AdminStorePage : System.Windows.Controls.Page
    {
        public AdminStorePage()
        {
            InitializeComponent();
            UpdateListView();
        }

        public void UpdateListView()
        {
            StoreListView.ItemsSource = null;
            StoreListView.ItemsSource = App.db.Stores.ToList();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length == 0)
            {
                StoreListView.ItemsSource = App.db.Stores.ToList();
            }
            else
            {
                StoreListView.ItemsSource = App.db.Stores.ToList().Where(s => s.City.ToLower().Contains(Search.Text.ToLower())
                                                                              || s.Address.ToLower().Contains(Search.Text.ToLower())
                                                                              || s.Phone.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
        }
        
        private void AddStore(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminStoreInfo(this));
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminStoreInfo(this, StoreListView.SelectedItem as Store));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.db.Stores.Remove(StoreListView.SelectedItem as Store);
                App.db.SaveChanges();
            }
        }
    }
}
