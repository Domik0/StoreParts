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
    /// Interaction logic for AdminBrandPage.xaml
    /// </summary>
    public partial class AdminBrandPage : System.Windows.Controls.Page
    {
        public AdminBrandPage()
        {
            InitializeComponent();
            UpdateListView();
        }

        public void UpdateListView()
        {
            BrandListView.ItemsSource = null;
            BrandListView.ItemsSource = App.db.Brands.ToList();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length == 0)
            {
                BrandListView.ItemsSource = App.db.Brands.ToList();
            }
            else
            {
                BrandListView.ItemsSource = App.db.Brands.ToList().Where(b => b.Title.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
        }

        private void AddBrand(object sender, MouseButtonEventArgs e)
        {
            AdminBrandInfoWindow ab = new AdminBrandInfoWindow(this);
            ab.Show();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            AdminBrandInfoWindow ab = new AdminBrandInfoWindow(this, BrandListView.SelectedItem as Brand);
            ab.Show();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.db.Brands.Remove(BrandListView.SelectedItem as Brand);
                App.db.SaveChanges();
            }
        }
    }
}
