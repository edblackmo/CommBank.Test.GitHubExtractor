using CommBank.Test.Contracts.Request;
using CommBank.Test.Contracts.Response;
using CommBank.Test.CQRS.Queries;
using CommBank.Test.GitHubExtractor.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.Api.Controllers
{    
    public class GitHubExtractorController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GitHubExtractorController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("get-user-repositories/{userName}/{token}/{Uri}")]   
        public async Task<IActionResult> GetAllUserRepositories(string userName, string token, string uri)
        {
            
            var results = await _queryDispatcher.DispatchAsync<GetUsersRepositories, IEnumerable<UserGitRepositories>>(
                x => x.SetParams(userName, token, WebUtility.HtmlDecode(uri)));

            return PartialView("_RepoGrid", results);
        }

        [HttpPost]
        [Route("get-user-commits/{userName}/{token}")]
        public async Task<IActionResult> GetUserCommits(string userName, string token, [FromBody] AdditionalParameters additionalParameters, [FromQuery] int limit)
        {
            var results = await _queryDispatcher.DispatchAsync<GetUserCommits, IEnumerable<UserCommits>>(
                x => x.SetParams(userName, token, additionalParameters, limit));

            //not found
            return PartialView("_RepoGrid", results);
        }
    }
}
