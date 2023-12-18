using Dapper;
using AdessoWL.Application.Interfaces.DapperContext;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Entities;
using System.Collections.Generic;

namespace AdessoWL.Persistence.Repositories
{
    public class DapperTeamRepository : DapperGenericRepository<Team>, ITeamRepository
    {
        public DapperTeamRepository(IDapperContext dapperContext) : base(dapperContext, "Teams")
        {
        }

        public List<Team> GetTeamsByCountryId(int Id)
        {
            var query = $"select * from Teams where CountryId = {Id} ";

            using (var conn = dapperContext.GetConnection())
            {
                conn.Open();
                return (List<Team>)conn.Query<Team>(query);
            }
        }

        public List<Team> GetTeamByName(string Name)
        {
            var query = $"select * from Teams where Name = {"'" + Name + "'"} ";

            using (var conn = dapperContext.GetConnection())
            {
                conn.Open();
                return (List<Team>)conn.Query<Team>(query);
            }
        }
    }
}
