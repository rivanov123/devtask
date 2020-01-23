using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.Decorators
{
    public class TeamsManagerDbSynchronizationDecorator : ITeamsManager
    {
        private readonly TeamRankingsDbContext _context;

        private readonly ITeamsManager _inner;

        public TeamsManagerDbSynchronizationDecorator(TeamRankingsDbContext context, ITeamsManager inner)
        {
            _context = context;
            _inner = inner;
        }

        public Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return _inner.GetTeamsAsync();
        }

        public Task<Team> GetByIdAsync(int id)
        {
            return _inner.GetByIdAsync(id);
        }

        public async Task CreateTeamAsync(Team team)
        {
            await _inner.CreateTeamAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeamAsync(Team team)
        {
            await _inner.DeleteTeamAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Team team)
        {
            await _inner.UpdateAsync(team);
            await _context.SaveChangesAsync();
        }
    }
}
