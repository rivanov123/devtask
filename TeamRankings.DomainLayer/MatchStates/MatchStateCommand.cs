using System.Collections.Generic;
using TeamRankings.DomainModel;

namespace TeamRankings.DomainLayer.MatchStates
{
    public abstract class MatchStateCommand
    {
        public abstract void Execute();
    }
}
