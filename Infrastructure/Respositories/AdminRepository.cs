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
    internal class AdminRepository : IAdminRepository
    {
        private readonly APIServicesDbContext dbContext;

        public AdminRepository(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Admin> CreateAsync(Admin admin)
        {
            await dbContext.Admins.AddAsync(admin);
            await dbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var existingAdmin = dbContext.Admins.FirstOrDefault(x => x.Id == id);
            if (existingAdmin == null)
            {
                return false;
            }

            dbContext.Admins.Remove(existingAdmin);
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async  Task<IEnumerable<Admin>> GetAllAsync(IDictionary<string, string> query)
        {
            var baseQuery = dbContext.Admins.AsQueryable();

            var queryParams = query.ToDictionary();

            var apiFeatures = new ApiFeatures<Admin>(baseQuery, queryParams).Filter()
                                .Sort()
                                .Paginate()
                                .Build();

            return await apiFeatures.ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(Guid id)
        {
            return await dbContext.Admins.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Admin?> UpdateByIdAsync(Guid id, Admin admin)
        {
            var existingAdmin = dbContext.Admins.FirstOrDefault(x => x.Id == id);

            if (existingAdmin == null)
            {
                return null;
            }

            existingAdmin.Name = admin.Name;
            existingAdmin.Username = admin.Username;
            existingAdmin.UpdatedAt = admin.UpdatedAt;
            await dbContext.SaveChangesAsync();

            return existingAdmin;
        }
    }
}
