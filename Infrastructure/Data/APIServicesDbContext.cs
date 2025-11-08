using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class APIServicesDbContext : DbContext
    {

        public APIServicesDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
