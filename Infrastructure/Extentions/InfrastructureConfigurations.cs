using Application.Services;
using Infrastructure.Data;
using Infrastructure.Respositories;
using Infrastructure.Services;
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
                options.UseSqlServer("Server=ABDULRAHMAN\\SQLEXPRESS01;Database=APIReservationServices;TrustServerCertificate=True;Trusted_Connection=true", sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure")); ;
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


