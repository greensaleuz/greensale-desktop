using GreenSale.Desktop.Companents.Loader;
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
            string image =$"{AuthAPI.BASE_URL_IMG}"+ post.mainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            SellePostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.region;
            txtbDescription.Text = post.description;
            txtbPrice.Text = post.price.ToString();
            txtbUpdate.Text = post.updatedAt.ToString("hh:mm") + " " + post.updatedAt.ToString("dd-MM-yy");
            txtTitle.Text = post.title;
            txtbCapacity.Text = post.capacity.ToString();
            txtbCapacityMeasure.Text  = post.capacityMeasure.ToString();
            if(post.AverageStars.ToString().Length > 1)
            {
                var str = post.AverageStars.ToString().Split(',');
                starAvareg.Content = str[0] + "." + str[1];
            }
            else
            {
                starAvareg.Content = post.AverageStars.ToString();
            }
            

            if (post.status == 0)
            {
                txtbStatus.Text = "Yangi";
                statusPost.Background = new SolidColorBrush(Colors.Green);
                txtbStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else if (post.status == 1)
            {
                txtbStatus.Text = "Kelishilgan";
                statusPost.Background = new SolidColorBrush(Colors.Yellow);
                txtbStatus.Foreground = new SolidColorBrush(Colors.Yellow);

            }
            else if (post.status == 2) 
            {
                txtbStatus.Text = " Sotib olingan";
                statusPost.Background = new SolidColorBrush(Colors.Red);
                txtbStatus.Foreground = new SolidColorBrush(Colors.Red);

            }
            ID = post.Id;
        }


        public void SetData(SellerPostViewModelSearch post)
        {
            string image = $"{AuthAPI.BASE_URL_IMG}" + post.MainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            SellePostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.Region;
            txtbDescription.Text = post.Description;
            txtbPrice.Text = post.Price.ToString();
            txtbUpdate.Text = post.UpdatedAt.ToString();
            txtTitle.Text = post.Title;
            txtbCapacity.Text = post.Capacity.ToString();

            txtbCapacityMeasure.Text = post.CapacityMeasure.ToString();
            ID = post.Id;
        }

        private void btnReadmore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sellerId = ID;
            SellerProductViewWindow seller = new SellerProductViewWindow();
            seller.ShowDialog();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PictureLoader loader = new PictureLoader();
           
        }
    }
}
