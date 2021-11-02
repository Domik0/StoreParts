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
using System.Windows.Shapes;

namespace StoreParts.Page.Admin
{
    /// <summary>
    /// Interaction logic for AdminSparePartInfoWindow.xaml
    /// </summary>
    public partial class AdminSparePartInfoWindow : Window
    {
        private AdminDeviceSparePartPage page;
        private SparePart sparePart;

        public AdminSparePartInfoWindow(AdminDeviceSparePartPage page)
        {
            this.page = page;
            InitializeComponent();
            deviceComboBox.ItemsSource = App.db.Devices.ToList();
        }

        public AdminSparePartInfoWindow(AdminDeviceSparePartPage page, SparePart sparePart)
        {
            this.page = page;
            this.sparePart = sparePart;
            InitializeComponent();
            deviceComboBox.ItemsSource = App.db.Devices.ToList();
            deviceComboBox.SelectedItem = sparePart.Device;
            SparePartTitle.DataContext = sparePart;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (sparePart == null)
            {
                sparePart = new SparePart()
                {
                    Id = App.db.Devices.Count() + 1
                };
                App.db.SpareParts.Add(sparePart);
            }
            sparePart.Device = deviceComboBox.SelectedItem as Device;
            sparePart.Title = SparePartTitle.Text;

            page.UpdateSparePartListView();
            App.db.SaveChanges();
            this.Close();
        }
    }
}
