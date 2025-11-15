using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync(IDictionary<string, string> queryParams);

        Task<Client?> GetById(Guid id);

        Task<Client?> UpdateByIdAsync(Guid id, Client client);

        Task<Client> CreateAsync(Client client);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
