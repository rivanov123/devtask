using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TeamRankings.Adapters.Mvc.Hubs
{
    public class TeamsHub : Hub
    {
        public async Task BroadcastTeamRankChanges()
        {
            await Clients.All.SendAsync("UpdateTeams");
        }
    }
}
