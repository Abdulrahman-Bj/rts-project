using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly APIServicesDbContext dbContext;

        public ReservationRepository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();

            return reservation;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var existingReservation = await dbContext.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (existingReservation == null)
            {
                return false;
            }

            dbContext.Reservations.Remove(existingReservation);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync(IDictionary<string, string> query)
        {
            var reservations = dbContext.Reservations.Include(r => r.Room).Include(r => r.Room.Hotel).Include(r => r.Client).AsQueryable(); 
            var queryParams = query.ToDictionary();
            var apiFeature = new ApiFeatures<Reservation>(reservations, queryParams).Filter().Sort().Paginate().Build();

            var result = await apiFeature.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Reservation>> GetAllHotelReservationsAsync(Guid hotelId, IDictionary<string, string> query)
        {
            var reservations = dbContext.Reservations.Include(r => r.Room).Where(r => r.Room.HotelId == hotelId).Include(r => r.Client).AsQueryable();
            var queryParams = query.ToDictionary();
            var apiFeature = new ApiFeatures<Reservation>(reservations, queryParams).Filter().Sort().Paginate().Build();

            var result = await apiFeature.ToListAsync();
            return result;

        }


        public async Task<Reservation?> GetByIdAsync(Guid id)
        {
            var existingReservation = await dbContext.Reservations.Include(r => r.Room).Include(r => r.Room.Hotel).Include(x => x.Client).FirstOrDefaultAsync(r => r.Id == id);

            if (existingReservation == null)
            {
                return null;
            }

            return existingReservation;
        }


        public async Task<IEnumerable<Reservation>> GetOverLappingReservationAsync(Guid roomId, DateTime startedAt, DateTime endedAt)
        {
            return await dbContext.Reservations.WhereByRoom(roomId).WhereOverlapping(startedAt, endedAt).ToListAsync();
        }


        public async Task<Reservation?> UpdateByIdAsync(Guid id, Reservation reservation)
        {
            var existingReservation = await dbContext.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if (existingReservation == null)
            {
                return null;
            }

            existingReservation.Status = reservation.Status;
            existingReservation.UpdatedAt = reservation.UpdatedAt;

            await dbContext.SaveChangesAsync();

            return existingReservation;


        }
    }
}
