﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for BuyerProductCreateWindow.xaml
    /// </summary>
    public partial class BuyerProductCreateWindow : Window
    {
        public BuyerProductCreateWindow()
        {
            InitializeComponent();
        }

        private void btnCreateWindowClose_Click(object sender, RoutedEventArgs e)
        {
            BuyerProductCreateWindow buyerProductCreateWindow = new BuyerProductCreateWindow();
            this.Close();
        }

        private void btnPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Img.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                    ImgIcon.Visibility = Visibility.Hidden;
                    btnPicture2.Visibility = Visibility.Visible;
                }
            }

        }

        private void btnPicture2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Img2.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img2.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                    ImgIcon2.Visibility = Visibility.Hidden;
                    btnPicture3.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnPicture3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Img3.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img3.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                    ImgIcon3.Visibility = Visibility.Hidden;
                    btnPicture4.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnPicture4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Img4.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img4.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                    ImgIcon4.Visibility = Visibility.Hidden;
                    btnPicture5.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnPicture5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Img5.ImageSource == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imgPath = openFileDialog.FileName;
                    Img5.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                    ImgIcon5.Visibility = Visibility.Hidden;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            string filteredText = Regex.Replace(text, "[^0-9]+", "");

            if (text != filteredText)
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex > 0 ? caretIndex - 1 : 0;
            }
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            string filteredText = Regex.Replace(text, "[^0-9]+", "");

            if (text != filteredText)
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex > 0 ? caretIndex - 1 : 0;
            }
        }
    }
}
