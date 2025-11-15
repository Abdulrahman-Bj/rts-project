using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class AdminRepositoryExtention
    {

        public static IServiceCollection AddAdminRepository(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            return services;
        }
    }
}
