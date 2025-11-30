using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Infrastructure.Respositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly APIServicesDbContext dbContext;

        public ClientRepository( APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<Client>> GetAllAsync(IDictionary<string, string> query)
        {
            var baseQuery = dbContext.Clients.Include(x => x.City).AsQueryable();

            // Convert to dictionary
            var queryParams = query.ToDictionary();

            // Use ApiFeatures for filtering, sorting, pagination
            var apiFeatures = new ApiFeatures<Client>(baseQuery, queryParams)
                                .Filter()
                                .Sort()
                                .Paginate()
                                .Build();

            return await apiFeatures.ToListAsync();
        }


        public async Task<Client?> GetById(Guid id)
        {
            return await dbContext.Clients.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Client> CreateAsync(Client client)
        {
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
            return client;
        }
        public async  Task<Client?> UpdateByIdAsync(Guid id, Client client)
        {
            var exitingClient = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingClient == null)
            {
                return null;
            }
            exitingClient.Phone = client.Phone;
            exitingClient.CountryCode = client.CountryCode;
            exitingClient.Name = client.Name;
            exitingClient.CityId = client.CityId;
            exitingClient.Type = client.Type;
            exitingClient.UpdatedAt = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return exitingClient;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var exitingClient = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if ( exitingClient == null)
            {
                return false;
            }

            dbContext.Clients.Remove(exitingClient);

            await dbContext.SaveChangesAsync();

            return true;
        }

    }
}
