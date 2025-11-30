using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync(IDictionary<string, string> query);
        Task<Currency?> GetByIdAsync(Guid id);
        Task<Currency?> UpdateByIdAsync(Guid id, Currency currency);
        Task<Currency> CreateAsync(Currency currency);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
