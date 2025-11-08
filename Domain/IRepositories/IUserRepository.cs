using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> GetById(Guid id);

        Task<User?> UpdateByIdAsync(Guid id, User user);

        Task<User> CreateAsync(User user);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
