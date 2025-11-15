using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class VenderRepositoryExtention 
    {
        public static IServiceCollection AddVenderRepository(this IServiceCollection services)
        {
            services.AddScoped<IVenderRepository, VenderRepository>();
            return services;
        }
    }
}
