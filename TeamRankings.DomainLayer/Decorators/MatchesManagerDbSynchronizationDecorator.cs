using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainLayer.MatchStates;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.Decorators
{
    public class MatchesManagerDbSynchronizationDecorator : IMatchesManager
    {
        private readonly TeamRankingsDbContext _context;

        private readonly IMatchesManager _inner;

        public MatchesManagerDbSynchronizationDecorator(TeamRankingsDbContext context, IMatchesManager inner)
        {
            _context = context;
            _inner = inner;
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
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatchAsync(Match match)
        {
            await _inner.DeleteMatchAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMatchAsync(Match match)
        {
            await _inner.UpdateMatchAsync(match);
            await _context.SaveChangesAsync();
        }
    }
}
