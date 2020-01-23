using System.Threading.Tasks;

namespace TeamRankings.DomainLayer.Abstractions
{
    public interface IStateObserver<in TState>
    {
        Task Update(TState state);
    }
}
