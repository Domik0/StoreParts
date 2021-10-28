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

namespace StoreParts.Page
{
    /// <summary>
    /// Interaction logic for PartPage.xaml
    /// </summary>
    public partial class PartPage : System.Windows.Controls.Page
    {
        private Part part;
        private User user = App.User;
        int CountPartBasket
        {
            get
            {
                return App.User.BasketParts.Where(b => b == part).Count();
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

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddInBasket(object sender, MouseButtonEventArgs e)
        {
            user.BasketParts.Add(part);
            UpdatePlusMinusImage();
        }

        private void MinusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountPartBasket != 0)
            {
                user.BasketParts.Remove(part);
            }
            UpdatePlusMinusImage();
        }

        private void PlusCountPartBasket(object sender, MouseButtonEventArgs e)
        {
            if (CountPartBasket != 0 && CountPartBasket <= part.CountStorage)
            {
                user.BasketParts.Add(part);
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
