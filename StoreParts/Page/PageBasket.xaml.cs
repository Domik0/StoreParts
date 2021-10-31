using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
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
    /// Interaction logic for PageBasket.xaml
    /// </summary>
    public partial class PageBasket : System.Windows.Controls.Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private User user = App.User;
        private int countBasket = 0;
        private double? sumBasket = 0.0;
        private List<PartCount> listBasket = new List<PartCount>();

        public int CountBasket
        {
            get => countBasket;
            set
            {
                countBasket = value;
                OnPropertyChanged();
            }
        }
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

        public PageBasket()
        {
            InitializeComponent();
            GenerateBasket();
            DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GenerateListBasket()
        {
            foreach (var part in App.User.BasketParts.GroupBy(b => b).Select(g => new { Key = g.Key, Count = g.Count() }))
            {
                if (ListBasket.Count(l => l.part == part.Key) > 0)
                {
                    ListBasket.Remove(ListBasket.First(l => l.part == part.Key));
                    //ListBasket.First(l => l.part == part.Key).count = App.User.BasketParts.Count(b => b == part.Key);
                }
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
            CountBasket = App.User.BasketParts.Count;
            if (CountBasket <= 0)
            {
                BasketPartsListView.Visibility = Visibility.Hidden;
                NotKnowBox.Visibility = Visibility.Visible;
            }
        }

        private void ButtonOnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainСategoryPage());
        }

        private void OrderClick(object sender, MouseButtonEventArgs e)
        {
            if (user.BasketParts.Count > 0)
            {
                NavigationService.Navigate(new PageOrder());
            }
        }

        private void MinusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            var item = ((sender as System.Windows.Controls.Image).DataContext as PartCount);
            App.User.BasketParts.Remove(item.part);
            GenerateBasket();
        }

        private void PlusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            var item = ((sender as System.Windows.Controls.Image).DataContext as PartCount);
            App.User.BasketParts.Add(item.part);
            GenerateBasket();
        }
    }
}
