using AdessoWL.Application.Interfaces.DapperContext;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Entities;
using Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace AdessoWL.Persistence.Repositories
{
    public class DapperCountryRepository : DapperGenericRepository<Country>, ICountryRepository
    {
        public DapperCountryRepository(IDapperContext dapperContext) : base(dapperContext, "Countries")
        {

        }

        public List<Country> GetCountryByName(string Name)
        {
            var query = $"select * from Countries where Name = {"'" + Name + "'"} ";

            using (var conn = dapperContext.GetConnection())
            {
                conn.Open();
                return (List<Country>)conn.Query<Country>(query);
            }
        }

        public Country GetCountryWithTeamsById(int countryId)
        {
            using (var conn = dapperContext.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT c.*, t.*
                FROM Countries c
                LEFT JOIN Teams t ON c.Id = t.CountryId
                WHERE c.Id = @CountryId";

                var countryDictionary = new Dictionary<int, Country>();

                var result = conn.Query<Country, Team, Country>(
                    query,
                    (country, team) =>
                    {
                        if (!countryDictionary.TryGetValue(country.Id, out var countryEntry))
                        {
                            countryEntry = country;
                            countryEntry.Teams = new List<Team>();
                            countryDictionary.Add(countryEntry.Id, countryEntry);
                        }

                        if (team != null)
                        {
                            countryEntry.Teams.Add(team);
                        }

                        return countryEntry;
                    },
                    new { CountryId = countryId },
                    splitOn: "Id"
                ).Distinct().ToList();

                return result.FirstOrDefault();
            }
        }
    }
}
