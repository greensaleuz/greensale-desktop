using GreenSale.Dtos.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(UserRegisterDto dto);
        public Task<bool> SendCodeForRegisterAsync(string phoneNumber);
        public Task<bool> VerifyRegisterAsync(string phoneNumber, int code);
        public Task<bool> LoginAsync(UserLoginDto dto);
        public Task<bool> ResetPasswordAsync(ForgotPassword dto);
        public Task<bool> VerifyResetPasswordAsync(string phoneNumber, int code);
        public Task<bool> CheckTokenAsync(AuthorizationDto token);
    }
}
