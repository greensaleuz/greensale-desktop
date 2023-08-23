using GreenSale.ViewModels.Models.SellerPosts;
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
    }
}
