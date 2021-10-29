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
        private List<(Part part, int count)> listBasket = new List<(Part part, int count)>();

        public int CountBasket
        {
            get
            {
                return countBasket;
            }
            set
            {
                countBasket = value;
                OnPropertyChanged();
            }
        }
        public double? SumBasket
        {
            get
            {
                return sumBasket;
            }
            set
            {
                sumBasket = value;
                OnPropertyChanged();
            }
        }
        public List<(Part part, int count)> ListBasket
        {
            get
            {
                return listBasket;
            }
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
            var item = BasketPartsListView.ItemsSource;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        void GenerateBasket()
        {
            double? sum = 0.0;
            foreach (var item in user.BasketParts)
            {
                sum += item.RetailPrice;
            }
            SumBasket = sum;
            CountBasket = App.User.BasketParts.Count;
            if (CountBasket > 0)
            {
                BasketPartsListView.ItemsSource = App.User.BasketParts;
            }
            else
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
            throw new NotImplementedException();
        }
    }
}
