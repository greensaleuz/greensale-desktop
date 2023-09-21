using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Interfaces.Users;
using GreenSale.Integrated.Services.BuyerPosts;
using GreenSale.Integrated.Services.SellerPosts;
using GreenSale.Integrated.Services.Storages;
using GreenSale.Integrated.Services.Users;
using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenSale.Desktop.Pages.Dashbord
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private ISellerPost _serviceSeller;
        private IBuyerPostService _serviceBuyer;
        private IStorageService _serviceStorage;
        private IUserService _serviseUser;
        public Dashboard()
        {
            InitializeComponent();
            this._serviceSeller = new SellerPostService();
            this._serviceBuyer = new BuyerPostService();
            this._serviceStorage = new StorageService();
            this._serviseUser = new UserService();
        }

        private void User_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public async void Page_Loaded_Dashbord(object sender, RoutedEventArgs e)
        {
            long buoyed_count = 0;
            long new_post = 0;
            
            var seller_count = await _serviceSeller.CountAsync();
            var buyer_count = await _serviceBuyer.CountAsync();
            var user_count = await _serviseUser.CountAsync();

            long count = seller_count + buyer_count;
            post_count.SubTitle = $"Bir yillik e'lonlar soni {count}";

            var seller_post = await _serviceSeller.GetAllAsync();

            buoyed_count += seller_post.Count(seller => seller.status == 1);
            new_post += seller_post.Count(seller => seller.status == 0);

             var buyer_post = await _serviceBuyer.GetAllAsync();

             buoyed_count += buyer_post.Count(buyer => buyer.status == 1);
             new_post += buyer_post.Count(buyer => buyer.status == 0);

            var res = await CanCulateAsync(count, buoyed_count);
            post_buyed.SubTitle = $"Bir yillik kelishilgan e'lonlar soni {buoyed_count}";
            post_buyed.Amount = Convert.ToInt32(res);

            post_new.SubTitle = $"Yangi e'lonlar soni {new_post}";
            post_new.Amount = 100 - Convert.ToInt32(res);

            user_counthml.SubTitle = $"Foydalanuvchilar soni {user_count}";
            var storage_post = await _serviceStorage.GetAllAsync();
            chart(seller_post, buyer_post, storage_post);
        }


        public Task<long> CanCulateAsync(long count, long statsus)
        {

            var x = (statsus * 100) / count;
         
            return Task.FromResult(x);
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        public void chart(List<SellerPost> sellerPosts, List<BuyerPost> buyerPosts, List<Storage> storages)
        {
            DateTime now = DateTime.Now;
            List<Double> item = new List<Double>();
            seller_post_dg.Values.Clear();
            for (int i = 1; i < 7; i++)
            {
                var day = sellerPosts.Count(item => item.createdAt.ToString("dd") == (Convert.ToInt32(now.ToString("dd")) - i).ToString());
                item.Add(day);
                seller_post_dg.Values.Add(Convert.ToDouble(day));
                buyer_post_dg.Values.Add(Convert.ToDouble(day));
                buyer_post_dg.Values.Add(Convert.ToDouble(day));
                storage_post_dg.Values.Add(Convert.ToDouble(day));
            }




        }

    }
}
