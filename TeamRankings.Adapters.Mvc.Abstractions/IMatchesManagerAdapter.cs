using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.ViewModel;

namespace TeamRankings.Adapters.Mvc.Abstractions
{
    public interface IMatchesManagerAdapter
    {
        Task<IEnumerable<MatchViewModel>> GetMatches();

        Task<MatchViewModel> GetMatchByIdAsync(int id);

        Task CreateMatch(MatchViewModel match);

        Task UpdateMatch(MatchViewModel match);

        Task DeleteMatch(int id);
    }
}
