using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainLayer.MatchStates;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.Decorators
{
    public class ObservableMatchesManagerDecorator : IMatchesManager
    {
        private readonly IMatchesManager _inner;

        private readonly IStateObserver<MatchStateCommand> _observer;

        private readonly TeamRankingsDbContext _context;

        public ObservableMatchesManagerDecorator(IMatchesManager inner, IStateObserver<MatchStateCommand> observer, TeamRankingsDbContext context)
        {
            _inner = inner;
            _observer = observer;
            _context = context;
        }

        public Task<IEnumerable<Match>> GetMatchesAsync()
        {
            return _inner.GetMatchesAsync();
        }

        public Task<Match> GetMatchByIdAsync(int id)
        {
            return _inner.GetMatchByIdAsync(id);
        }

        public async Task CreateMatchAsync(Match match)
        {
            await _inner.CreateMatchAsync(match);
            await _observer.Update(new MatchCreateStateCommand(match));
        }

        public async Task DeleteMatchAsync(Match match)
        {
            await _observer.Update(new MatchDeleteStateCommand(match));
            await _inner.DeleteMatchAsync(match);
        }

        public async Task UpdateMatchAsync(Match match)
        {
            await _observer.Update(new MatchUpdateStateCommand(match, await _context.TeamMatchScores.Where(x => x.MatchId == match.Id).ToListAsync()));
            await _inner.UpdateMatchAsync(match);
        }
    }
}
