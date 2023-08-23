using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Services.SellerPosts;
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
        private ISellerPost _service;
        public SellerPage()
        {
            InitializeComponent();
            this._service= new SellerPostService();
        }

        private async void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            var sellerpost = await _service.GetAllAsync();
            foreach (var post in sellerpost)
            {
                SellerProductViewUserControl userControl = new SellerProductViewUserControl();
                userControl.SetData(post);
                wrpSellerPost.Children.Add(userControl);
            }
        }
    }
}
