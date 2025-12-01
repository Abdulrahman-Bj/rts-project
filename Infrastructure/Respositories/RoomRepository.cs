using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Respositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly APIServicesDbContext dbContext;

        public RoomRepository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Room> CreateAsync(Room room, IEnumerable<Guid> serviceIds)
        {

            if (serviceIds != null && serviceIds.Any())
            {
                room.Services = await dbContext.Services
                    .Where(service => serviceIds.Contains(service.Id))
                    .ToListAsync();
            }

            await dbContext.Rooms.AddAsync(room);
            await dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var exitingRoom = await dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingRoom == null)
            {
                return false;
            }

            dbContext.Rooms.Remove(exitingRoom);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Room>> GetAllAsync(IDictionary<string, string> query)
        {
            var rooms = dbContext.Rooms.Include(x => x.Hotel).Include(x => x.Services).Include(x => x.Images).AsQueryable();

            var queryParams = query.ToDictionary();

            var apiFeature = new ApiFeatures<Room>(rooms, queryParams).Filter().Sort().Paginate().Build();

            return await apiFeature.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await dbContext.Rooms.Include(x => x.Hotel).Include(x => x.Services).Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(Guid hotelId, IDictionary<string, string> query)
        {
            var rooms = dbContext.Rooms.Where(x => x.HotelId == hotelId).Include(x => x.Images).Include(x =>x.CoverImage).AsQueryable();

            var queryParams = query.ToDictionary();

            var apiFeature = new ApiFeatures<Room>(rooms, queryParams).Filter().Sort().Paginate().Build();

            return await apiFeature.ToListAsync();

        }


        public async Task<Room?> UpdateByIdAsync(Guid id, Room room)
        {
            var exitingRoom = await dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingRoom == null)
            {
                return null;
            }

            exitingRoom.Name = room.Name;
            exitingRoom.HotelId = room.HotelId;
            exitingRoom.CoverImage = room.CoverImage;
            exitingRoom.Images = room.Images;
            exitingRoom.Type = room.Type;
            exitingRoom.UpdatedAt = room.UpdatedAt;
            exitingRoom.Description = room.Description;
            exitingRoom.DailyPrice = room.DailyPrice;
            exitingRoom.WeeklyPrice = room.WeeklyPrice;
            exitingRoom.MonthlyPrice = room.MonthlyPrice;
            exitingRoom.Discount = room.Discount;
            exitingRoom.DiscountType = room.DiscountType;

            await dbContext.SaveChangesAsync();

            return exitingRoom;
        }
    }
}
