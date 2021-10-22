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
    /// Interaction logic for MainСategoryPage.xaml
    /// </summary>
    public partial class MainСategoryPage : System.Windows.Controls.Page
    {
        public MainСategoryPage()
        {
            InitializeComponent();
            CategoryListView.ItemsSource = App.db.Devices.ToList();
        }

        private void SelectCategoryClick(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
