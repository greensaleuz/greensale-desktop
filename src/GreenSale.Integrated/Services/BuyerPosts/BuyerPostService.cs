﻿using GreenSale.Dtos.Dtos.BuyerPost;
using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.BuyerPosts;
using GreenSale.Integrated.Security;
using GreenSale.ViewModels.Models.BuyerPosts;
using Newtonsoft.Json;

namespace GreenSale.Integrated.Services.BuyerPosts
{
    public class BuyerPostService : IBuyerPostService
    {
        public async Task<bool> CreateAsync(BuyerPostCreateDto dto)
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
            content.Add(new StringContent(dto.Address), "Address");
            content.Add(new StringContent(dto.CategoryID.ToString()), "CategoryID");
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
