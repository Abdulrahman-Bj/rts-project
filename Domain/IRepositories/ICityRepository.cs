using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();

        Task<City?> GetById(Guid id);

        Task<City?> UpdateByIdAsync(Guid id, City city);

        Task<City> CreateAsync(City city);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
