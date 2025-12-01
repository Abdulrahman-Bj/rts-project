using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class ApiAuthDbContextFactory : IDesignTimeDbContextFactory<ApiAuthDbContext>
    {
        public ApiAuthDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiAuthDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=APIAuthReservationServices;User Id=sa;Password=AbdulrahmanBj321;TrustServerCertificate=True;",
                sqlOptions => sqlOptions
                    .MigrationsAssembly("Infrastructure")
                    .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
            );

            return new ApiAuthDbContext(optionsBuilder.Options);
        }
    }
}