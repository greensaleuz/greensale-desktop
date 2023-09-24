﻿using GreenSale.Desktop.Companents.Products;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Services.SellerPosts;
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

namespace GreenSale.Desktop.Pages.Sellers
{
    /// <summary>
    /// Interaction logic for SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Page
    {
        private ISellerPost _service;
        public Action RefreshPage { get; set; }
        public SellerPage()
        {
            InitializeComponent();
            this._service= new SellerPostService();
        }

        private async void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        public async Task Refresh()
        {
            wrpSellerPost.Children.Clear();
            var sellerpost = await _service.GetAllAsync();
            loader.Visibility = Visibility.Collapsed;
            foreach (var post in sellerpost)
            {
                SellerProductViewUserControl userControl = new SellerProductViewUserControl();
                userControl.SetData(post);
                wrpSellerPost.Children.Add(userControl);
            }
        }
        private async void By_Pst_TextBoxSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && TextBoxSearch.Text.Length > 0)
            {
                var buyerpost = await _service.SearchAsync(TextBoxSearch.Text.ToString());
                wrpSellerPost.Children.Clear();
                foreach (var post in buyerpost.item2)
                {
                    SellerProductViewUserControl buyerProductViewUserControl = new SellerProductViewUserControl();
                    buyerProductViewUserControl.SetData(post);
                    wrpSellerPost.Children.Add(buyerProductViewUserControl);
                }
            }
        }

        private async void By_Pst_TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text.Length == 0)
            {
                wrpSellerPost.Children.Clear();
                var sellerPost = await _service.GetAllAsync();
                loader.Visibility = Visibility.Collapsed;
                foreach (var post in sellerPost)
                {
                    SellerProductViewUserControl buyerProductViewUserControl = new SellerProductViewUserControl();
                    buyerProductViewUserControl.SetData(post);
                    wrpSellerPost.Children.Add(buyerProductViewUserControl);
                }
            }
        }
    }
}
