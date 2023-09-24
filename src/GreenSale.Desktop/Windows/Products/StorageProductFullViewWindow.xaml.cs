﻿using GreenSale.Desktop.Companents.Products;
using GreenSale.Dtos.Dtos.Storages;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Services.Storages;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using GreenSale.ViewModels.Models.Storages;
using Microsoft.Identity.Client.Extensions.Msal;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;
using System.Reflection;
using GreenSale.Integrated.API.Auth;
using System.Windows.Media;

namespace GreenSale.Desktop.Windows.Products
{
    /// <summary>
    /// Interaction logic for StorageProductFullViewWindow.xaml
    /// </summary>
    public partial class StorageProductFullViewWindow : Window
    {
        private IStorageService _service;
        public long storageId { get; set; }
        public int Star_CountUP { get; set; }
        public int Star_Count { get; set; }

        public Func<Task> Refresh { get; set; }
        public StorageProductFullViewWindow()
        {
            InitializeComponent();
            this._service = new StorageService();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            long id = StorageProductPersonalViewUserControl.storageId;
            storageId = id;
            var storage = await _service.GetByIdAsync(id);

            txtbName.Text = storage.StorageName;
            txtbFullName.Text = storage.FullName.Split()[0];
            txtbDescription.Text = storage.Description;
            txtbDistrict.Text = storage.District;
            txtbAddress.Text = storage.Address;
            txtbInfo.Text = storage.Info;
            txtbPhoneNumber.Text = storage.PhoneNumber;
            txtbRegion.Text = storage.Region;
            

            string image = $"{AuthAPI.BASE_URL_IMG}" + storage.ImagePath;
            Uri imageUri = new Uri(image, UriKind.Absolute);
            ImgStorage.ImageSource = new BitmapImage(imageUri);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string DowlaodImage(string url)
        {
            try
            {
                string saveDirectory = "C:\\Users\\Lenovo\\source\\repos\\greensale-desktop\\src\\GreenSale.Desktop\\Assets\\Dowloands\\Images\\";
                //string currentAssemblyPath = Assembly.GetExecutingAssembly().Location;
                string fileName = Path.GetFileName(url);

                string localFilePath = Path.Combine(saveDirectory, fileName);

                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                using (WebClient client = new WebClient())
                {
                    if(!File.Exists(localFilePath))
                        client.DownloadFile(url, localFilePath);
                }

                return localFilePath;
            }
            catch 
            {
                return "";
            }
            
        }
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            StorageUpdateDto dto = new StorageUpdateDto();
            dto.Info = txtbInfo.Text.ToString(); 
            dto.Description = txtbDescription.Text.ToString();
            dto.District = txtbDistrict.Text.ToString();
            dto.Region = txtbRegion.Text.ToString();
            dto.AddressLatitude = 238434637;
            dto.AddressLongitude = 20930846; 
            dto.Name = txtbName.Text.ToString();
            dto.Address = txtbAddress.Text.ToString();
           // dto.ImagePath = DowlaodImage(ImgStorage.ImageSource.ToString());

            long id = StorageProductPersonalViewUserControl.storageId;
            var storage = await _service.UpdateAsync(id,dto);
        
        }

        private void btnPicture_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (btnPicture.IsMouseOver == true)
            {
                ImgIcon.Visibility = Visibility.Visible;
                btnPicture.BorderThickness = new Thickness(2);

            }
            else
            {
                ImgIcon.Visibility = Visibility.Hidden;
                btnPicture.BorderThickness = new Thickness(0);
            }
        }
        private async void btnPicture_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var CurrentImage = ImgStorage.ImageSource.ToString();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgStorage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                ImgIcon.Visibility = Visibility.Hidden;
                btnPicture.BorderThickness = new Thickness(0);

                StorageImageDto storageImageDto = new StorageImageDto()
                {
                    StorageId = storageId,
                    StorageImagePath = imgPath,
                };

                var result = await _service.UpdateImageStorageAsync(storageImageDto);

                if (result)
                {
                    MessageBox.Show("Yangilandi");
                }
                else
                {
                    MessageBox.Show("yangilanmadi ");
                }
            }
        }

        int star_count = 0;
        private void click_star_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            star_2.Fill = new SolidColorBrush(Colors.Transparent);
            star_3.Fill = new SolidColorBrush(Colors.Transparent);
            star_4.Fill = new SolidColorBrush(Colors.Transparent);
            star_5.Fill = new SolidColorBrush(Colors.Transparent);
            //-------
            star_1.Fill = new SolidColorBrush(Colors.Yellow);
            Star_CountUP = 1;
        }

        private void click_star_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            star_2.Fill = new SolidColorBrush(Colors.Yellow);
            star_3.Fill = new SolidColorBrush(Colors.Transparent);
            star_4.Fill = new SolidColorBrush(Colors.Transparent);
            star_5.Fill = new SolidColorBrush(Colors.Transparent);
            //-------
            star_1.Fill = new SolidColorBrush(Colors.Yellow);
            Star_CountUP = 2;
        }

        private void click_star_3(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            star_2.Fill = new SolidColorBrush(Colors.Yellow);
            star_3.Fill = new SolidColorBrush(Colors.Yellow);
            star_4.Fill = new SolidColorBrush(Colors.Transparent);
            star_5.Fill = new SolidColorBrush(Colors.Transparent);
            //-------
            star_1.Fill = new SolidColorBrush(Colors.Yellow);
            Star_CountUP = 3;
        }

        private void click_star_4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            star_2.Fill = new SolidColorBrush(Colors.Yellow);
            star_3.Fill = new SolidColorBrush(Colors.Yellow);
            star_4.Fill = new SolidColorBrush(Colors.Yellow);
            star_5.Fill = new SolidColorBrush(Colors.Transparent);
            //-------
            star_1.Fill = new SolidColorBrush(Colors.Yellow);
            Star_CountUP = 4;
        }

        private void click_star_5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            star_2.Fill = new SolidColorBrush(Colors.Yellow);
            star_3.Fill = new SolidColorBrush(Colors.Yellow);
            star_4.Fill = new SolidColorBrush(Colors.Yellow);
            star_5.Fill = new SolidColorBrush(Colors.Yellow);
            //-------
            star_1.Fill = new SolidColorBrush(Colors.Yellow);
            Star_CountUP = 5;
        }
    }
}

