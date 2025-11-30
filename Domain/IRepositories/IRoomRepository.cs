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

        Task<Room> CreateAsync(Room room, IEnumerable<Guid> serviceIds);

        Task<Room?> UpdateByIdAsync(Guid id, Room room);
        Task<bool> DeleteByIdAsync(Guid id);

        Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(Guid hotelId, IDictionary<string,string> queryParams);
    }
}
