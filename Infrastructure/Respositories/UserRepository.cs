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
    internal class UserRepository : IUserRepository
    {
        private readonly APIServicesDbContext dbContext;

        public UserRepository( APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }


        public async Task<User?> GetById(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
        public async  Task<User?> UpdateByIdAsync(Guid id, User user)
        {
            var exitingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingUser == null)
            {
                return null;
            }

            exitingUser.Username = user.Username;
            exitingUser.Password = user.Password;
            exitingUser.Name = user.Name;
            exitingUser.CityId = user.CityId;
            exitingUser.Type = user.Type;
            exitingUser.UpdateAt = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return exitingUser;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var exitingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if ( exitingUser == null)
            {
                return false;
            }

            dbContext.Users.Remove(exitingUser);

            await dbContext.SaveChangesAsync();

            return true;
        }




    }
}
