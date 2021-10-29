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
    /// Interaction logic for PageOrder.xaml
    /// </summary>
    public partial class PageOrder : System.Windows.Controls.Page
    {
        private User user = App.User;
        private Order order = new Order();

        public PageOrder()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
        
        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
