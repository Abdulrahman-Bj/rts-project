using Infrastructure.Data;
using Infrastructure.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
    public static class InfrastructureConfigurations 
    {

        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services)
        {
            services.AddDbContext<APIServicesDbContext>(options =>
            {
                options.UseSqlServer("Server=ABDULRAHMAN\\SQLEXPRESS;Database=APICustomerServices;User Id=sa;Password=test1234;TrustServerCertificate=True;Trusted_Connection=true",sqlOptions => sqlOptions.MigrationsAssembly("CustomerServicesAPI")); ;
        });
            services.AddUserRepository();
            services.AddCityRepository();

            return services;

        }
    }
}
