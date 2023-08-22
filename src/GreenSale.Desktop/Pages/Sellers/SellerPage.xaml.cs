using GreenSale.Desktop.Companents.Products;
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

namespace GreenSale.Desktop.Pages.Sellers
{
    /// <summary>
    /// Interaction logic for SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Page
    {
        public SellerPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            SellerProductViewUserControl sellerProductViewUserControl = new SellerProductViewUserControl();
            wrpCourses.Children.Add(sellerProductViewUserControl);
        }
    }
}
