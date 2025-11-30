using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync(IDictionary<string, string> query);
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<Reservation?> GetByIdAsync(Guid id);
        Task<Reservation?> UpdateByIdAsync(Guid id, Reservation reservation);
        Task<bool> DeleteByIdAsync(Guid id);

        Task<IEnumerable<Reservation>> GetOverLappingReservationAsync(Guid roomId, DateTime startedAt, DateTime endedAt);

        Task<IEnumerable<Reservation>> GetAllHotelReservationsAsync(Guid hotelId, IDictionary<string, string> query);
    }
}
