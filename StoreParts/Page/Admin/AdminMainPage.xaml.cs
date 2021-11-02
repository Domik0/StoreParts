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
    /// Interaction logic for AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : System.Windows.Controls.Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void ClientProfileClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenUserList(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AdminUserPage());
        }

        private void OpenDeviceSparePartList(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AdminDeviceSparePartPage());
        }

        private void OpenStoreList(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AdminStorePage());
        }

        private void OpenBrandList(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AdminBrandPage());
        }
    }
}
