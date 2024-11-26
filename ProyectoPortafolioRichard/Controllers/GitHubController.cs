using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPortafolioRichard.Services;
using System.Threading.Tasks;

namespace ProyectoPortafolioRichard.Controllers
{
    public class GitHubController : Controller
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<IActionResult> Index()
        {
            var repos = await _gitHubService.GetReposAsync("richardvaldes-developer");
            return View(repos);
        }

    }

}

