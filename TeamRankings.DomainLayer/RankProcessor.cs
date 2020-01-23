using System.Collections.Generic;
using System.Linq;
using TeamRankings.DomainLayer.Abstractions;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer
{
    public class DefaultRankComputeStrategy : IRankComputeStrategy
    {
        public void ComputeRanks(IEnumerable<Team> teams)
        {
            var teamsByScore = teams
                .GroupBy(x => x.Score)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList())
                .OrderByDescending(x => x.Key)
                .ToList();

            for (var i = 0; i < teamsByScore.Count; i++)
            {
                foreach (var t in teamsByScore[i].Value)
                {
                    t.Rank = i + 1;
                }
            }
        }
    }
}
