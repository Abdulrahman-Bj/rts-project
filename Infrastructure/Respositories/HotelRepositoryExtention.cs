using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class HotelRepositoryExtention 
    {

        public static IServiceCollection AddHotelRepository(this IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
            return services;
        }
    }
}
