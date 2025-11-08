using Application.Converters;
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
            services.AddUserService();
            services.AddCityService();
            return services;
        }
    }
}
