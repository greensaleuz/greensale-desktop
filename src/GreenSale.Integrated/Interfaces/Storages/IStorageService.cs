using GreenSale.ViewModels.Models.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Integrated.Interfaces.Storages
{
    public interface IStorageService
    {
        public Task<List<Storage>> GetAllAsync();
    }
}
