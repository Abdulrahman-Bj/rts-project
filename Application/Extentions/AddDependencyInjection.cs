using Application.Converters;
using Application.Mappings;
using Application.Services;
using Infrastructure.Extentions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{
    public static class AddDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add application services here
            services.AddInfrastructureServices();
            services.AddScoped<IClientService, ClientServices>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IHotelServices, HotelServices>();
            services.AddScoped<IVenderServices, VenderServices>();
            services.AddScoped<IRoomServices, RoomServices>();
            services.AddCityService();
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());
            return services;
        }
    }
}
