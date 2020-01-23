using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.Abstractions
{
    public interface IMatchesManager
    {
        Task<IEnumerable<Match>> GetMatchesAsync();

        Task<Match> GetMatchByIdAsync(int id);

        Task CreateMatchAsync(Match match);

        Task DeleteMatchAsync(Match match);

        Task UpdateMatchAsync(Match match);
    }
}
