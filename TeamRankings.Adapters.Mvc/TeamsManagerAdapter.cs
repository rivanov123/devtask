using System.Collections.Generic;
using System.Threading.Tasks;
using TeamRankings.Adapters.Mvc.Abstractions;
using TeamRankings.DataAccess;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainModel;
using TeamRankings.ViewModel;

namespace TeamRankings.Adapters.Mvc
{
    public class TeamsManagerAdapter : ITeamsManagerAdapter
    {
        private readonly ITeamsManager _teamsManager;

        private readonly IObjectMapper _objMapper;

        private readonly TeamRankingsDbContext _dbContext;

        public TeamsManagerAdapter(ITeamsManager teamsManager, IObjectMapper objMapper, TeamRankingsDbContext dbContext)
        {
            _teamsManager = teamsManager;
            _objMapper = objMapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamViewModel>> GetTeamsAsync()
        {
            return _objMapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(await _teamsManager.GetTeamsAsync());
        }

        public async Task<TeamViewModel> GetTeamAsync(int id)
        {
            return _objMapper.Map<Team, TeamViewModel>(await _teamsManager.GetByIdAsync(id));
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamsManager.DeleteTeamAsync(await _dbContext.Teams.FindAsync(id));
        }

        public async Task UpdateAsync(TeamViewModel team)
        {
            await _teamsManager.UpdateAsync(_objMapper.Map<TeamViewModel, Team>(team));
        }

        public async Task CreateTeamAsync(TeamViewModel team)
        {
            await _teamsManager.CreateTeamAsync(_objMapper.Map<TeamViewModel, Team>(team));
        }
    }
}
