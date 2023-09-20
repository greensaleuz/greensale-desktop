using GreenSale.Desktop.Companents.Images;
using GreenSale.Desktop.Companents.Products;
using GreenSale.Dtos.Dtos.SellerPost;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Services.SellerPosts;
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
    /// Interaction logic for SellerProductFullViewWindow.xaml
    /// </summary>
    public partial class SellerProductFullViewWindow : Window
    {
        private ISellerPost _service;
        public long MainImg_Id { get; set; }
        public bool updated = false;
        public long updated_Id { get; set; }
        public SellerProductFullViewWindow()
        {
            InitializeComponent();
            this._service = new SellerPostService();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

/*        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
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
*/
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Task RefreshAsync(long id, string ImagePath)
        {
            string image = "http://139.59.96.168:89/" + ImagePath;
            if (updated == false)
            {
                MainImg_Id = id;
            }
            else if (updated == true)
            {
                MainImg_Id = updated_Id;
            }

            Uri imageUri = new Uri(image, UriKind.Absolute);
            ImgMain.ImageSource = new BitmapImage(imageUri);
            return Task.CompletedTask;
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

            if (result)
            {
                MessageBox.Show("Malumotlar muvafaqqiyatli o'zgartirildi");
            }
            else MessageBox.Show("Qayerdadur xatolik yuz berdi, qayta urunib koring");

        }
        // private Dictionary<long, string> data = new Dictionary<long, string>();


        public async Task RefreshWindowSeller()
        {
            long id = SellerProductPersonalViewUserControl.sellerId;
            var sellerPost = await _service.GetByIdAsync(id);
            var sellerAllImg = sellerPost.PostImages.OrderBy(item => item.Id).ToList();

            txtCapacity.Text = sellerPost.Capacity.ToString();
            txtCapacityMeasure.Text = sellerPost.CapacityMeasure;
            txtDescription.Text = sellerPost.Description;
            txtDistrict.Text = sellerPost.District;
            txtPhoneNumber.Text = sellerPost.PostPhoneNumber;
            txtPrice.Text = sellerPost.Price.ToString();
            txtTitle.Text = sellerPost.Title;
            txtType.Text = sellerPost.Type;


            int i = 0;
            foreach (var item in sellerAllImg)
            {
                // data.Add(item.Id, item.ImagePath);

                SellerUpdateImageComponent sellerUpdate = new SellerUpdateImageComponent();
                sellerUpdate.Refresh = RefreshAsync;
                sellerUpdate.SetData(item);
                wrpImgSeller.Children.Add(sellerUpdate);

                if (i == 0)
                {
                    string image = "http://139.59.96.168:89/" + item.ImagePath;
                    MainImg_Id = item.Id;
                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    ImgMain.ImageSource = new BitmapImage(imageUri);
                    i++;
                }
                /*else if (i == 1)
                {
                    string image = "http://139.59.96.168:89/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img1.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 2)
                {
                    string image = "http://139.59.96.168:89/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img2.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 3)
                {
                    string image = "http://139.59.96.168:89/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img3.ImageSource = new BitmapImage(imageUri);
                }
                else if (i == 4)
                {
                    string image = "http://139.59.96.168:89/" + item.ImagePath;

                    Uri imageUri = new Uri(image, UriKind.Absolute);
                    Img4.ImageSource = new BitmapImage(imageUri);
                }*/
                
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshWindowSeller();
        }

        private async void ImgUpdateMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wrpImgSeller.Children.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
               // Img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                ImgIcon.Visibility = Visibility.Hidden;
                ImgUpdateMain.BorderThickness = new Thickness(0);

                long id = MainImg_Id;
                var result = await _service.ImageUpdateAsync(id, imgPath);

                if (result)
                {
                    await RefreshWindowSeller();

                    updated_Id = id;
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
