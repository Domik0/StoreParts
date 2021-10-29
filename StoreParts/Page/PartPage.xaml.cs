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
    /// Interaction logic for PartPage.xaml
    /// </summary>
    public partial class PartPage : System.Windows.Controls.Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Part part;
        private User user = App.User;
        private int countPartBasket = 1;
        private int countStoreAndBasket = 0;
        public int CountStoreAndBasket
        {
            get
            {
                return countStoreAndBasket;
            }
            set
            {
                countStoreAndBasket = value;
                OnPropertyChanged();
            }
        }
        public int CountPartBasket
        {
            get
            {
                return countPartBasket;
            }
            set
            {
                countPartBasket = value;
                OnPropertyChanged();
            }
        } 

        public PartPage(Part part)
        {
            this.part = part;
            CountStoreAndBasket = (int) (part.CountStorage - App.User.BasketParts.Count(b => b == part));
            InitializeComponent();
            DataContext = part;
            CountPartInBasket.DataContext = this;
            CountTitlePart.DataContext = this;
            if (part.CountStorage == 0)
            {
                CountTitlePart.Visibility = Visibility.Hidden;
                BorderStatusCountNull.Visibility = Visibility.Visible;
                BorderStatusCount.Visibility = Visibility.Hidden;
            }

            if (part.Description == null)
            {
                DescriptionTitle.Text = "Описание отсутвует.";
            }

            UpdatePlusMinusImage();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddInBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountStoreAndBasket >= CountPartBasket)
            {
                for (int i = 0; i < CountPartBasket; i++)
                {
                    user.BasketParts.Add(part);
                }
                CountStoreAndBasket = (int)(part.CountStorage - App.User.BasketParts.Count(b => b == part));
                UpdatePlusMinusImage();
                if (CountPartBasket > CountStoreAndBasket)
                {
                    CountPartBasket = CountStoreAndBasket;
                    ImagePlusPart.Visibility = Visibility.Hidden;
                }
            }
        }

        private void MinusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountPartBasket != 0)
            {
                CountPartBasket -= 1;
            }
            UpdatePlusMinusImage();
        }

        private void PlusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountPartBasket >= 0 && CountPartBasket <= CountStoreAndBasket)
            {
                CountPartBasket += 1;
            }
            UpdatePlusMinusImage();
        }

        void UpdatePlusMinusImage()
        {
            if (CountPartBasket != 0 && CountPartBasket < CountStoreAndBasket)
            {
                ImageMinusPart.Visibility = Visibility.Visible;
                ImagePlusPart.Visibility = Visibility.Visible;
            }
            else if (CountPartBasket == CountStoreAndBasket)
            {
                ImagePlusPart.Visibility = Visibility.Hidden;
                ImageMinusPart.Visibility = Visibility.Visible;
            }
            else if (CountPartBasket == 0)
            {
                ImageMinusPart.Visibility = Visibility.Hidden;
                ImagePlusPart.Visibility = Visibility.Visible;
            }
        }
    }
}
