using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.SellerPosts;
using GreenSale.Integrated.Security;
using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Services.SellerPosts
{
    public class SellerPostService : ISellerPost
    {
        public async Task<bool> DeleteAsync(long postId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AuthAPI.BASE_URL + $"/api/client/seller/post/{postId}");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var result = await client.DeleteAsync(client.BaseAddress);
            string response = await result.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<List<SellerPost>> GetAllAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + "/api/common/seller/post");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response =  await message.Content.ReadAsStringAsync();
            List<SellerPost> posts = JsonConvert.DeserializeObject<List<SellerPost>>(response);

            return posts;

        }

        public async Task<List<SellerPost>> GetAllUserId(long userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/seller/post/all/{userId}");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            List<SellerPost> posts = JsonConvert.DeserializeObject<List<SellerPost>>(response);

            return posts;
        }


        public async Task<SellerGetById> GetByIdAsync(long postId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/seller/post/{postId}");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            SellerGetById posts = JsonConvert.DeserializeObject<SellerGetById>(response);

            return posts;
        }
    }
}
