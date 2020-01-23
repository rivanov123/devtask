using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.Abstractions
{
    public interface ITeamsManager
    {
        Task<IEnumerable<Team>> GetTeamsAsync();

        Task<Team> GetByIdAsync(int id);

        Task CreateTeamAsync(Team team);

        Task DeleteTeamAsync(Team team);

        Task UpdateAsync(Team team);
    }
}
