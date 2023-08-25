using GreenSale.ViewModels.Models.Storages;
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

namespace GreenSale.Desktop.Companents.Products
{
    /// <summary>
    /// Interaction logic for StorageProductPersonalViewUserControl.xaml
    /// </summary>
    public partial class StorageProductPersonalViewUserControl : UserControl
    {
        public StorageProductPersonalViewUserControl()
        {
            InitializeComponent();
        }
        public void SetData(Storage post)
        {
            string image = "http://95.130.227.68:8080/" + post.ImagePath;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            StorageImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.Region;
            txtbDescription.Text = post.Description;
            txtbUpdate.Text = post.UpdatedAt.ToString();
            txtInfo.Text = post.Info;
            txtbUser.Text = post.FullName.ToString().Split()[1];
            txtbPhoneNumber.Text = post.PhoneNumber;
        }
    }
}
