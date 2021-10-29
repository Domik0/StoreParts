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
        private int countPartBasket = 0;

        private int CountPartBasket
        {
            get
            {
                //return App.User.BasketParts.Where(b => b == part).Count();
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
            InitializeComponent();
            DataContext = part;
            CountPartInBasket.DataContext = CountPartBasket;
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
            for (int i = 0; i < CountPartBasket; i++)
            {
                user.BasketParts.Add(part);
            }
            //if (CountPartBasket >= 0 && CountPartBasket <= part.CountStorage)
            //{
            //    user.BasketParts.Add(part);
            //}
            //UpdatePlusMinusImage();
        }

        private void MinusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountPartBasket != 0)
            {
                CountPartBasket -= 1;
                //user.BasketParts.Remove(part);
            }
            UpdatePlusMinusImage();
        }

        private void PlusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountPartBasket >= 0 && CountPartBasket <= part.CountStorage)
            {
                CountPartBasket += 1;
                //user.BasketParts.Add(part);
            }
            UpdatePlusMinusImage();
        }

        void UpdatePlusMinusImage()
        {
            if (CountPartBasket != 0 && CountPartBasket <= part.CountStorage)
            {
                ImageMinusPart.Visibility = Visibility.Visible;
                ImagePlusPart.Visibility = Visibility.Visible;
            }
            else if (CountPartBasket == part.CountStorage)
            {
                ImagePlusPart.Visibility = Visibility.Hidden;
            }
            else if (CountPartBasket == 0)
            {
                ImageMinusPart.Visibility = Visibility.Hidden;

            }
        }
    }
}
