using AdessoWL.Domain.Entities;
using System.Collections.Generic;

namespace AdessoWL.Application.Interfaces.Repositories
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        public List<Team> GetTeamsByCountryId(int Id);

        public List<Team> GetTeamByName(string Name);
    }
}
