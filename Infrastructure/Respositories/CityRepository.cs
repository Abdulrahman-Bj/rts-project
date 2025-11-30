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
    public class CityRepository : ICityRepository
    {
        private readonly APIServicesDbContext dbContext;

        public CityRepository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await dbContext.Cities.ToListAsync();
        }

        public async Task<City> CreateAsync(City city)
        {
            await dbContext.Cities.AddAsync(city);
            await dbContext.SaveChangesAsync();

            return city;
        }
        public async Task<City?> GetById(Guid id)
        {
            return await dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var exitingCity = await dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingCity == null)
            {
                return false;
            }

            dbContext.Cities.Remove(exitingCity);

            await dbContext.SaveChangesAsync();

            return true;

        }




        public async Task<City?> UpdateByIdAsync(Guid id, City city)
        {
            var exitingCity = await dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingCity == null)
            {
                return null;
            }


            exitingCity.Name = city.Name;
            exitingCity.UpdatedAt = city.UpdatedAt;

            await dbContext.SaveChangesAsync();

            return exitingCity;
        }
    }
}
