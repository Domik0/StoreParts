using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : System.Windows.Controls.Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = App.User;
            if (App.User.Orders.Count > 0)
            {

            }
            else
            {
                NotKnowBox.Visibility = Visibility.Visible;
            }
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveInfo(object sender, RoutedEventArgs e)
        {
            StatusSaveProfile.Visibility = Visibility.Visible;
            App.User.Name = TitleName.Text;
            App.User.Phone = TitlePhone.Text;
            App.User.Email = TitleEmail.Text;
            App.db.SaveChanges();
        }

        private void SavePassword(object sender, RoutedEventArgs e)
        {
            if (PasswordBox1.Text == PasswordBox2.Text)
            {
                StatusSavePasssword.Visibility = Visibility.Visible;
                App.User.Password = PasswordBox1.Text;
            }
        }
    }
}
