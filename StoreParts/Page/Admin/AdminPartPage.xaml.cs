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
    /// Interaction logic for AdminPartPage.xaml
    /// </summary>
    public partial class AdminPartPage : System.Windows.Controls.Page
    {
        public AdminPartPage()
        {
            InitializeComponent();
            UpdateListView();
        }

        public void UpdateListView()
        {
            PartListView.ItemsSource = null;
            PartListView.ItemsSource = App.db.Parts.ToList();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length == 0)
            {
                PartListView.ItemsSource = App.db.Parts.ToList();
            }
            else
            {
                PartListView.ItemsSource = App.db.Parts.ToList().Where(p => p.Title.ToLower().Contains(Search.Text.ToLower())
                                                                            || p.Brand.Title.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
        }

        private void AddPart(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminPartInfoPage(this));
        }

        private void OpenPart(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminPartInfoPage(this, PartListView.SelectedItem as Part));
        }
    }
}
