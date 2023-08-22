using GreenSale.Dtos.Dtos.Auth;
using GreenSale.Integrated.API.Auth;
using GreenSale.Integrated.Interfaces.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Services.Auth
{
    public class AuthService : IAuthService
    {
        public Task<bool> CheckTokenAsync(AuthorizationDto token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginAsync(UserLoginDto dto)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(AuthAPI.BASE_URL);
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{AuthAPI.BASE_URL}/api/auth/login");
            var content = new StringContent(JsonConvert.SerializeObject(dto), null, "application/json");
            httpRequestMessage.Content = content;
            var response = await client.SendAsync(httpRequestMessage);
            
            if (response.IsSuccessStatusCode)
            {
                //save to identity
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(ForgotPassword dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendCodeForRegisterAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyRegisterAsync(string phoneNumber, int code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetPasswordAsync(string phoneNumber, int code)
        {
            throw new NotImplementedException();
        }
    }
}
