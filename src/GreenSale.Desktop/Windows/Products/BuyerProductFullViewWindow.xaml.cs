using GreenSale.Desktop.Companents.Images;
using GreenSale.Desktop.Companents.Products;
using GreenSale.Dtos.Dtos.BuyerPost;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Services.BuyerPosts;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GreenSale.Desktop.Windows.Products
{
    /// <summary>
    /// Interaction logic for BuyerProductFullViewWindow.xaml
    /// </summary>
    public partial class BuyerProductFullViewWindow : Window
    {
        public IBuyerPostService _service;
        public long MainImg_Id { get; set; }
        public BuyerProductFullViewWindow()
        {
            InitializeComponent();
            this._service = new BuyerPostService();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       /* private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
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

        }*/

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //  public static Dictionary<long, string> data = new Dictionary<long, string>();
        public Task RefreshAsync(long id, string ImagePath)
        {
            string image = "http://128.199.140.234:3030/" + ImagePath;

            Uri imageUri = new Uri(image, UriKind.Absolute);
            ImgMain.ImageSource = new BitmapImage(imageUri);
            return Task.CompletedTask;
        }


        public async Task RefreshWindow()
        {
            long id = BuyerProductPersonalViewUserControl.buyerId;
            var buyerPost = await _service.GetByIdAsync(id);
            var imglist = buyerPost.BuyerPostsImages.OrderBy(item => item.Id).ToList();
             
            txtCapacity.Text = buyerPost.Capacity.ToString();
            txtCapacityMeasure.Text = buyerPost.CapacityMeasure;
            txtDescription.Text = buyerPost.Description;
            txtDistrict.Text = buyerPost.District;
            txtPhoneNumber.Text = buyerPost.PostPhoneNumber;
            txtPrice.Text = buyerPost.Price.ToString();
            txtTitle.Text = buyerPost.Title;
            txtType.Text = buyerPost.Type;
            txtAddress.Text = buyerPost.Address;


            int i = 0;
            foreach (var item in imglist)
            {
                BuyerUpdateImageComponent buyerUpdateImageComponent = new BuyerUpdateImageComponent();
                buyerUpdateImageComponent.Refresh = RefreshAsync;
                buyerUpdateImageComponent.SetData(item);
                wrpImg.Children.Add(buyerUpdateImageComponent);


                //  data.Add(item.Id, item.ImagePath);
                if (i == 0)
                {
                    string image = "http://128.199.140.234:3030/" + item.ImagePath;
                    MainImg_Id = item.Id;
                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    ImgMain.ImageSource = new BitmapImage(imageUri);
                    i++;
                }
                /*else if (i == 1)
                {
                    string image = "http://128.199.140.234:3030/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img1.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 2)
                {
                    string image = "http://128.199.140.234:3030/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img2.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 3)
                {
                    string image = "http://128.199.140.234:3030/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img3.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 4)
                {
                    string image = "http://128.199.140.234:3030/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img4.ImageSource = new BitmapImage(imageUri);
                }
                i++;*/
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshWindow();
        }

        private async void ImgUpdateMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wrpImg.Children.Clear();
            //  string path = Path.GetFileName(ImgMain.ImageSource.ToString());

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                //Img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                ImgIcon.Visibility = Visibility.Hidden;
                ImgUpdateMain.BorderThickness = new Thickness(0);

                long id = MainImg_Id;
                var result = await _service.UpdateImageAsync(id, imgPath);

                if (result)
                {
                    await RefreshWindow();
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



        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BuyerPostUpdateDto dto = new BuyerPostUpdateDto();
            dto.Address = txtAddress.Text;
            dto.Description = txtDescription.Text;
            dto.District = txtDistrict.Text;
            dto.Capacity = int.Parse(txtCapacity.Text);
            dto.CapacityMeasure = txtCapacityMeasure.Text;
            dto.Title = txtTitle.Text;
            dto.Region = txtRegion.Text;
            dto.PhoneNumber = txtPhoneNumber.Text;
            dto.Price = double.Parse(txtPrice.Text);
            dto.Type = txtType.Text;

            long id = BuyerProductPersonalViewUserControl.buyerId;
            var res = await _service.UpdateAsync(id, dto);

            if (res)
            {
                MessageBox.Show("Malumotlar muvafaqqiyatli o'zgartirildi");
            }
            else MessageBox.Show("Qayerdadur xatolik yuz berdi, qayta urunib koring");
        }


        private async void btnImageUpdate_Click(object sender, RoutedEventArgs e)
        {
            //string path = ImgMain.ImageSource.ToString();

            //foreach (var item in data)
            //{
            //    if (item.Value == path)
            //    {
            //        long id = item.Key;
            //        var result = await _service.UpdateImageAsync(id, path);
            //    }
            //}
        }
    }
}
