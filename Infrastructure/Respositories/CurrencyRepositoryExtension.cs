using Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public static class CurrencyRepositoryExtension
    {
        public static IServiceCollection AddCurrencyRepository(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyRepository, CurrencyRespoitory>();

            return services;
        }
    }
}
