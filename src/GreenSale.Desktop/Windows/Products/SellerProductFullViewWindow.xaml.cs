using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Services.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using Microsoft.Win32;
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
            var sellerPost = await _service.GetByIdAsync(id);

            lbCapacity.Text = sellerPost.Capacity.ToString();
            lbCM.Text = sellerPost.CapacityMeasure;
            txbDescribtion.Text = sellerPost.Description;
            lbDistrict.Text = sellerPost.District;
            lbPhone.Text = sellerPost.PostPhoneNumber;
            lbPrice.Text = sellerPost.Price.ToString();
            txbTitle.Text = sellerPost.Title;
            lbType.Text = sellerPost.Type;


            int i = 0;
            foreach (var item in sellerPost.PostImages)
            {

                if (i == 0)
                {
                    string image = "http://95.130.227.68:8080/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img.ImageSource = new BitmapImage(imageUri);
                    ImgMain.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 1)
                {
                    string image = "http://95.130.227.68:8080/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img1.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 2)
                {
                    string image = "http://95.130.227.68:8080/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img2.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 3)
                {
                    string image = "http://95.130.227.68:8080/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img3.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 4)
                {
                    string image = "http://95.130.227.68:8080/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img4.ImageSource = new BitmapImage(imageUri);
                }
                i++;
            }
        }

        private void ImgUpdateMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                }
        }

        private void ImgUpdateMain_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ImgUpdateMain.IsMouseOver == true)
            {
                ImgIcon.Visibility = Visibility.Visible;
                ImgUpdateMain.BorderThickness = new Thickness(2);

            }
            else
            {
                ImgIcon.Visibility = Visibility.Hidden;
                ImgUpdateMain.BorderThickness = new Thickness(0);
            }
        }
    }
}
