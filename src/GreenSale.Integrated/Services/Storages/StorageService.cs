using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.Storages;
using GreenSale.ViewModels.Models.SellerPosts;
using GreenSale.ViewModels.Models.Storages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Services.Storages
{
    public class StorageService : IStorageService
    {
        public async Task<List<Storage>> GetAllAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{AuthAPI.BASE_URL}" + "/api/common/storage");
            HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
            string response = await message.Content.ReadAsStringAsync();
            List<Storage> posts = JsonConvert.DeserializeObject<List<Storage>>(response);

            return posts;
        }
    }
}
