using GreenSale.ViewModels.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Interfaces.Users
{
    public interface IUserService
    {
        public Task<UserModel> GetAsync();
    }
}
