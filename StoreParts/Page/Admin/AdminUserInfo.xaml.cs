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
    /// Interaction logic for AdminUserInfo.xaml
    /// </summary>
    public partial class AdminUserInfo : System.Windows.Controls.Page
    {
        private AdminUserPage page;
        private User user;

        public AdminUserInfo(AdminUserPage page)
        {
            this.page = page;
            InitializeComponent();
        }

        public AdminUserInfo(AdminUserPage page, User user)
        {
            this.page = page;
            InitializeComponent();
            this.user = user;
            DataContext = user;
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
        
        private void SaveChange(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                user = new User()
                {
                    Id = App.db.Users.Count() + 1
                };
                App.db.Users.Add(user);
            }
            user.Name = NameTextBox.Text;
            user.Phone = PhoneTextBox.Text;
            user.Email = EmailTextBox.Text;
            user.Password = PasswordTextBox.Text;
            user.AdminStatus = AdminStatusCheckBox.IsChecked;
           
            App.db.SaveChanges();
            page.UpdateListView();
            NavigationService.GoBack();
        }
    }
}
