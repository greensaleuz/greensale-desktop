using GreenSale.Dtos.Dtos.Storages;
using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Security;
using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Services.Storages
{

    public class StorageService : IStorageService
    {
        public async Task<bool> CreateAsync(StorageDto dto)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AuthAPI.BASE_URL + "/api/client/storages");
            MultipartFormDataContent multipart = new MultipartFormDataContent();
            
            string json = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var res = await client.PostAsync(client.BaseAddress, content);
            var response = await res.Content.ReadAsStringAsync();
           

            return response == "true";
        }

        public async Task<bool> DeleteAsync(long storageId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AuthAPI.BASE_URL + $"/api/client/storages/{storageId}");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var result = await client.DeleteAsync(client.BaseAddress);
            string response = await result.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<List<Storage>> GetAllAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + "/api/common/storage");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            List<Storage> posts = JsonConvert.DeserializeObject<List<Storage>>(response);

            return posts;
        }

        public async Task<List<Storage>> GetAllUserId(long userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/storage/all/{userId}");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            List<Storage> posts = JsonConvert.DeserializeObject<List<Storage>>(response);

            return posts;
        }
    }
}
