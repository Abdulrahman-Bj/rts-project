using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApiAuthDbContext : IdentityDbContext
    {
        public ApiAuthDbContext(DbContextOptions<ApiAuthDbContext> options): base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = Guid.NewGuid().ToString();
            var writerRoleId = Guid.NewGuid().ToString();

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    ConcurrencyStamp = readerRoleId,
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    ConcurrencyStamp = writerRoleId,
                    NormalizedName = "Writer".ToUpper()
                }
            };
            
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}