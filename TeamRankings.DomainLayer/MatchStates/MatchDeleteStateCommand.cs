using System.Linq;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.MatchStates
{
    public class MatchDeleteStateCommand : MatchStateCommand
    {
        private readonly Match _match;

        public MatchDeleteStateCommand(Match match)
        {
            _match = match;
        }

        public override void Execute()
        {
            var teamAScore = _match.TeamScores.ElementAt(0);
            var teamBScore = _match.TeamScores.ElementAt(1);
            var teamA = teamAScore.Team;
            var teamB = teamBScore.Team;

            if (teamAScore.Score > teamBScore.Score)
            {
                teamA.Score -= 3;
            }
            else if (teamAScore.Score == teamBScore.Score)
            {
                teamA.Score -= 1;
                teamB.Score -= 1;
            }
            else if (teamAScore.Score < teamBScore.Score)
            {
                teamB.Score -= 3;
            }
        }
    }
}
