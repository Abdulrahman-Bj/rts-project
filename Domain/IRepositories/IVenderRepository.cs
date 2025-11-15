using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IVenderRepository
    {
        Task<IEnumerable<Vender>> GetAllAsync(IDictionary<string, string> query);

        Task<Vender?> GetByIdAsync(Guid id);

        Task<Vender?> UpdateByIdAsync(Guid id, Vender vender);

        Task<Vender> CreateAsync(Vender vender);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
