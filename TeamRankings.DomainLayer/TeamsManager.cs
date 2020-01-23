using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer
{
    public class TeamsManager : ITeamsManager
    {
        private readonly TeamRankingsDbContext _context;

        private readonly IRankComputeStrategy _rankProcessor;

        public TeamsManager(TeamRankingsDbContext context, IRankComputeStrategy rankProcessor)
        {
            _context = context;
            _rankProcessor = rankProcessor;
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await _context.Teams.OrderBy(t => t.Rank).ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task CreateTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            var allTeams = await _context.Teams.ToListAsync();
            allTeams.Add(team);
            _rankProcessor.ComputeRanks(allTeams);
        }

        public async Task DeleteTeamAsync(Team team)
        {
            _context.Teams.Remove(team);
            var allTeams = await _context.Teams.ToListAsync();
            allTeams.Remove(team);
            _rankProcessor.ComputeRanks(allTeams);
        }

        public async Task UpdateAsync(Team team)
        {
            _context.Teams.AddOrUpdate(team);
            _rankProcessor.ComputeRanks(await _context.Teams.ToListAsync());
        }
    }
}
