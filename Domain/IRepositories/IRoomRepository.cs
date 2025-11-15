using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync(IDictionary<string, string> queryParams);
        Task<Room?> GetByIdAsync(Guid id);

        Task<Room> CreateAsync(Room room);

        Task<Room?> UpdateByIdAsync(Guid id, Room room);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
