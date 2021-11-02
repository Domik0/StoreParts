using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Xceed.Wpf.Toolkit.Primitives;

namespace StoreParts.Page
{
    /// <summary>
    /// Interaction logic for PageListParts.xaml
    /// </summary>
    public partial class PageListParts : System.Windows.Controls.Page
    {
        private string search;
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
            ComboBoxSort.ItemsSource = comboBoxList;
        }

        public PageListParts(string search)
        {
            this.search = search;
            InitializeComponent();
            BrandComboBox.ItemsSource = App.db.Brands.ToList();
            SparePartComboBox.ItemsSource = App.db.SpareParts.ToList();
            TitleCategory.Text = $"Результат по поиску \"{TitleCategory}\"";
            parts = App.db.Parts.Where(p => p.Brand.Title.ToLower().Contains(search.ToLower()) 
                                                || p.Title.ToLower().Contains(search.ToLower()) 
                                                || p.Description.ToLower().Contains(search.ToLower()) 
                                                || p.SparePart.Title.ToLower().Contains(search.ToLower())).ToList();
            PartsListView.ItemsSource = parts;
            ComboBoxSort.ItemsSource = comboBoxList;
        }

        private void GeneratePartsCategory()
        {
            parts = new List<Part>();
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
            if (search == null)
            {
                GeneratePartsCategory();
            }
            else
            {
                parts = App.db.Parts.Where(p => p.Brand.Title.ToLower().Contains(search.ToLower())
                                                || p.Title.ToLower().Contains(search.ToLower())
                                                || p.Description.ToLower().Contains(search.ToLower())
                                                || p.SparePart.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            List<Part> partsFilter = new List<Part>();
            foreach (var part in parts)
            {
                if ((BrandComboBox.SelectedItems.Contains(part.Brand) || BrandComboBox.SelectedItems.Count == 0) &&
                    (SparePartComboBox.SelectedItems.Contains(part.SparePart) || SparePartComboBox.SelectedItems.Count == 0) &&
                    priceSlider.Value >= part.RetailPrice)
                {
                    partsFilter.Add(part);
                }
            }

            PartsListView.ItemsSource = null;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(PartsListView.ItemsSource);
            switch (ComboBoxSort.SelectedItem)
            {
                case "По умолчанию":
                    PartsListView.ItemsSource = partsFilter;
                    break;
                case "По убыванию":
                    PartsListView.ItemsSource = partsFilter.OrderByDescending(p => p.RetailPrice);
                    break;
                case "По возрастанияю":
                    PartsListView.ItemsSource = partsFilter.OrderBy(p => p.RetailPrice);
                    break;
            }
        }

        private void ResetFiter(object sender, RoutedEventArgs e)
        {
            PartsListView.ItemsSource = parts;
            ComboBoxSort.SelectedItem = "По умолчанию";
            priceSlider.Value = 15000;
            SparePartComboBox.SelectedItem = null;
            BrandComboBox.SelectedItem = null;
        }
    }
}
