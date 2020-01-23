using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TeamRankings.Adapters.Mvc.Abstractions;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainModel;
using TeamRankings.ViewModel;

namespace TeamRankings.Adapters.Mvc
{
    public class MatchesManagerAdapter : IMatchesManagerAdapter
    {
        private readonly IMatchesManager _matchesManager;

        private readonly IObjectMapper _objectMapper;

        private readonly TeamRankingsDbContext _context;

        public MatchesManagerAdapter(IMatchesManager matchesManager, IObjectMapper objectMapper, TeamRankingsDbContext context)
        {
            _matchesManager = matchesManager;
            _objectMapper = objectMapper;
            _context = context;
        }

        public async Task<IEnumerable<MatchViewModel>> GetMatches()
        {
            return _objectMapper.Map<IEnumerable<Match>, IEnumerable<MatchViewModel>>(await _matchesManager.GetMatchesAsync());
        }

        public async Task<MatchViewModel> GetMatchByIdAsync(int id)
        {
            return _objectMapper.Map<Match, MatchViewModel>(await _matchesManager.GetMatchByIdAsync(id));
        }

        public async Task CreateMatch(MatchViewModel matchViewModel)
        {
            

            await _matchesManager.CreateMatchAsync(await ConvertMatchViewModel(matchViewModel));
        }

        public async Task UpdateMatch(MatchViewModel matchViewModel)
        {
            await _matchesManager.UpdateMatchAsync(await ConvertMatchViewModelToExisting(matchViewModel));
        }

        public async Task DeleteMatch(int id)
        {
            var m = await _context.Matches.FindAsync(id);
            await _matchesManager.DeleteMatchAsync(m);
        }

        private async Task<Match> ConvertMatchViewModel(MatchViewModel matchViewModel)
        {
            var teamA = await _context.Teams.FirstAsync(t => t.Name == matchViewModel.TeamA);
            var teamB = await _context.Teams.FirstAsync(t => t.Name == matchViewModel.TeamB);
            return new Match
            {
                Id = matchViewModel.Id,
                MatchDateTime = matchViewModel.MatchDateTime,
                TeamScores = new List<TeamMatchScore>
                {
                    new TeamMatchScore
                    {
                        Score = matchViewModel.TeamAScore,
                        Team = teamA,
                        TeamId = teamA.Id
                    },
                    new TeamMatchScore
                    {
                        Score = matchViewModel.TeamBScore,
                        Team = teamB,
                        TeamId = teamB.Id
                    }
                }
            };
        }

        private async Task<Match> ConvertMatchViewModelToExisting(MatchViewModel matchViewModel)
        {
            var existing = await _matchesManager.GetMatchByIdAsync(matchViewModel.Id);
            existing.MatchDateTime = matchViewModel.MatchDateTime;
            var teamA = await _context.Teams.FirstAsync(x => x.Name == matchViewModel.TeamA);
            var teamB = await _context.Teams.FirstAsync(x => x.Name == matchViewModel.TeamB);
            existing.TeamScores.Clear();
            existing.TeamScores = new List<TeamMatchScore>
            {
                new TeamMatchScore
                {
                    Score = matchViewModel.TeamAScore,
                    Team = teamA,
                    TeamId = teamA.Id
                },
                new TeamMatchScore
                {
                    Score = matchViewModel.TeamBScore,
                    Team = teamB,
                    TeamId = teamB.Id
                }
            };

            return existing;
        }
    }
}
