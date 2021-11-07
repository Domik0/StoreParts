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
    /// Interaction logic for AdminOrderPage.xaml
    /// </summary>
    public partial class AdminOrderPage : System.Windows.Controls.Page
    {
        public AdminOrderPage()
        {
            InitializeComponent();
            UpdateListView();
        }

        public void UpdateListView()
        {
            OrderListView.ItemsSource = null;
            OrderListView.ItemsSource = App.db.Orders.ToList();
        }

        private void AddOrder(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AdminOrderInfoPage(this));
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFilter();
        }

        private void UpdateFilter()
        {

            if (DatePickerFilterOT.SelectedDate != null && DatePickerFilterDO.SelectedDate != null)
            {
                if (Search.Text.Length == 0)
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList().Where(o =>
                            o.DateTime >= DatePickerFilterOT.SelectedDate &&
                            o.DateTime <= DatePickerFilterDO.SelectedDate)
                        .ToList();
                }
                else
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList()
                        .Where(o => o.User.Name.ToLower().Contains(Search.Text.ToLower())).ToList()
                        .Where(o =>
                            o.DateTime >= DatePickerFilterOT.SelectedDate &&
                            o.DateTime <= DatePickerFilterDO.SelectedDate)
                        .ToList();
                }
            }
            else if (DatePickerFilterOT.SelectedDate != null && DatePickerFilterDO.SelectedDate == null)
            {
                if (Search.Text.Length == 0)
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList().Where(o => o.DateTime >= DatePickerFilterOT.SelectedDate)
                    .ToList();
                }
                else
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList()
                        .Where(o => o.User.Name.ToLower().Contains(Search.Text.ToLower())).ToList()
                        .Where(o => o.DateTime >= DatePickerFilterOT.SelectedDate)
                        .ToList();
                }
            }
            else if (DatePickerFilterOT.SelectedDate == null && DatePickerFilterDO.SelectedDate != null)
            {
                if (Search.Text.Length == 0)
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList().Where(o => o.DateTime <= DatePickerFilterDO.SelectedDate)
                        .ToList();
                }
                else
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList()
                        .Where(o => o.User.Name.ToLower().Contains(Search.Text.ToLower())).ToList()
                        .Where(o => o.DateTime <= DatePickerFilterDO.SelectedDate)
                        .ToList();
                }
            }
            else
            {
                if (Search.Text.Length == 0)
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList();
                }
                else
                {
                    OrderListView.ItemsSource = App.db.Orders.ToList().Where(o => o.User.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
                }
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminOrderInfoPage(this, OrderListView.SelectedItem as Order));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.db.Orders.Remove(OrderListView.SelectedItem as Order);
                App.db.SaveChanges();
            }
        }

        private void DatePickerChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilter();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DatePickerFilterOT.SelectedDate = null;
            DatePickerFilterDO.SelectedDate = null;
        }
    }
}
