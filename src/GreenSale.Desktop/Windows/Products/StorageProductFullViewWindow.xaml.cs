using GreenSale.Desktop.Companents.Products;
using GreenSale.Dtos.Dtos.Storages;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Services.Storages;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GreenSale.Desktop.Windows.Products
{
    /// <summary>
    /// Interaction logic for StorageProductFullViewWindow.xaml
    /// </summary>
    public partial class StorageProductFullViewWindow : Window
    {
        private IStorageService _service;

        public StorageProductFullViewWindow()
        {
            InitializeComponent();
            this._service = new StorageService();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = StorageProductPersonalViewUserControl.storageId;
            var storage = await _service.GetByIdAsync(id);

            txtbName.Text = storage.StorageName;
            txtbFullName.Text = storage.FullName;
            txtbDescription.Text = storage.Description;
            txtbDistrict.Text = storage.District;
            txtbAddress.Text = storage.Address;
            txtbInfo.Text = storage.Info;
            txtbPhoneNumber.Text = storage.PhoneNumber;
            txtbRegion.Text = storage.Region;
            

            string image = "http://95.130.227.68:8080/" + storage.ImagePath;
            Uri imageUri = new Uri(image, UriKind.Absolute);
            ImgStorage.ImageSource = new BitmapImage(imageUri);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            StorageUpdateDto dto = new StorageUpdateDto();
            dto.Info = txtbInfo.Text.ToString(); 
            dto.Description = txtbDescription.Text.ToString();
            dto.District = txtbDistrict.Text.ToString();
            dto.Region = txtbRegion.Text.ToString();
            dto.AddressLatitude = 2384934637;
            dto.AddressLongitude = 2093740930846; 
            dto.Name = txtbName.Text.ToString();
            dto.Address = txtbAddress.Text.ToString();

            long id = StorageProductPersonalViewUserControl.storageId;
            var storage = await _service.UpdateAsync(id,dto);
        
        }

        private void btnPicture_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}

