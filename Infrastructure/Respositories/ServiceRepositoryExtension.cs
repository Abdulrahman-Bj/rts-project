using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static  class ServiceRepositoryExtension
    {
        public static IServiceCollection AddServicesRepository( this IServiceCollection services)
        {
            services.AddScoped<IServiceRepository, ServicesRespository>();
            return services;    
        }

    }
}
