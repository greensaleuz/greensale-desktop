using Microsoft.Win32;
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
    /// Interaction logic for StorageProductCreateWindow.xaml
    /// </summary>
    public partial class StorageProductCreateWindow : Window
    {
        public StorageProductCreateWindow()
        {
            InitializeComponent();
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Img.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img.ImageSource = new BitmapImage(new Uri(imgPath,UriKind.Relative));
                    ImgIcon.Visibility= Visibility.Hidden;
                }

            }
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            StorageProductCreateWindow storageProductCreateWindow   = new StorageProductCreateWindow();
            this.Close();
        }
    }
}
