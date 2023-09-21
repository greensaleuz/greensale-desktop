using GreenSale.Desktop.Windows.Products;
using GreenSale.Integrated.API.Auth;
using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.SellerPosts;
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
    /// Interaction logic for BuyerProductViewUserControl.xaml
    /// </summary>
    public partial class BuyerProductViewUserControl : UserControl
    {
        private long ID { get; set; }

        public static long storageId { get; set; }

        public BuyerProductViewUserControl()
        {
            InitializeComponent();
        }
        public void SetData(BuyerPost post)
        {
            string image = $"{AuthAPI.BASE_URL_IMG}" + post.mainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            BuyerPostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.region;
            txtbDescription.Text = post.description;
            txtbPrice.Text = post.price.ToString();
            txtbUpdate.Text = post.updatedAt.ToString();
            txtTitle.Text = post.title;
            txtbCapacity.Text = post.capacity.ToString();
            txtbCapacityMeasure.Text = post.capacityMeasure.ToString();
            ID = post.Id;
        }

        public void SetData(BuyerPosrtSearchViewModel post)
        {
            string image = $"{AuthAPI.BASE_URL_IMG}" + post.MainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            BuyerPostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.Region;
            txtbDescription.Text = post.Description;
            txtbPrice.Text = post.Price.ToString();
            txtbUpdate.Text = post.UpdatedAt.ToString();
            txtTitle.Text = post.Title;
            txtbCapacity.Text = post.Capacity.ToString();
            txtbCapacityMeasure.Text = post.CapacityMeasure.ToString();
            ID = post.Id;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnReadMore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            storageId = ID;
            BuyerProductViewWindow buyer = new BuyerProductViewWindow();
            buyer.ShowDialog();
        }
    }
}
