using GreenSale.Desktop.Companents.Products;
using GreenSale.Desktop.Windows.Products;
using GreenSale.Integrated.Services.SellerPosts;
using GreenSale.Integrated.Services.Storages;
using GreenSale.Integrated.Services.Users;
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
    /// Interaction logic for CreateAd.xaml
    /// </summary>
    public partial class CreateAd : Page
    {
        private SellerPostService _service;
        private UserService _serviceUser;

        public CreateAd()
        {
            InitializeComponent();
            this._service = new SellerPostService();
            this._serviceUser = new UserService();

        }

        private void btnSellerCreate_Click(object sender, RoutedEventArgs e)
        {
            SellerProductCreateWindow sellerProductCreateWindow = new SellerProductCreateWindow();
            sellerProductCreateWindow.ShowDialog();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var user = await _serviceUser.GetAsync();
            long id = user.Id;
            var sellerPost = await _service.GetAllUserId(id);
            foreach (var post in sellerPost)
            {
                SellerProductPersonalViewUserControl control = new SellerProductPersonalViewUserControl();
                control.SetData(post);

                wrpCourses.Children.Add(control);
            }
        }
    }
}
