using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Services.Storages;
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
    /// Interaction logic for StorageProductViewWindow.xaml
    /// </summary>
    public partial class StorageProductViewWindow : Window
    {
        private IStorageService _service;

        public StorageProductViewWindow()
        {
            InitializeComponent();
            this._service = new StorageService();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = StorageProductViewUserControl.storageId;
            var storagePost = await _service.GetByIdAsync(id);

            txbStorageName.Text = storagePost.StorageName;
            txbInfo.Text = storagePost.Info;
            txbFullName.Text = storagePost.FullName.Split()[0];
            txbPhone.Text = storagePost.PhoneNumber;
            txbRegion.Text = storagePost.Region;
            txbDistrict.Text = storagePost.District;
            txbAddress.Text = storagePost.Address;
            txbDescription.Text = storagePost.Description;
            
            string image = "https://localhost:7288/" + storagePost.ImagePath;
            Uri imageUri = new Uri(image, UriKind.Absolute);
            Img.ImageSource = new BitmapImage(imageUri);
        }
    }
}
