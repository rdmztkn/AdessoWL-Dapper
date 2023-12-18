using AdessoWL.Domain.Entities;
using System.Collections.Generic;

namespace AdessoWL.Application.Interfaces.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        public List<Country> GetCountryByName(string Name);

        public Country GetCountryWithTeamsById(int countryId);
    }
}
