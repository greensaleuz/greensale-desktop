using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.Users;
using GreenSale.Integrated.Security;
using GreenSale.ViewModels.Models.Auth;
using GreenSale.ViewModels.Models.Storages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Services.Users
{
    public class UserService : IUserService
    {
        public async Task<UserModel> GetAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AuthAPI.BASE_URL + "/api/account");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var result = client.GetAsync(client.BaseAddress);
            string response = await result.Result.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserModel>(response);
            return user!;
        }
    }
}
