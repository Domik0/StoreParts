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
    /// Interaction logic for AdminDeviceSparePartPage.xaml
    /// </summary>
    public partial class AdminDeviceSparePartPage : System.Windows.Controls.Page
    {
        public AdminDeviceSparePartPage()
        {
            InitializeComponent();
            UpdateDeviceListView();
            UpdateSparePartListView();
        }

        public void UpdateDeviceListView()
        {
            DeviceListView.ItemsSource = null;
            DeviceListView.ItemsSource = App.db.Devices.ToList();
        }

        public void UpdateSparePartListView()
        {
            SparePartListView.ItemsSource = null;
            SparePartListView.ItemsSource = App.db.SpareParts.ToList();
        }

        private void SearchTextDeviceChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchDevice.Text.Length == 0)
            {
                DeviceListView.ItemsSource = App.db.Devices.ToList();
            }
            else
            {
                DeviceListView.ItemsSource = App.db.Devices.Where(d => d.Title.ToLower().Contains(SearchDevice.Text.ToLower())).ToList();
            }
        }

        private void SearchTextSparePartChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchSparePart.Text.Length == 0)
            {
                SparePartListView.ItemsSource = App.db.SpareParts.ToList();
            }
            else
            {
                SparePartListView.ItemsSource = App.db.SpareParts.Where(sp => sp.Title.ToLower().Contains(SearchDevice.Text.ToLower()) 
                                                                              || sp.Device.Title.ToLower().Contains(SearchDevice.Text.ToLower())).ToList();
            }
        }

        private void AddDevice(object sender, MouseButtonEventArgs e)
        {
            AdminDeviceInfoWindow ad = new AdminDeviceInfoWindow(this);
            ad.Show();
        }

        private void AddSparePart(object sender, MouseButtonEventArgs e)
        {
            AdminSparePartInfoWindow ad = new AdminSparePartInfoWindow(this, DeviceListView.SelectedItem as SparePart);
            ad.Show();
        }

        private void UpdateDevice(object sender, RoutedEventArgs e)
        {
            AdminDeviceInfoWindow ad = new AdminDeviceInfoWindow(this, DeviceListView.SelectedItem as Device);
            ad.Show();
        }

        private void DeleteDevice(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.db.Devices.Remove(DeviceListView.SelectedItem as Device);
                App.db.SaveChanges();
            }
        }

        private void UpdateSparePart(object sender, RoutedEventArgs e)
        {
            AdminSparePartInfoWindow ad = new AdminSparePartInfoWindow(this, SparePartListView.SelectedItem as SparePart);
            ad.Show();
        }

        private void DeleteSparePart(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.db.SpareParts.Remove(SparePartListView.SelectedItem as SparePart);
                App.db.SaveChanges();
            }
        }
    }
}
