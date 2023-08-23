using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Services.BuyerPosts;
using System.Windows;
using System.Windows.Controls;

namespace GreenSale.Desktop.Pages.Buyers
{
    /// <summary>
    /// Interaction logic for BuyerPage.xaml
    /// </summary>
    public partial class BuyerPage : Page
    {
        private IBuyerPostService _service;

        public BuyerPage()
        {
            InitializeComponent();
            this._service = new BuyerPostService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var buyerpost = await _service.GetAllAsync();

            foreach (var post in buyerpost)
            {

                BuyerProductViewUserControl buyerProductViewUserControl = new BuyerProductViewUserControl();
                buyerProductViewUserControl.SetData(post);
                wrpCourses.Children.Add(buyerProductViewUserControl);
            }

        }
    }
}
