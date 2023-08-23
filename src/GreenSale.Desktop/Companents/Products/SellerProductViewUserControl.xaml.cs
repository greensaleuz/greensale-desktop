using GreenSale.Integrated.API.Auth;
using GreenSale.ViewModels.Models.SellerPosts;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for ProductViewUserControl.xaml
    /// </summary>
    public partial class SellerProductViewUserControl : UserControl
    {
        public SellerProductViewUserControl()
        {
            InitializeComponent();
        }
        public void SetData(SellerPost post)
        {
            string image = AuthAPI.BASE_URL + post.image[0];
            Uri imageUri = new Uri(image, UriKind.Absolute);

            SellerPostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.region;
            txtbDescription.Text = post.description;
            txtbPrice.Text = post.price.ToString();
            txtbUpdate.Text = post.updatedAt.ToString();
            txtTitle.Text = post.title;
            txtbCapacity.Text = post.capacity.ToString();
            txtbCapacityMeasure.Text  = post.capacityMeasure.ToString();
        }
    }
}
