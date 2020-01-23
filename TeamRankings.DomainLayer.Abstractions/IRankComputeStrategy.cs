using System.Collections.Generic;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.Abstractions
{
    public interface IRankComputeStrategy
    {
        void ComputeRanks(IEnumerable<Team> teams);
    }
}
