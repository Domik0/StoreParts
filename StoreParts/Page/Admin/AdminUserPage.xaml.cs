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

        public void UpdateListView()
        {
            UserListView.ItemsSource = null;
            UserListView.ItemsSource = App.db.Users.ToList().Where(u => u != App.User).ToList();
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length == 0)
            {
                UserListView.ItemsSource = App.db.Users.ToList().Where(u => u != App.User).ToList();
            }
            else
            {
                UserListView.ItemsSource = App.db.Users.ToList().Where(u => u != App.User).ToList()
                                                                .Where(u => u.Name.ToLower().Contains(Search.Text.ToLower())
                                                                   || u.Email.ToLower().Contains(Search.Text.ToLower())
                                                                   || u.Phone.ToLower().Contains(Search.Text.ToLower())).ToList();
            }
        }

        private void AddUser(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminUserInfo(this));
        }
        
        private void Update(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminUserInfo(this, UserListView.SelectedItem as User));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.db.Users.Remove(UserListView.SelectedItem as User);
                App.db.SaveChanges();
            }
        }
    }
}
