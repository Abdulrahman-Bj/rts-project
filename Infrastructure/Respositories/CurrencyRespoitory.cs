using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class CurrencyRespoitory : ICurrencyRepository
    {
        private readonly APIServicesDbContext dbContext;

        public CurrencyRespoitory(APIServicesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Currency> CreateAsync(Currency currency)
        {
            await dbContext.Currencies.AddAsync(currency);
            await dbContext.SaveChangesAsync();

            return currency;

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var existinCurrency = await dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == id);

            if (existinCurrency == null)
            {
                return false;
            }

            dbContext.Currencies.Remove(existinCurrency);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Currency>> GetAllAsync(IDictionary<string, string> query)
        {
            var currencies = dbContext.Currencies.AsQueryable();
            var queryParams = query.ToDictionary();
            var apiFeature = new ApiFeatures<Currency>(currencies, queryParams).Filter().Sort().Paginate().Build();

            return await apiFeature.ToListAsync();
        }

        public async Task<Currency?> GetByIdAsync(Guid id)
        {
            var existingCurrency = await dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == id);

            if (existingCurrency == null)
            {
                return null;
            }

            return existingCurrency;
        }

        public async Task<Currency?> UpdateByIdAsync(Guid id, Currency currency)
        {
            var existingCurrency = await dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == id);

            if (existingCurrency == null)
            {
                return null;
            }

            existingCurrency.Name = currency.Name;
            existingCurrency.Code = currency.Code;
            existingCurrency.ExchangeRateToDefault = currency.ExchangeRateToDefault;
            existingCurrency.IsDefault = currency.IsDefault;
            existingCurrency.UpdatedAt = currency.UpdatedAt;

            await dbContext.SaveChangesAsync();

            return existingCurrency;
        }
    }
}
