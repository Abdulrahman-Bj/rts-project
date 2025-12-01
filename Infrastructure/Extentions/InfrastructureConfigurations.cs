using Application.Services;
using Infrastructure.Data;
using Infrastructure.Respositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
                options.UseSqlServer(
                    "Server=localhost;Database=APIReservationServices;User Id=sa;Password=AbdulrahmanBj321;TrustServerCertificate=True;",
                    sqlOptions => sqlOptions
                        .MigrationsAssembly("Infrastructure")
                        .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );    
            });
            services.AddDbContext<ApiAuthDbContext>(options =>
            {
                options.UseSqlServer(
                    "Server=localhost;Database=APIAuthReservationServices;User Id=sa;Password=AbdulrahmanBj321;TrustServerCertificate=True;",
                    sqlOptions => sqlOptions
                        .MigrationsAssembly("Infrastructure")
                        .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );    
            });
            services.AddClientRepository();
            services.AddCityRepository();
            services.AddAdminRepository();
            services.AddHotelRepository();
            services.AddVenderRepository();
            services.AddRoomRepository();
            services.AddServicesRepository();
            services.AddReservationRepository();
            services.AddCurrencyRepository();
            services.AddScoped<IFileServices, FileServices>();

            return services;

        }
    }
}


