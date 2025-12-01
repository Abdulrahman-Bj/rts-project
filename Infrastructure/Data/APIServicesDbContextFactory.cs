using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Infrastructure.Data
{
    public class APIServicesDbContextFactory : IDesignTimeDbContextFactory<APIServicesDbContext>
    {
        public APIServicesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<APIServicesDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=APIReservationServices;User Id=sa;Password=AbdulrahmanBj321;TrustServerCertificate=True;",
                sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure")
                    .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
            );
            
            var optionsBuilderAuth = new DbContextOptionsBuilder<ApiAuthDbContext>();
            optionsBuilderAuth.UseSqlServer(
                    "Server=localhost;Database=APIAuthReservationServices;User Id=sa;Password=AbdulrahmanBj321;TrustServerCertificate=True;",
                    sqlOptions => sqlOptions
                        .MigrationsAssembly("Infrastructure")
                        .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                    );    
            return new APIServicesDbContext(optionsBuilder.Options);
        }
    }
}