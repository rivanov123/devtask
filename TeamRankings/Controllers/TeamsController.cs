using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamRankings.Adapters.Mvc.Abstractions;
using TeamRankings.ViewModel;

namespace TeamRankings.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamsManagerAdapter _teamsManagerAdapter;

        public TeamsController(ITeamsManagerAdapter teamsManagerAdapter)
        {
            _teamsManagerAdapter = teamsManagerAdapter;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _teamsManagerAdapter.GetTeamsAsync());
        }

        public async Task<IEnumerable<string>> GetTeams()
        {
            var teams = await _teamsManagerAdapter.GetTeamsAsync();
            return teams.Select(t => t.Name);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _teamsManagerAdapter.GetTeamAsync(id));
        }

        public IActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create([Bind("Id,Name,Rank,Score")] TeamViewModel team)
        {
            await _teamsManagerAdapter.CreateTeamAsync(team);
        }

        public async Task<IActionResult> UpdateDataTable()
        {
            return PartialView("TeamTablePartial", await _teamsManagerAdapter.GetTeamsAsync());
        }

        public async Task<IActionResult> Update(int id)
        {
            return PartialView("Edit", await _teamsManagerAdapter.GetTeamAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Update([Bind("Id,Name,Rank,Score")] TeamViewModel team)
        {
            await _teamsManagerAdapter.UpdateAsync(team);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return PartialView("Delete", await _teamsManagerAdapter.GetTeamAsync(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task DeleteConfirmed(int id)
        {
            await _teamsManagerAdapter.DeleteTeamAsync(id);
        }
    }
}
