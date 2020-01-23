using System.Collections.Generic;
using System.Linq;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.MatchStates
{
    public class MatchUpdateStateCommand : MatchStateCommand
    {
        private readonly Match _match;

        private readonly IEnumerable<TeamMatchScore> _originalScores;

        public MatchUpdateStateCommand(Match match, IEnumerable<TeamMatchScore> originalScores)
        {
            _match = match;
            _originalScores = originalScores;
        }

        public override void Execute()
        {
            if (HasScoreOrTeamChanges())
            {
                var scoreA = _originalScores.ElementAt(0);
                var scoreB = _originalScores.ElementAt(1);
                var oldWinner = GetOldWinner(scoreA, scoreB);

                if (oldWinner == null)
                {
                    scoreA.Team.Score -= 1;
                    scoreB.Team.Score -= 1;
                }
                else
                {
                    oldWinner.Score -= 3;
                }

                var newScoreA = _match.TeamScores.ElementAt(0);
                var newScoreB = _match.TeamScores.ElementAt(1);

                if (newScoreB.Score > newScoreA.Score)
                {
                    newScoreB.Team.Score += 3;
                }
                else if (newScoreB.Score == newScoreA.Score)
                {
                    newScoreB.Team.Score += 1;
                    newScoreA.Team.Score += 1;
                }
                else
                {
                    newScoreA.Team.Score += 3;
                }
            }
        }

        private static Team GetOldWinner(TeamMatchScore scoreA, TeamMatchScore scoreB)
        {
            
            if (scoreA.Score > scoreB.Score)
            {
                return scoreA.Team;
            }

            return scoreA.Score < scoreB.Score ? scoreB.Team : null;
        }

        private bool HasScoreOrTeamChanges()
        {
            var newScores = _match.TeamScores;
            return (from newScore in newScores
                    let original = _originalScores.FirstOrDefault(x => x.Team.Id == newScore.TeamId)
                    where original == null || original.Score != newScore.Score
                    select newScore)
                .Any();
        }
    }
}
