using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAsync(IDictionary<string, string> query);

        Task<Admin?> GetByIdAsync(Guid id);

        Task<Admin> CreateAsync(Admin admin);

        Task<Admin?> UpdateByIdAsync(Guid id, Admin admin);
        Task<bool> DeleteByIdAsync(Guid id);

    }
}
