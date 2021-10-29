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
    /// Interaction logic for PageListParts.xaml
    /// </summary>
    public partial class PageListParts : System.Windows.Controls.Page
    {
        private Device category;
        private List<Part> parts = new List<Part>();
        private User user = App.User;
        private List<string> comboBoxList = new List<string>
        {
            "По умолчанию",
            "По убыванию",
            "По возрастанияю"
        };

        public PageListParts(Device category)
        {
            this.category = category;
            InitializeComponent();
            BrandComboBox.ItemsSource = App.db.Brands.ToList();
            SparePartComboBox.ItemsSource = category.SparePart.ToList();
            TitleCategory.DataContext = category;
            GeneratePartsCategory();
            PartsListView.ItemsSource = parts;
            ComboBox.ItemsSource = comboBoxList;
        }

        private void GeneratePartsCategory()
        {
            foreach (var sparePart in category.SparePart)
            {
                parts.AddRange(sparePart.Parts);
            }
        }

        private void ButtonInBasket_Click(object sender, MouseButtonEventArgs e)
        {
            user.BasketParts.Add((sender as Border).DataContext as Part);
        }
        
        private void PartClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PartPage((sender as Border).DataContext as Part));
        }
        
        private void UpdateList(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ResetFiter(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
