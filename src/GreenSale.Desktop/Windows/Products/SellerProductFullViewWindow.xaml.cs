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
    /// Interaction logic for SellerProductFullViewWindow.xaml
    /// </summary>
    public partial class SellerProductFullViewWindow : Window
    {
        public SellerProductFullViewWindow()
        {
            InitializeComponent();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img.ImageSource;
        }

        private void btnPicture1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img1.ImageSource;

        }

        private void btnPicture2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img2.ImageSource;

        }

        private void btnPicture3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img3.ImageSource;

        }

        private void btnPicture4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgMain.ImageSource = Img.ImageSource;

        }
    }
}
