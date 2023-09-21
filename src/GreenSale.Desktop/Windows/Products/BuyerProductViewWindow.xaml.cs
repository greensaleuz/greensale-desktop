using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Services.BuyerPosts;
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
using System.Windows.Shapes;

namespace GreenSale.Desktop.Windows.Products
{
    /// <summary>
    /// Interaction logic for BuyerProductViewWindow.xaml
    /// </summary>
    public partial class BuyerProductViewWindow : Window
    {
        private IBuyerPostService _service;

        public BuyerProductViewWindow()
        {
            InitializeComponent();
            this._service = new BuyerPostService();

        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            BuyerProductViewWindow buyerProductViewWindow = new BuyerProductViewWindow();
            this.Close();
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img.ImageSource;

        }

        private void btnPicture1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img2.ImageSource;

        }

        private void btnPicture2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img2.ImageSource;

        }

        private void btnPicture3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img3.ImageSource;

        }

        private void btnPicture4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img4.ImageSource;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = BuyerProductViewUserControl.storageId;
            var buyerPost = await _service.GetByIdAsync(id);

            lbCapacity.Content = buyerPost.Capacity.ToString();
            lbCM.Content = buyerPost.CapacityMeasure;
            txbDescription.Text = buyerPost.Description;
            lbDistrict.Content = buyerPost.District;
            lbPhone.Content = buyerPost.PostPhoneNumber;
            lbPrice.Content = buyerPost.Price.ToString();
            txbTitle.Text = buyerPost.Title;
            lbType.Content = buyerPost.Type;


            int i = 0;
            foreach (var item in buyerPost.BuyerPostsImages)
            {

                if (i == 0)
                {
                    string image = $"{AuthAPI.BASE_URL_IMG}" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img.ImageSource = new BitmapImage(imageUri);
                    ImgMain.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 1)
                {
                    string image = $"{AuthAPI.BASE_URL_IMG}" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img1.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 2)
                {
                    string image = $"{AuthAPI.BASE_URL_IMG}" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img2.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 3)
                {
                    string image = $"{AuthAPI.BASE_URL_IMG}" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img3.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 4)
                {
                    string image = $"{AuthAPI.BASE_URL_IMG}" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img4.ImageSource = new BitmapImage(imageUri);
                }
                i++;
            }
        }
    }
}
