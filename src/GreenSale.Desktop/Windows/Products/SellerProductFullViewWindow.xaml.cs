using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Services.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
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
    /// Interaction logic for SellerProductFullViewWindow.xaml
    /// </summary>
    public partial class SellerProductFullViewWindow : Window
    {
        private ISellerPost _service;

        public SellerProductFullViewWindow()
        {
            InitializeComponent();
            this._service=new SellerPostService ();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void btnPicture3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img3.ImageSource;

        }

        private void btnPicture4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img.ImageSource;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = SellerProductPersonalViewUserControl.sellerId;
            var seller = await _service.GetByIdAsync(id);

            txbTitle.Text = seller.Title;
            lbType.Content = seller.Type;
            lbCapacity.Content = seller.Capacity;
            lbCM.Content = seller.CapacityMeasure;
            lbPrice.Content = seller.Price;
            lbRegion.Content = seller.Region;
            lbDistrict.Content = seller.District;
            lbPhone.Content = seller.PhoneNumber;
            txbDescribtion.Text=seller.Description;

            string image = "http://95.130.227.68:8080/" + seller.MainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);
            ImgMain.ImageSource = new BitmapImage(imageUri);

            string image1 = "http://95.130.227.68:8080/" + seller.MainImage;
            Uri imageUri1 = new Uri(image1, UriKind.Absolute);
            Img.ImageSource = new BitmapImage(imageUri1);

            string image2 = "http://95.130.227.68:8080/" + seller.Images[1];
            Uri imageUri2 = new Uri(image2, UriKind.Absolute);
            Img1.ImageSource = new BitmapImage(imageUri2);

            string image3 = "http://95.130.227.68:8080/" + seller.Images[2];
            Uri imageUri3 = new Uri(image3, UriKind.Absolute);
            Img2.ImageSource = new BitmapImage(imageUri3);

            string image4 = "http://95.130.227.68:8080/" + seller.Images[3];
            Uri imageUri4 = new Uri(image4, UriKind.Absolute);
            Img3.ImageSource = new BitmapImage(imageUri4);

            string image5 = "http://95.130.227.68:8080/" + seller.Images[4];
            Uri imageUri5 = new Uri(image5, UriKind.Absolute);
            Img4.ImageSource = new BitmapImage(imageUri5);
        }
    }
}
