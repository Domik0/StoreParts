using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
using StoreParts.Class;
using StoreParts.Page.LogIn_and_SignUp;

namespace StoreParts.Page
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : System.Windows.Controls.Page
    {
        private double? sumOrder = 0.0;
        private List<PartCount> listOrder = new List<PartCount>();

        public ProfilePage()
        {
            InitializeComponent();
            OrderPartsListView.DataContext = this;
            SumOrderstack.DataContext = this;
            DataContext = App.User;
            if (App.User.Orders.Count > 0)
            {
                OrderListView.ItemsSource = App.User.Orders;
                OrderListView.Visibility = Visibility.Visible;
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
                App.db.SaveChanges();
            }
            else
            {
                StatusNotSavePasssword.Visibility = Visibility.Visible;
            }
        }

        private void OpenOrder(object sender, MouseButtonEventArgs e)
        {
            GenerateOrder(OrderListView.SelectedItem as Order);
            OrderListView.Visibility = Visibility.Hidden;
            ImageBackOrder.Visibility = Visibility.Visible;
            OrderPartsListView.Visibility = Visibility.Visible;
            SumOrderstack.Visibility = Visibility.Visible;
        }

        void GenerateOrder(Order order)
        {
            GenerateListOrder(order);
            double? sum = 0.0;
            foreach (var item in order.Parts)
            {
                sum += item.RetailPrice;
            }
            sumOrder = sum;

            OrderPartsListView.ItemsSource = listOrder;
            SumOrder.DataContext = sumOrder;
        }

        private void GenerateListOrder(Order order)
        {
            foreach (var part in order.Parts.GroupBy(b => b).Select(g => new { Key = g.Key, Count = g.Count() }))
            {
                listOrder.Add(new PartCount(part.Key, part.Count));
            }
        }

        private void BackOrder(object sender, MouseButtonEventArgs e)
        {
            OrderListView.Visibility = Visibility.Visible;
            ImageBackOrder.Visibility = Visibility.Hidden;
            OrderPartsListView.Visibility = Visibility.Hidden;
            listOrder = new List<PartCount>();
            OrderPartsListView.ItemsSource = null;
            SumOrderstack.Visibility = Visibility.Hidden;
            sumOrder = 0;
            SumOrder.DataContext = null;
        }

        private void PasswordBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            StatusSaveProfile.Visibility = Visibility.Hidden;
            StatusSavePasssword.Visibility = Visibility.Hidden;
            StatusNotSavePasssword.Visibility = Visibility.Hidden;
        }

        private void GoBackMainWindow(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
