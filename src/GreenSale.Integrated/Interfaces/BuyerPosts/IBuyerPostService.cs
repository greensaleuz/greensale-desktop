using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Interfaces.BuyerPosts
{
    public interface IBuyerPostService
    {
        public Task<List<BuyerPost>> GetAllAsync();
        public Task<BuyerPost> GetByIdAsync(int id);

        public Task<List<BuyerPost>> GetAllUserId(long userId);
        public Task<bool> DeleteAsync(long postId);


    }
}
