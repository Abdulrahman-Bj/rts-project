using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync(IDictionary<string, string> query);

        Task<Service?> GetByIdAsync(Guid id);

        Task<Service> CreatedAsync(Service services);

        Task<Service?> UpdateByIdAsync(Guid id, Service services);

        Task<bool> DeletebByIdAsync(Guid id);


    }
}
