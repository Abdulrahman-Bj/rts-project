using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class APIServicesDbContext : DbContext
    {

        public APIServicesDbContext(DbContextOptions<APIServicesDbContext>  options) : base (options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Vender> Venders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .Property(r => r.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Reservation>().Property(r => r.Status).HasConversion<string>();
            modelBuilder.Entity<Room>().Property(r => r.DiscountType).HasConversion<string>();
        }

    }
}
