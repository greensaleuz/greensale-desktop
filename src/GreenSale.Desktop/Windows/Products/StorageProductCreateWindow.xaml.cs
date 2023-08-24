using GreenSale.Desktop.Helper;
using GreenSale.Dtos.Dtos.Storages;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Services.Storages;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GreenSale.Desktop.Windows.Products
{
    /// <summary>
    /// Interaction logic for StorageProductCreateWindow.xaml
    /// </summary>
    public partial class StorageProductCreateWindow : Window
    {
        private IStorageService _service;

        public StorageProductCreateWindow()
        {
            InitializeComponent();
            this._service = new StorageService();
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ImgStorage.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    ImgStorage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                    ImgIcon.Visibility = Visibility.Hidden;
                }

            }
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            StorageDto storage = new StorageDto()
            {
                Name = txtbName.Text.ToString(),
                Info = txtbInfo.Text.ToString(),
                Region = cmbRegion.Text.ToString(),
                District = cmbDistrict.Text.ToString(),
                Address = txtbAddress.Text.ToString(),
                Description = txtbDescription.Text.ToString(),
            };

            string imagePath = ImgStorage.ImageSource.ToString();

            string name = Path.GetFileName(imagePath);
            if (!String.IsNullOrEmpty(imagePath))
            {
                storage.ImagePath = name.ToString();
            }

            var result = await _service.CreateAsync(storage);

            if (result)
            {
                MessageBox.Show("Muvafaqqiyatli saqlandi");
            }
            else
            {
                MessageBox.Show("Qayerdadur xatolik ketdi");
            }
            
            this.Close();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
