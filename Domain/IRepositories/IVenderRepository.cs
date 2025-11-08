using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    internal interface IVenderRepository
    {
        Task<IEnumerable<Vender>> GetAllAsync();

        Task<Vender?> GetById(Guid id);

        Task<Vender?> UpdateByIdAsync(Guid id, Vender vender);

        Task<Vender> CreateAsync(Vender vender);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
