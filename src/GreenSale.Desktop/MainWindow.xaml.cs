using GreenSale.Desktop.Pages;
using GreenSale.Desktop.Pages.Buyers;
using GreenSale.Desktop.Pages.CreateAd;
using GreenSale.Desktop.Pages.Dashbord;
using GreenSale.Desktop.Pages.Sellers;
using GreenSale.Desktop.Pages.Storages;
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

namespace GreenSale.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        bool IsMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    IsMaximized = false;
                }

                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AsosiyButton_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            FrameFilter.Content = dashboard;
        }

        private void btnCreateAd_Click(object sender, RoutedEventArgs e)
        {
            ChooseAd chooseAd = new ChooseAd();
            FrameFilter.Content=chooseAd;
        }

        private void btnSeller_Click(object sender, RoutedEventArgs e)
        {
            SellerPage sellerPage = new SellerPage();
            FrameFilter.Content = sellerPage;
        }

        private void btnStorage_Click(object sender, RoutedEventArgs e)
        {
            StoragePage storagePage = new StoragePage();
            FrameFilter.Content = storagePage;
        }

        private void btnBuyer_Click(object sender, RoutedEventArgs e)
        {
            BuyerPage buyerPage = new BuyerPage();
            FrameFilter.Content = buyerPage;
        }
    }
}
