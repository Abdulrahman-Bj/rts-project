using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync(IDictionary<string, string> query);

        Task<Hotel?> GetByIdAsync(Guid id);

        Task<Hotel> CreateAsync(Hotel hotel);

        Task<Hotel?> UpdateByIdAsync(Guid id, Hotel hotel);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
