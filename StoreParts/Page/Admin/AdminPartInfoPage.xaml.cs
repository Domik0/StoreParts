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
    /// Interaction logic for AdminPartInfoPage.xaml
    /// </summary>
    public partial class AdminPartInfoPage : System.Windows.Controls.Page
    {
        private AdminPartPage page;
        private Part part;

        public AdminPartInfoPage(AdminPartPage page)
        {
            this.page = page;
            InitializeComponent();
            brandComboBox.ItemsSource = App.db.Brands.ToList();
            SparePartComboBox.ItemsSource = App.db.SpareParts.ToList();
        }

        public AdminPartInfoPage(AdminPartPage page, Part part)
        {
            this.page = page;
            this.part = part;
            InitializeComponent();
            brandComboBox.ItemsSource = App.db.Brands.ToList();
            brandComboBox.SelectedItem = part.Brand;
            SparePartComboBox.ItemsSource = App.db.SpareParts.ToList();
            SparePartComboBox.SelectedItem = part.SparePart;
            DataContext = part;
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveChange(object sender, RoutedEventArgs e)
        {
            if (part == null)
            {
                part = new Part()
                {
                    Id = App.db.Parts.Count() + 1
                };
                App.db.Parts.Add(part);
            }

            App.db.Images.Remove(part.FirstImage);
            App.db.Images.Add(new Image()
            {
                ImagePath = ImagePathTextBox.Text,
                Part = part
            });
            part.Title = TitleTextBox.Text;
            part.RetailPrice = Convert.ToDouble(RetailPriceTextBox.Text);
            part.CountStorage = Convert.ToInt32(CountStorageTextBox.Text);
            part.Description = DescriptionTextBox.Text;
            part.Brand = brandComboBox.SelectedItem as Brand;

            App.db.SaveChanges();
            page.UpdateListView();
            NavigationService.GoBack();
        }
    }
}
