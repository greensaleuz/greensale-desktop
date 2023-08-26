using GreenSale.Desktop.Windows.Products;
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
        private long ID { get; set; }

        public static long sellerId { get; set; }

        public SellerProductViewUserControl()
        {
            InitializeComponent();
        }
        public void SetData(SellerPost post)
        {
            string image ="http://95.130.227.68:8080/"+ post.mainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            SellePostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.region;
            txtbDescription.Text = post.description;
            txtbPrice.Text = post.price.ToString();
            txtbUpdate.Text = post.updatedAt.ToString();
            txtTitle.Text = post.title;
            txtbCapacity.Text = post.capacity.ToString();
            txtbCapacityMeasure.Text  = post.capacityMeasure.ToString();
            ID = post.Id;
        }

        private void btnReadmore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sellerId = ID;
            SellerProductViewWindow seller = new SellerProductViewWindow();
            seller.ShowDialog();
            
        }
    }
}
