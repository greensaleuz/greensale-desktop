using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Security;
using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
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
        public async Task<bool> DeleteAsync(long postId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AuthAPI.BASE_URL + $"/api/client/buyer/post/{postId}");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var result = await client.DeleteAsync(client.BaseAddress);
            string response = await result.Content.ReadAsStringAsync();
            return response == "true";
        }

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

        public async Task<BuyerPostGetById> GetByIdAsync(long postId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/buyer/posts/{postId}");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            BuyerPostGetById posts = JsonConvert.DeserializeObject<BuyerPostGetById>(response);

            return posts;
        }
    }
}
