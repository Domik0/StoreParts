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
    /// Interaction logic for AdminBrandInfoWindow.xaml
    /// </summary>
    public partial class AdminBrandInfoWindow : Window
    {
        private AdminBrandPage page;
        private Brand brand;

        public AdminBrandInfoWindow(AdminBrandPage page)
        {
            this.page = page;
            InitializeComponent();
        }

        public AdminBrandInfoWindow(AdminBrandPage page, Brand brand)
        {
            this.page = page;
            this.brand = brand;
            InitializeComponent();
            brandTitle.DataContext = brand;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (brand == null)
            {
                brand = new Brand()
                {
                    Id = App.db.Brands.Count() + 1
                };
                App.db.Brands.Add(brand);
            }
            brand.Title = brandTitle.Text;

            page.UpdateListView();
            App.db.SaveChanges();
            this.Close();
        }
    }
}
