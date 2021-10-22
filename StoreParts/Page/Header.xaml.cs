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

namespace StoreParts
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : System.Windows.Controls.Page
    {
        public Header()
        {
            User user = App.User;
            InitializeComponent();
            ClientProfile.Text = user.Name.Substring(0, 2).ToUpper();
        }
        
        private void BasketClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClientProfileClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonSearchClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
