using GreenSale.Dtos.Dtos.Storages;
using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.Integrated.Security;
using GreenSale.ViewModels.Models.BuyerPosts;
using GreenSale.ViewModels.Models.Storages;
using Newtonsoft.Json;

namespace GreenSale.Integrated.Services.Storages
{

    public class StorageService : IStorageService
    {
        public async Task<bool> CreateAsync(StorageDto dto)
        {

            var token = IdentitySingelton.GetInstance().Token;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, AuthAPI.BASE_URL + "/api/client/storages");
            request.Headers.Add("Authorization", $"Bearer {token}");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.Description), "Description");
            content.Add(new StringContent(dto.Region), "Region");
            content.Add(new StringContent(dto.District), "District");
            content.Add(new StringContent(dto.AddressLatitude.ToString()), "AddressLatitude");
            content.Add(new StringContent(dto.AddressLongitude.ToString()), "AddressLongitude");
            content.Add(new StringContent(dto.Address), "Address");
            content.Add(new StringContent(dto.Info), "Info");
            content.Add(new StreamContent(File.OpenRead(dto.ImagePath)), "ImagePath", dto.ImagePath);

            request.Content = content;
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;

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

            if (message.StatusCode.ToString() != "NotFound")
            {
                string response = await message.Content.ReadAsStringAsync();
                List<Storage> posts = JsonConvert.DeserializeObject<List<Storage>>(response);
                return posts;
            }
            return new List<Storage>();
        }

        public async Task<StorageGetById> GetByIdAsync(long storageId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/storage/{storageId}");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            StorageGetById posts = JsonConvert.DeserializeObject<StorageGetById>(response);

            return posts;
        }

        public async Task<StorageSearchViewModel> SearchAsync(string info)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + $"/api/common/storage/search/info?search={info}");
                HttpResponseMessage message = await client.GetAsync(client.BaseAddress);

                if (message.StatusCode.ToString() != "NotFound")
                {
                    var respons = await message.Content.ReadAsStringAsync();
                    StorageSearchViewModel StoragePost = JsonConvert.DeserializeObject<StorageSearchViewModel>(respons)!;
                    return StoragePost;
                }
                return new StorageSearchViewModel { };
            }
            catch
            {
                return new StorageSearchViewModel { };
            }
        }

        public async Task<bool> UpdateAsync(long storageId, StorageUpdateDto dto)
        {
            var token = IdentitySingelton.GetInstance().Token;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, AuthAPI.BASE_URL + $"/api/client/storages/{storageId}");
            request.Headers.Add("Authorization", $"Bearer {token}");

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(dto.Name), "Name");
            content.Add(new StringContent(dto.Description), "Description");
            content.Add(new StringContent(dto.Region), "Region");
            content.Add(new StringContent(dto.District), "District");
            content.Add(new StringContent(dto.AddressLatitude.ToString()), "AddressLatitude");
            content.Add(new StringContent(dto.AddressLongitude.ToString()), "AddressLongitude");
            content.Add(new StringContent(dto.Address), "Address");
            content.Add(new StringContent(dto.Info), "Info");
            content.Add(new StreamContent(File.OpenRead(dto.ImagePath)), "ImagePath", dto.ImagePath);

            request.Content = content;
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return true;
            }
            var res1 = await response.Content.ReadAsStringAsync();
            return false;
        }

        public async Task<bool> UpdateImageStorageAsync(StorageImageDto dto)
        {
            try
            {
                var token = IdentitySingelton.GetInstance().Token;
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, AuthAPI.BASE_URL + $"/api/client/storages/image/{dto.StorageId}");
                request.Headers.Add("Authorization", $"Bearer {token}");

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(File.OpenRead(dto.ImagePath)), "ImagePath", dto.ImagePath);
                content.Add(new StringContent(dto.StorageId.ToString()), "StorageId");


                request.Content = content;
                var response = await client.SendAsync(request);

                var res = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
