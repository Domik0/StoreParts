using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace StoreParts.Page.Admin
{
    /// <summary>
    /// Interaction logic for AdminOrderInfoPage.xaml
    /// </summary>
    public partial class AdminOrderInfoPage : System.Windows.Controls.Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AdminOrderPage page;
        private Order order;
        List<string> listPay = new List<string>
        {
            "Банковской картой",
            "Наличная оплата"
        };
        private double? sumBasket = 0.0;
        private List<Part> listBasket = new List<Part>();

        public double? SumBasket
        {
            get => sumBasket;
            set
            {
                sumBasket = value;
                OnPropertyChanged();
            }
        }
        public List<Part> ListBasket
        {
            get => listBasket;
            set
            {
                listBasket = value;
                OnPropertyChanged();
            }
        }

        public AdminOrderInfoPage(AdminOrderPage page)
        {
            this.page = page;
            InitializeComponent();
            DataContext = this;
            GenerateBasket();
            ComboBoxTypePay.ItemsSource = listPay;
            ComboBoxStore.ItemsSource = App.db.Stores.ToList();
            ComboBoxUser.ItemsSource = App.db.Users.ToList();
        }

        public AdminOrderInfoPage(AdminOrderPage page, Order order)
        {
            this.page = page;
            this.order = order;
            InitializeComponent();
            DataContext = this;
            GenerateBasket();
            ComboBoxTypePay.ItemsSource = listPay;
            ComboBoxStore.ItemsSource = App.db.Stores.ToList();
            ComboBoxStore.SelectedItem = this.order.Store;
            ComboBoxUser.ItemsSource = App.db.Users.ToList();
            ComboBoxUser.SelectedItem = this.order.User;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveChange(object sender, RoutedEventArgs e)
        {
            if (order == null)
            {
                order = new Order()
                {
                    Id = App.db.Orders.Count() + 1
                };
                App.db.Orders.Add(order);
            }
            order.User = ComboBoxUser.SelectedItem as User;
            if (ComboBoxTypePay.SelectedItem as string == "Банковской картой")
            {
                order.TypePayOnline = true;
            }
            else
            {
                order.TypePayOnline = false;
            }
            order.Comments = TextBoxComments.Text;
            order.Store = ComboBoxStore.SelectedItem as Store;
            //order.Parts = BasketPartsListView.ItemsSource as List<Part>;
            
            NavigationService.Navigate(new MainСategoryPage());
            App.db.Orders.Add(order);
            App.db.SaveChanges();

            page.UpdateListView();
            NavigationService.GoBack();
        }

        private void ComboBoxUserChange(object sender, SelectionChangedEventArgs e)
        {
            order.User = ComboBoxUser.SelectedItem as User;
            TextBlockPhone.Text = order.User.Phone;
            TextBlockEmail.Text = order.User.Email;
        }

        private void GenerateListBasket()
        {
            foreach (var part in order.Parts)
            {
                ListBasket.Add(part);
            }
        }

        void GenerateBasket()
        {
            GenerateListBasket();
            double? sum = 0.0;
            foreach (var item in order.Parts)
            {
                sum += item.RetailPrice;
            }
            SumBasket = sum;
        }

        private void AddPart(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new AdminOrderAddPartPage(this));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if(BasketPartsListView.SelectedItem != null)
                {
                    order.Parts.Remove(BasketPartsListView.SelectedItem as Part);
                    SumBasket -= (BasketPartsListView.SelectedItem as Part).RetailPrice;
                    ListBasket = order.Parts.ToList();
                    BasketPartsListView.ItemsSource = null;
                    BasketPartsListView.ItemsSource = ListBasket;
                    TextBlockSumBasket.Text = $"Итоговая сумма: {SumBasket} ₽";
                }
            }
        }

        public void AddPartInList(Part part)
        {
            ListBasket.Add(part);
            SumBasket += part.RetailPrice;
        }
    }
}
