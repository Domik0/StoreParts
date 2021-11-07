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
    /// Interaction logic for AdminOrderAddPartPage.xaml
    /// </summary>
    public partial class AdminOrderAddPartPage : System.Windows.Controls.Page
    {
        private AdminOrderInfoPage page;

        public AdminOrderAddPartPage(AdminOrderInfoPage page)
        {
            this.page = page;
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

        private void SelectPart(object sender, MouseButtonEventArgs e)
        {
            page.AddPartInList((sender as Border).DataContext as Part);
            NavigationService.GoBack();
        }
    }
}
