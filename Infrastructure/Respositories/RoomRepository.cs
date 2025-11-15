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
        public async Task<Room> CreateAsync(Room room)
        {
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
            var rooms = dbContext.Rooms.Include(x => x.Hotel).AsQueryable();

            var queryParams = query.ToDictionary();

            var apiFeature = new ApiFeatures<Room>(rooms, queryParams).Filter().Sort().Paginate().Build();

            return await apiFeature.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await dbContext.Rooms.Include(x => x.Hotel).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Room?> UpdateByIdAsync(Guid id, Room room)
        {
            var exitingRoom = await dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingRoom != null)
            {
                return null;
            }

            exitingRoom.Name = room.Name;
            exitingRoom.HotelId = room.HotelId;
            exitingRoom.CoverImage = room.CoverImage;
            exitingRoom.Images = room.Images;
            exitingRoom.Type = room.Type;
            exitingRoom.UpdateAt = room.UpdateAt;
            exitingRoom.Description = room.Description;


            await dbContext.SaveChangesAsync();

            return exitingRoom;
        }
    }
}
