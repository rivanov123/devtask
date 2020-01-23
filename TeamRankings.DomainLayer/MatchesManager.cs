using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer
{
    public class MatchesManager : IMatchesManager
    {
        private readonly TeamRankingsDbContext _context;

        public MatchesManager(TeamRankingsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetMatchesAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            var a = await _context.Matches.FindAsync(id);
            return a;
        }

        public Task CreateMatchAsync(Match match)
        {
            _context.Matches.Add(match);
            return Task.CompletedTask;
        }

        public Task DeleteMatchAsync(Match match)
        {
            foreach (var matchTeamScore in match.TeamScores.ToList())
            {
                _context.TeamMatchScores.Remove(matchTeamScore);
            }

            _context.Matches.Remove(match);
            return Task.CompletedTask;
        }

        public async Task UpdateMatchAsync(Match match)
        {
            var oldTeamScores = await _context.TeamMatchScores.Where(x => x.MatchId == match.Id).ToListAsync();
            _context.TeamMatchScores.RemoveRange(oldTeamScores);
            _context.Matches.AddOrUpdate(match);
        }
    }
}
