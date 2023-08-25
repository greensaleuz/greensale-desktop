using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.SellerPosts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Services.BuyerPosts
{
    public class BuyerPostService : IBuyerPostService
    {
        public async Task<List<BuyerPost>> GetAllAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + "/api/common/buyer/posts");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            List<BuyerPost> posts = JsonConvert.DeserializeObject<List<BuyerPost>>(response);

            return posts;
        }

        public async Task<List<BuyerPost>> GetAllUserId(long userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/buyer/posts/all/{userId}");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            List<BuyerPost> posts = JsonConvert.DeserializeObject<List<BuyerPost>>(response);

            return posts;
        }

        public Task<BuyerPost> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
