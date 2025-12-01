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
    public class HotelRepository : IHotelRepository
    {
        private readonly APIServicesDbContext dbContext;

        public HotelRepository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Hotel> CreateAsync(Hotel hotel)
        {
            await dbContext.Hotels.AddAsync(hotel);
            await dbContext.SaveChangesAsync();
            return hotel;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var exitingHotel = await dbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingHotel == null)
            {
                return false;
            }

            dbContext.Hotels.Remove(exitingHotel);

            await dbContext.SaveChangesAsync();

            return true;
        }
        

        public async Task<IEnumerable<Hotel>> GetAllAsync(IDictionary<string, string> query)
        {
            var hotels = dbContext.Hotels.Include(x => x.City).Include(x => x.CoverImage).Include(x => x.Images).AsQueryable();

            var queryParams = query.ToDictionary();

            var apiFeature = new ApiFeatures<Hotel>(hotels, queryParams).Filter().Sort().Paginate().Build();

            return await apiFeature.ToListAsync();
        }

        public async Task<Hotel?> GetByIdAsync(Guid id)
        {
            return await dbContext.Hotels.Include(x => x.City).Include(x => x.CoverImage).Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Hotel?> UpdateByIdAsync(Guid id, Hotel hotel)
        {
            var exitingHotel = await dbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            
            if(exitingHotel != null)
            {
                return null;
            }

            exitingHotel.Name = hotel.Name;
            exitingHotel.CityId = hotel.CityId;
            exitingHotel.CoverImageId = hotel.CoverImageId;
            exitingHotel.Images = hotel.Images;
            exitingHotel.Address = hotel.Address;
            exitingHotel.UpdatedAt = hotel.UpdatedAt;
            await dbContext.SaveChangesAsync();

            return exitingHotel;
        }
    }
}
