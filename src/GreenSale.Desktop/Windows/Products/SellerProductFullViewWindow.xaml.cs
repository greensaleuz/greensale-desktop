using GreenSale.Desktop.Companents.Products;
using GreenSale.Dtos.Dtos.SellerPost;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Services.SellerPosts;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
            this._service = new SellerPostService();
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

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SellerPostUpdateDto dto = new SellerPostUpdateDto();
            dto.Capacity = int.Parse(txtCapacity.Text);
            dto.CapacityMeasure = txtCapacityMeasure.Text;
            dto.Title = txtTitle.Text;
            dto.Type = txtType.Text;
            dto.Price = double.Parse(txtPrice.Text);
            dto.District = txtDistrict.Text;
            dto.Region = txtRegion.Text;
            dto.PhoneNumber = txtPhoneNumber.Text;
            dto.Description = txtDescription.Text;

            long id = SellerProductPersonalViewUserControl.sellerId;
            var result = await _service.UpdateAsync(id, dto);

        }
        public static Dictionary<long, string> data = new Dictionary<long, string>();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = SellerProductPersonalViewUserControl.sellerId;
            var sellerPost = await _service.GetByIdAsync(id);

            txtCapacity.Text = sellerPost.Capacity.ToString();
            txtCapacityMeasure.Text = sellerPost.CapacityMeasure;
            txtDescription.Text = sellerPost.Description;
            txtDistrict.Text = sellerPost.District;
            txtPhoneNumber.Text = sellerPost.PostPhoneNumber;
            txtPrice.Text = sellerPost.Price.ToString();
            txtTitle.Text = sellerPost.Title;
            txtType.Text = sellerPost.Type;

            
            int i = 0;
            foreach (var item in sellerPost.PostImages)
            {
                data.Add(item.Id, item.ImagePath);
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

        private async void ImgUpdateMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string path = Path.GetFileName(ImgMain.ImageSource.ToString());

            foreach (var item in data)
            {
                string str = Path.GetFileName(item.Value);
                if (str == path)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        string imgPath = openFileDialog.FileName;
                        Img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                        ImgIcon.Visibility = Visibility.Hidden;
                        ImgUpdateMain.BorderThickness = new Thickness(0);

                        long id = item.Key;
                        var result = await _service.ImageUpdateAsync(id, imgPath);
                    }

                }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
