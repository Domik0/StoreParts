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
    /// Interaction logic for AdminStoreInfo.xaml
    /// </summary>
    public partial class AdminStoreInfo : System.Windows.Controls.Page
    {
        private AdminStorePage page;
        private Store store;

        public AdminStoreInfo(AdminStorePage page)
        {
            this.page = page;
            InitializeComponent();
        }

        public AdminStoreInfo(AdminStorePage page, Store store)
        {
            this.page = page;
            this.store = store;
            InitializeComponent();
            DataContext = store;
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveChange(object sender, RoutedEventArgs e)
        {
            if (store == null)
            {
                store = new Store()
                {
                    Id = App.db.Stores.Count() + 1
                };
                App.db.Stores.Add(store);
            }
            store.City = CityTextBox.Text;
            store.Address = AddressTextBox.Text;
            store.TimeWork = TimeWorkTextBox.Text;
            store.Phone = PhoneTextBox.Text;

            App.db.SaveChanges();
            page.UpdateListView();
            NavigationService.GoBack();
        }
    }
}
