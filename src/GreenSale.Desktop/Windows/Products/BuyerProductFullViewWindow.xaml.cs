using GreenSale.Desktop.Companents.Products;
using GreenSale.Dtos.Dtos.BuyerPost;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Services.BuyerPosts;
using GreenSale.ViewModels.Enums.BuyerPost;
using GreenSale.ViewModels.Models.BuyerPosts;
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
    /// Interaction logic for BuyerProductFullViewWindow.xaml
    /// </summary>
    public partial class BuyerProductFullViewWindow : Window
    {
        public IBuyerPostService _service;

        public BuyerProductFullViewWindow()
        {
            InitializeComponent();
            this._service = new BuyerPostService();
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
            ImgMain.ImageSource = Img4.ImageSource;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = BuyerProductPersonalViewUserControl.buyerId;
            var buyerPost = await _service.GetByIdAsync(id);

            txtCapacity.Text = buyerPost.Capacity.ToString();
            txtCapacityMeasure.Text = buyerPost.CapacityMeasure;
            txtDescription.Text = buyerPost.Description;
            txtDistrict.Text = buyerPost.District;
            txtPhoneNumber.Text = buyerPost.PostPhoneNumber;
            txtPrice.Text = buyerPost.Price.ToString();
            txtTitle.Text = buyerPost.Title;
            txtType.Text = buyerPost.Type;


            int i = 0;
            foreach (var item in buyerPost.BuyerPostsImages)
            {
           
                if(i==0)
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


        private void btnUpdateMain_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
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


        private void ImgUpdateMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                Img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                ImgIcon.Visibility = Visibility.Hidden;
                ImgUpdateMain.BorderThickness = new Thickness(0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImgUpdateMain_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
