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
    public class ServicesRespository : IServiceRepository
    {
        private readonly APIServicesDbContext dbContext;

        public ServicesRespository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Service> CreatedAsync(Service services)
        {
            await dbContext.Services.AddAsync(services);
            await dbContext.SaveChangesAsync();
            return services;

        }

        public async Task<bool> DeletebByIdAsync(Guid id)
        {
            var service = await dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return false;
            }
            dbContext.Services.Remove(service);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Service>> GetAllAsync(IDictionary<string, string> query)
        {
            var services = dbContext.Services.AsQueryable();
            var queryParams = query.ToDictionary();
            var apiFeature = new ApiFeatures<Service>(services, queryParams).Filter().Sort().Paginate().Build();

            return await apiFeature.ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(Guid id)
        {
            var existingService = await dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (existingService == null)
            {
                return null;
            }

            return existingService;

        }

        public async Task<Service?> UpdateByIdAsync(Guid id, Service services)
        {
            var existingService = await dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (existingService == null)
            {
                return null;
            }

            existingService.Name = services.Name;
            existingService.Icon = services.Icon;
            existingService.UpdatedAt = services.UpdatedAt;

            await dbContext.SaveChangesAsync();
            return existingService;
        }
    }
}
