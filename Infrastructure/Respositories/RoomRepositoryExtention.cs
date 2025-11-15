using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class RoomRepositoryExtention
    {

        public static IServiceCollection AddRoomRepository(this IServiceCollection services)
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            return services;
        }
    }
}
