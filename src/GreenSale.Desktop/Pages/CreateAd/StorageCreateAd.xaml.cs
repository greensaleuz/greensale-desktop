using GreenSale.Desktop.Companents.Products;
using GreenSale.Desktop.Windows.Products;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Security;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenSale.Desktop.Pages.CreateAd
{
    /// <summary>
    /// Interaction logic for StorageCreateAd.xaml
    /// </summary>
    public partial class StorageCreateAd : Page
    {
        private IStorageService _service;

        public StorageCreateAd()
        {
            InitializeComponent();
            this._service = new StorageService();
        }

        private void btnStorageCreate_Click(object sender, RoutedEventArgs e)
        {
            StorageProductCreateWindow storageProductCreateWindow = new StorageProductCreateWindow();
            storageProductCreateWindow.ShowDialog();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var storagePost = await _service.GetAllUserId(20);
            foreach (var post in storagePost)
            {
                StorageProductViewUserControl control = new StorageProductViewUserControl();
                control.SetData(post);

                wrpCourses.Children.Add(control);
            }

        }
    }
}
