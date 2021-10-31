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
    /// Interaction logic for AdminUserPage.xaml
    /// </summary>
    public partial class AdminUserPage : System.Windows.Controls.Page
    {
        public AdminUserPage()
        {
            InitializeComponent();
            UpdateListView();
        }

        void UpdateListView()
        {
            UserListView.ItemsSource = null;
            UserListView.ItemsSource = App.db.Users.ToList();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
         
        private void ButtonSearchClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddUser(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void Update(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
