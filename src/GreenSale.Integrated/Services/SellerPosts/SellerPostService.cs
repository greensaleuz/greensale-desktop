using GreenSale.Dtos.Dtos.SellerPost;
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
        public async Task<bool> CreateAsync(SellerPostCreate dto)
        {
            var token = IdentitySingelton.GetInstance().Token;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, AuthAPI.BASE_URL + "/api/client/buyer/post");
            request.Headers.Add("Authorization", $"Bearer {token}");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(dto.PhoneNumber), "PhoneNumber");
            content.Add(new StringContent(dto.Title), "Title");
            content.Add(new StringContent(dto.Description), "Description");
            content.Add(new StringContent(dto.Price.ToString()), "Price");
            content.Add(new StringContent(dto.Capacity.ToString()), "Capacity");
            content.Add(new StringContent(dto.CapacityMeasure.ToString()), "CapacityMeasure");
            content.Add(new StringContent(dto.Type), "Type");
            content.Add(new StringContent(dto.Region), "Region");
            content.Add(new StringContent(dto.District), "District");
            content.Add(new StringContent(dto.CategoryId.ToString()), "CategoryID");
            //content.Add(new StreamContent(File.OpenRead(dto.ImagePath)), "ImagePath", dto.ImagePath);

            foreach (var item in dto.ImagePath)
            {
                content.Add(new StreamContent(File.OpenRead(item)), "ImagePath", item);
            }


            request.Content = content;
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }

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
