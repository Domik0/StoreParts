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

namespace StoreParts.Page
{
    /// <summary>
    /// Interaction logic for PageOrder.xaml
    /// </summary>
    public partial class PageOrder : System.Windows.Controls.Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User user = App.User;
        private Order order = new Order();
        private double? sumBasket = 0.0;
        private List<PartCount> listBasket = new List<PartCount>();
        
        public double? SumBasket
        {
            get => sumBasket;
            set
            {
                sumBasket = value;
                OnPropertyChanged();
            }
        }
        public List<PartCount> ListBasket
        {
            get => listBasket;
            set
            {
                listBasket = value;
                OnPropertyChanged();
            }
        }


        public PageOrder()
        {
            InitializeComponent();
            DataContext = this;
            GridInfo.DataContext = user;
            GenerateBasket();
            ComboBoxTypePay.ItemsSource = new List<string>
            {
                "Банковской картой",
                "Наличная оплата"
            };
            ComboBoxStore.ItemsSource = App.db.Stores.ToList();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
        
        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            order.Id = App.db.Orders.Count() + 1;
            order.Comments = TextBoxComments.Text;
            if (ComboBoxTypePay.SelectedItem.ToString() == "Банковской картой")
            {
                order.TypePayOnline = true;
            }
            else
            {
                order.TypePayOnline = false;

            }
            order.Store = ComboBoxStore.SelectedItem as Store;
            order.User = user;
            order.Parts = App.User.BasketParts;
            order.DateTime = DateTime.Now;
            if (ComboBoxStore.SelectedItem != null)
            {
                foreach (var item in ListBasket)
                {
                    App.db.Parts.ToList().First(p => p == item.part).CountStorage -= item.count;
                }
                App.User.BasketParts = new List<Part>();
                NavigationService.Navigate(new MainСategoryPage());
                App.db.Orders.Add(order);
                App.db.SaveChanges();
            }
            else
            {
                TextBlockError.Visibility = Visibility.Visible;
            }
        }

        private void GenerateListBasket()
        {
            foreach (var part in App.User.BasketParts.GroupBy(b => b).Select(g => new { Key = g.Key, Count = g.Count() }))
            {
                ListBasket.Add(new PartCount(part.Key, part.Count));
            }
        }

        void GenerateBasket()
        {
            GenerateListBasket();
            double? sum = 0.0;
            foreach (var item in user.BasketParts)
            {
                sum += item.RetailPrice;
            }
            SumBasket = sum;
        }
    }
}
