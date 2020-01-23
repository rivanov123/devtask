using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.ViewModel;

namespace TeamRankings.Adapters.Mvc.Abstractions
{
    public interface ITeamsManagerAdapter
    {
        Task<IEnumerable<TeamViewModel>> GetTeamsAsync();

        Task<TeamViewModel> GetTeamAsync(int id);

        Task DeleteTeamAsync(int id);

        Task UpdateAsync(TeamViewModel team);

        Task CreateTeamAsync(TeamViewModel team);
    }
}
