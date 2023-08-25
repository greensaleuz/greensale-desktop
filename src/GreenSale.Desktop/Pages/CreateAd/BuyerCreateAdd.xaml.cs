using GreenSale.Desktop.Companents.Products;
using GreenSale.Desktop.Windows.Products;
using GreenSale.Integrated.Services.BuyerPosts;
using GreenSale.Integrated.Services.Storages;
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

namespace GreenSale.Desktop.Pages.CreateAd
{
    /// <summary>
    /// Interaction logic for BuyerCreateAdd.xaml
    /// </summary>
    public partial class BuyerCreateAdd : Page
    {
        private BuyerPostService _service;

        public BuyerCreateAdd()
        {
            InitializeComponent();
            this._service = new BuyerPostService();

        }

        private void btnBuyerCreate_Click(object sender, RoutedEventArgs e)
        {
            BuyerProductCreateWindow buyerProductCreateWindow = new BuyerProductCreateWindow();
            buyerProductCreateWindow.ShowDialog();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var buyerPost = await _service.GetAllUserId(20);
            foreach (var post in buyerPost)
            {
                BuyerProductViewUserControl control = new BuyerProductViewUserControl();
                control.SetData(post);

                wrpCourses.Children.Add(control);
            }
        }
    }
}
