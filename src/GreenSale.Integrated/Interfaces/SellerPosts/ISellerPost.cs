using GreenSale.Dtos.Dtos.SellerPost;
using GreenSale.ViewModels.Models.BuyerPosts;
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
        public Task<SellerGetById> GetByIdAsync(long postId);
        public Task<bool> CreateAsync(SellerPostCreate dto);
        public Task<List<SellerPost>> GetAllUserId(long userId);
        public Task<bool> DeleteAsync(long postId);
        public Task<bool> UpdateAsync(long postId, SellerPostUpdateDto dto);
        public Task<bool> ImageUpdateAsync(long imageId, SellerPostUpdateImageDto dto);

    }
}
