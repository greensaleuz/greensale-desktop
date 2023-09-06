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
using System.Windows.Shapes;

namespace GreenSale.Desktop.Windows.Products
{
    /// <summary>
    /// Interaction logic for ProductViewWindow.xaml
    /// </summary>
    public partial class SellerProductViewWindow : Window
    {
        private ISellerPost _service;

        public SellerProductViewWindow()
        {
            InitializeComponent();
            this._service=new SellerPostService ();

        }

        private void btnPicture3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img3.ImageSource;
        }

        private void btnPicture4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img4.ImageSource;
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img.ImageSource;
        }

        private void btnPicture1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img1.ImageSource;
        }

        private void btnPicture2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img2.ImageSource;

        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = SellerProductViewUserControl.sellerId;
            var sellerPost = await _service.GetByIdAsync(id);

            txtCapacity.Text = sellerPost.Capacity.ToString();
            txtCM.Text = sellerPost.CapacityMeasure;
            txtDescription.Text = sellerPost.Description;
            txtDistrict.Text = sellerPost.District;
            txtPhone.Text = sellerPost.PostPhoneNumber;
            txtPrice.Text = sellerPost.Price.ToString();
            txtTitle.Text = sellerPost.Title;
            txtType.Text = sellerPost.Type;


            int i = 0;
            foreach (var item in sellerPost.PostImages)
            {

                if (i == 0)
                {
                    string image = "https://localhost:7288/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img.ImageSource = new BitmapImage(imageUri);
                    ImgMain.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 1)
                {
                    string image = "https://localhost:7288/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img1.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 2)
                {
                    string image = "https://localhost:7288/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img2.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 3)
                {
                    string image = "https://localhost:7288/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img3.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 4)
                {
                    string image = "https://localhost:7288/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img4.ImageSource = new BitmapImage(imageUri);
                }
                i++;
            }
        }
    }
}
