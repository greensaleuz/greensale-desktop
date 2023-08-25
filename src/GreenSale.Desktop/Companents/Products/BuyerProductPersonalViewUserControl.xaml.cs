﻿using GreenSale.ViewModels.Models.BuyerPosts;
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
    /// Interaction logic for BuyerProductPersonalViewUserControl.xaml
    /// </summary>
    public partial class BuyerProductPersonalViewUserControl : UserControl
    {
        public BuyerProductPersonalViewUserControl()
        {
            InitializeComponent();
        }
        public void SetData(BuyerPost post)
        {
            string image = "http://95.130.227.68:8080/" + post.mainImage;
            Uri imageUri = new Uri(image, UriKind.Absolute);

            BuyerPostImage.ImageSource = new BitmapImage(imageUri);
            txtbRegion.Text = post.region;
            txtbDescription.Text = post.description;
            txtbPrice.Text = post.price.ToString();
            txtbUpdate.Text = post.updatedAt.ToString();
            txtTitle.Text = post.title;
            txtbCapacity.Text = post.capacity.ToString();
            txtbCapacityMeasure.Text = post.capacityMeasure.ToString();
        }
    }
}
