using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class CityRepositoryExtention
    {
        public static IServiceCollection AddCityRepository(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            return services;
        }
    }
}
