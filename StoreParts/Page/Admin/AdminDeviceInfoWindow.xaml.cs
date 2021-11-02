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
    /// Interaction logic for AdminDeviceInfoWindow.xaml
    /// </summary>
    public partial class AdminDeviceInfoWindow : Window
    {
        private AdminDeviceSparePartPage page;
        private Device device;

        public AdminDeviceInfoWindow(AdminDeviceSparePartPage page)
        {
            this.page = page;
            InitializeComponent();
        }

        public AdminDeviceInfoWindow(AdminDeviceSparePartPage page, Device device)
        {
            this.page = page;
            this.device = device;
            InitializeComponent();
            deviceTitle.DataContext = device;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (device == null)
            {
                device = new Device()
                {
                    Id = App.db.Devices.Count() + 1
                };
                App.db.Devices.Add(device);
            }
            device.Title = deviceTitle.Text;

            page.UpdateDeviceListView();
            App.db.SaveChanges();
            this.Close();
        }
    }
}
