using DocumentFormat.OpenXml.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using GreenSale.Desktop.Companents.Loader;
using GreenSale.Desktop.Windows;
using GreenSale.Desktop.Windows.Products;
using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Services.Auth;
using GreenSale.ViewModels.Models.SellerPosts;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GreenSale.Desktop.Companents.Products
{
    /// <summary>
    /// Interaction logic for ProductViewUserControl.xaml
    /// </summary>
    public partial class SellerProductViewUserControl : UserControl
    {
        private AuthService _authservice;

        private long ID { get; set; }

        public Func<Task> Refresh { get; set; }

        public static long sellerId { get; set; }
        public string imageUrl { get; set; }

        public SellerProductViewUserControl()
        {
            this._authservice = new AuthService();
            InitializeComponent();
        }


        public void SetData(SellerPost post)
        {
            string image = $"{AuthAPI.BASE_URL_IMG}" + post.mainImage;
            imageUrl = image;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            SellePostImage.ImageSource = new BitmapImage(imageUri);

            loader.Visibility = Visibility.Collapsed;

            txtbRegion.Text = post.region;
            txtbDescription.Text = post.description;
            txtbPrice.Text = post.price.ToString();
            txtbUpdate.Text = post.updatedAt.ToString("hh:mm") + " " + post.updatedAt.ToString("dd-MM-yy");
            txtTitle.Text = post.title;
            txtbCapacity.Text = post.capacity.ToString();
            txtbCapacityMeasure.Text = post.capacityMeasure.ToString();
            starAvareg.Content = post.AverageStars;
            /*if(post.AverageStars.ToString().Length > 1)
            {
                var str = post.AverageStars.ToString("0.0");
                starAvareg.Content =str;
            }
            else
            {
                starAvareg.Content = post.AverageStars.ToString();
            }*/


            if (post.status == 0)
            {
                txtbStatus.Text = "Yangi";
                statusPost.Background = new System.Windows.Media. SolidColorBrush( Colors.Green);
                txtbStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else if (post.status == 1)
            {
                txtbStatus.Text = "Kelishilgan";
                statusPost.Background = new SolidColorBrush(Colors.Yellow);
                txtbStatus.Foreground = new SolidColorBrush(Colors.Yellow);

            }
            else if (post.status == 2)
            {
                txtbStatus.Text = " Sotib olingan";
                statusPost.Background = new SolidColorBrush(Colors.Red);
                txtbStatus.Foreground = new SolidColorBrush(Colors.Red);

            }
            ID = post.Id;
        }


        public void SetData(SellerPostViewModelSearch post)
        {
            string image = $"{AuthAPI.BASE_URL_IMG}" + post.MainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            SellePostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.Region;
            txtbDescription.Text = post.Description;
            txtbPrice.Text = post.Price.ToString();
            txtbUpdate.Text = post.UpdatedAt.ToString();
            txtTitle.Text = post.Title;
            txtbCapacity.Text = post.Capacity.ToString();

            txtbCapacityMeasure.Text = post.CapacityMeasure.ToString();
            ID = post.Id;
        }

        private void btnReadmore_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PictureLoader loader = new PictureLoader();
        }

        private void B_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sellerId = ID;
            SellerProductViewWindow seller = new SellerProductViewWindow();
            seller.ShowDialog();
            Refresh();
        }
        private string DowlaodImage(string url)
        {
            /*try
            {
                string saveDirectory = "D:\\path\\to\\save\\";
                

                
                string fileName = Path.GetFileName(url);

                string localFilePath = Path.Combine(saveDirectory, fileName);

                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                using (WebClient client = new WebClient())
                {
                    if (!File.Exists(localFilePath))
                        client.DownloadFile(url, localFilePath);
                }

                return saveDirectory;
            }
            catch
            {
                return "";
            }*/

            try
            {
                string saveDirectory = "D:\\path\\to\\save\\";
                string fileName = System.IO.Path.GetFileName(url);

                string localFilePath = System.IO.Path.Combine(saveDirectory, fileName);

                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                using (WebClient client = new WebClient())
                {
                    if (!File.Exists(localFilePath))
                        client.DownloadFile(url, localFilePath);
                }

                return localFilePath;
            }
            catch
            {
                return "";
            }
        }


       /* public void Downdload(string scurypath)
        {
            string filename = scurypath;
            string securypath = "C:\\Users\\Lenovo\\source\\repos\\greensale-desktop\\src\\GreenSale.Desktop\\Assets\\Images\\SecurityImage.jpg";
            ///string path = Path.Combine(basepath, filename);
            ///


            byte[] bytes = File.ReadAllBytes(scurypath);
            byte[] secryimg = File.ReadAllBytes(securypath);
            byte[] newbytes = new byte[securypath.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = secryimg[i];
            }

            File.WriteAllBytes(scurypath, newbytes);
        }*/

        private async void dowload_img(object sender, MouseButtonEventArgs e)
        {

            var user = await _authservice.VerifyUserRole();
            if (user.RoleId != 1)
            {
                var resulrt = DowlaodImage(imageUrl);

                //string path = System.IO.Path.Combine(basepath, filename);

                byte[] bytes = File.ReadAllBytes(resulrt);

                byte[] newbytes = new byte[bytes.Length];

                for (int i = 0; i < bytes.Length / 3; i++)
                {
                    newbytes[i] = bytes[i];
                }
                File.WriteAllBytes(resulrt, newbytes);

                /*// Image fileName = System.IO.Path.GetFileName(resulrt);

                 // Load the input image
                 Bitmap inputImage = new Bitmap(resulrt);

                 // Create a mask image
                 Bitmap maskImage = new Bitmap(inputImage.Width, inputImage.Height);

                 for (int x = 0; x < inputImage.Width; x++)
                 {
                     for (int y = 0; y < inputImage.Height; y++)
                     {
                         System.Drawing. Color pixelColor = inputImage.GetPixel(x, y);

                         // Check a custom condition (e.g., brightness)
                         double brightness = (pixelColor.R + pixelColor.G + pixelColor.B) / 3.0;

                         if (brightness > 128)
                         {
                             maskImage.SetPixel(x, y, System.Drawing.Color.White);
                         }
                         else
                         {
                             maskImage.SetPixel(x, y, System.Drawing.Color.Black);
                         }
                     }
                 }

                 // Save the mask image
                 maskImage.Save(System.IO.Path.GetFileName(resulrt), ImageFormat.Png);*/

                /*////var inputImage = new Bitmap(resulrt);
                //Mat inputImage = CvInvoke.Imread(fileName);

                ///*var maskImage = new Bitmap(inputImage.Width, inputImage.Height);

                //int threshold = 128; // Adjust this threshold value as needed

                //for (int x = 0; x < inputImage.Width; x++)
                //{
                //    for (int y = 0; y < inputImage.Height; y++)
                //    {
                //         System.Drawing.Color pixelColor = inputImage.GetPixel(x, y);

                //        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                //        if (grayscaleValue > threshold)
                //        {
                //            maskImage.SetPixel(x, y, System.Drawing. Color.White);
                //        }
                //        else
                //        {
                //            maskImage.SetPixel(x, y, System.Drawing.Color.Black);
                //        }
                //    }
                //}
                //try
                //{
                //maskImage.Save(resulrt.ToString(),  ImageFormat.Jpeg);

                //}
                //catch (Exception ex)
                //{

                //    Console.WriteLine("Error saving the image: " + ex.Message);
                //}*/


                //Mat grayscaleImage = new Mat();
                //CvInvoke.CvtColor(inputImage, grayscaleImage, ColorConversion.Bgr2Gray);

                //// Apply Canny edge detection to create a mask image
                //Mat maskImage = new Mat();
                //CvInvoke.Canny(grayscaleImage, maskImage, 100, 200);

                //// Save the mask image
                //maskImage.Save(resulrt);*/

                Uri uri = new Uri(resulrt);

                FullImageWindow fullImageWindow = new FullImageWindow();
                fullImageWindow.ImgMain.ImageSource = new BitmapImage(uri);

                fullImageWindow.ShowDialog();
                MessageBox.Show("Siz User  foydaluvchi emasizsiz");


            }
            else
            {

                Uri imageUri = new Uri(imageUrl, UriKind.Absolute);


                var resulrt = DowlaodImage(imageUrl);
                Uri uri = new Uri(resulrt);
                FullImageWindow fullImageWindow = new FullImageWindow();
                fullImageWindow.ImgMain.ImageSource = new BitmapImage(uri);
                fullImageWindow.ShowDialog();
                //LaunchRunDialog(resulrt);
            }

        }

        static void LaunchRunDialog(string path)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"/select, \"{path}\""
            };
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
