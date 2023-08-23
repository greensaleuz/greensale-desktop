﻿using GreenSale.Desktop.Windows.Products;
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

namespace GreenSale.Desktop.Pages.CreateAd
{
    /// <summary>
    /// Interaction logic for StorageCreateAd.xaml
    /// </summary>
    public partial class StorageCreateAd : Page
    {
        public StorageCreateAd()
        {
            InitializeComponent();
        }

        private void btnStorageCreate_Click(object sender, RoutedEventArgs e)
        {
            StorageProductCreateWindow storageProductCreateWindow = new StorageProductCreateWindow();
            storageProductCreateWindow.ShowDialog();
        }
    }
}
