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
    public class VenderRepository : IVenderRepository
    {
        private readonly APIServicesDbContext dbContext;

        public VenderRepository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Vender> CreateAsync(Vender vender)
        {
            await dbContext.Venders.AddAsync(vender);
            await dbContext.SaveChangesAsync();

            return vender;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var existingVender = await dbContext.Venders.FirstOrDefaultAsync(x => x.Id == id);
            if(existingVender == null)
            {
                return false;
            }
            dbContext.Venders.Remove(existingVender);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Vender>> GetAllAsync(IDictionary<string, string> query)
        {
            var venders = dbContext.Venders.Include(x => x.Hotel).AsQueryable();
            var queryParams  = query.ToDictionary();
            var apiFeature = new ApiFeatures<Vender>(venders, queryParams).Filter().Sort().Paginate().Build();
            return await apiFeature.ToListAsync();
        }

        public async Task<Vender?> GetByIdAsync(Guid id)
        {
            return await dbContext.Venders.Include(x => x.Hotel).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Vender?> UpdateByIdAsync(Guid id, Vender vender)
        {
            var existingVender = await dbContext.Venders.FirstOrDefaultAsync(x => x.Id == id);
            if (existingVender == null)
            {
                return null;
            }

            existingVender.Username = vender.Username;
            existingVender.Name = vender.Name;
            existingVender.HotelId = vender.HotelId;
            existingVender.UpdatedAt = vender.UpdatedAt;
            await dbContext.SaveChangesAsync();

            return existingVender;
        }
    }
}
