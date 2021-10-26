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
    /// Interaction logic for PageListParts.xaml
    /// </summary>
    public partial class PageListParts : System.Windows.Controls.Page
    {
        private Device category;
        private List<Part> parts = new List<Part>();

        public PageListParts(Device category)
        {
            InitializeComponent();
            this.category = category;
            Block.DataContext = category;
            GeneratePartsCategory();
            PartsListView.ItemsSource = parts;
        }

        private void GeneratePartsCategory()
        {
            foreach (var sparePart in category.SparePart)
            {
                parts.AddRange(sparePart.Parts);
            }
        }

        private void ButtonInBasket_Click(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
