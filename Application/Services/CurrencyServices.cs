using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IMapper mapper;

        public CurrencyServices(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
        }
        public async Task<CurrencyDto> CreateAsync(AddCurrencyRequestDto dto)
        {
            var currencyDomain = mapper.Map<Currency>(dto);
            var currnecy = await currencyRepository.CreateAsync(currencyDomain);

            return mapper.Map<CurrencyDto>(currnecy);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await currencyRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllAsync(IDictionary<string, string> query)
        {
            var currencies = await currencyRepository.GetAllAsync(query);

            return mapper.Map<IEnumerable<CurrencyDto>>(currencies);
        }

        public async Task<CurrencyDto?> GetByIdAsync(Guid id)
        {
            var currency = await currencyRepository.GetByIdAsync(id);

            if (currency == null)
            {
                return null;
            }

            return mapper.Map<CurrencyDto>(currency);
        }

        public async Task<CurrencyDto?> UpdateByIdAsync(Guid id, UpdateCurrencyRequestDto dto)
        {
            var currencyDomain = mapper.Map<Currency>(dto);
            var existingCurrency = await currencyRepository.UpdateByIdAsync(id, currencyDomain);
            if (existingCurrency == null)
            {
                return null;
            }

            return mapper.Map<CurrencyDto>(existingCurrency);
        }
    }
}
