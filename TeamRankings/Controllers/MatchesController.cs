using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamRankings.Adapters.Mvc.Abstractions;
using TeamRankings.Adapters.Mvc.Hubs;
using TeamRankings.ViewModel;

namespace TeamRankings.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatchesManagerAdapter _matchesManagerAdapter;

        private readonly TeamsHub _teamHub;

        public MatchesController(IMatchesManagerAdapter matchesManagerAdapter, TeamsHub teamHub)
        {
            _matchesManagerAdapter = matchesManagerAdapter;
            _teamHub = teamHub;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _matchesManagerAdapter.GetMatches());
        }

        public IActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create(MatchViewModel match)
        {
            await _matchesManagerAdapter.CreateMatch(match);
            await _teamHub.BroadcastTeamRankChanges();
        }

        public async Task<IActionResult> UpdateDataTable()
        {
            return PartialView("MatchesTablePartial", await _matchesManagerAdapter.GetMatches());
        }

        public async Task<IActionResult> Update(int id)
        {
            return PartialView("Edit", await _matchesManagerAdapter.GetMatchByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Update(MatchViewModel match)
        {
            await _matchesManagerAdapter.UpdateMatch(match);
            await _teamHub.BroadcastTeamRankChanges();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return PartialView("Delete", await _matchesManagerAdapter.GetMatchByIdAsync(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task ConfirmDelete(int id)
        {
            await _matchesManagerAdapter.DeleteMatch(id);
            await _teamHub.BroadcastTeamRankChanges();
        }
    }
}