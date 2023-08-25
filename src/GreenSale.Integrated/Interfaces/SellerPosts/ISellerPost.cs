using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Interfaces.SellerPosts
{
    public interface ISellerPost
    {
        public Task<List<SellerPost>> GetAllAsync();
        public Task<SellerPost> GetByIdAsync(int id);
        public Task<List<SellerPost>> GetAllUserId(long userId);
        public Task<bool> DeleteAsync(long postId);

    }
}
