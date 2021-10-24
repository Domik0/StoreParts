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
    /// Interaction logic for PartPage.xaml
    /// </summary>
    public partial class PartPage : System.Windows.Controls.Page
    {
        public PartPage(Part part)
        {
            InitializeComponent();
            DataContext = part;
            if (part.CountStorage == 0)
            {
                BorderStatusCountNull.Visibility = Visibility.Visible;
                BorderStatusCount.Visibility = Visibility.Hidden;
            }
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonBasket_Click(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
