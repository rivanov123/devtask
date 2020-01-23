using System.Threading.Tasks;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainLayer.MatchStates;

namespace TeamRankings.DomainLayer
{
    public class MatchStateObserver : IStateObserver<MatchStateCommand>
    {
        private readonly ITeamsManager _manager;

        private readonly IRankComputeStrategy _rankProcessor;

        public MatchStateObserver(ITeamsManager manager, IRankComputeStrategy rankProcessor)
        {
            _manager = manager;
            _rankProcessor = rankProcessor;
        }

        public async Task Update(MatchStateCommand stateCommand)
        {
            stateCommand.Execute();
            var teams = await _manager.GetTeamsAsync();

            _rankProcessor.ComputeRanks(teams);
        }
    }
}
