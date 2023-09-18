using GreenSale.ViewModels.Models.BuyerPosts;
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
using System.Xml.Linq;

namespace GreenSale.Desktop.Companents.Images
{
    /// <summary>
    /// Interaction logic for BuyerUpdateImageComponent.xaml
    /// </summary>
    public partial class BuyerUpdateImageComponent : UserControl
    {
        public Func<long, string, Task> Refresh { get; set; }
        private BuyerPostImage buyerPost = new BuyerPostImage();
        public long Id { get; private set; }
        public BuyerUpdateImageComponent()
        {
            InitializeComponent();
        }

        public void SetData(BuyerPostImage buyerPostImage)
        {
            this.buyerPost = buyerPostImage;
            string image = "http://128.199.140.234:3030/" + buyerPostImage.ImagePath;

            Uri imageUri = new Uri(image, UriKind.Absolute);
            ImgBuyer.ImageSource = new BitmapImage(imageUri);
            Id = buyerPostImage.Id;
        }

        private async void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Refresh(buyerPost.Id, buyerPost.ImagePath);
        }
    }
}
