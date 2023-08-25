using GreenSale.Desktop.Companents.Products;
using GreenSale.Desktop.Windows.Products;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Interfaces.Users;
using GreenSale.Integrated.Security;
using GreenSale.Integrated.Services.Storages;
using GreenSale.Integrated.Services.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public IUserService _serviceUser;

        public StorageCreateAd()
        {
            InitializeComponent();
            this._service = new StorageService();
            this._serviceUser = new UserService();
        }

        private void btnStorageCreate_Click(object sender, RoutedEventArgs e)
        {
            StorageProductCreateWindow storageProductCreateWindow = new StorageProductCreateWindow();
            storageProductCreateWindow.ShowDialog();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var user = await _serviceUser.GetAsync();
            long id = user.Id;
            var storagePost = await _service.GetAllUserId(id);
            foreach (var post in storagePost)
            {
                StorageProductPersonalViewUserControl control = new StorageProductPersonalViewUserControl();
                control.SetData(post);

                wrpCourses.Children.Add(control);
            }

        }
    }
}
