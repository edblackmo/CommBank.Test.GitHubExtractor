﻿using CommBank.Test.Contracts.Request;
using CommBank.Test.Contracts.Response;
using CommBank.Test.CQRS.Queries;
using CommBank.Test.GitHubExtractor.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CommBank.Test.GitHubExtractor.Api.Controllers
{
    [Route("api/git-hub")]
    public class GitHubExtractorController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;

        //TODO: Implement automated testing via XUnit/Bddfy/Shouldly or unit testing using MOQ
        public GitHubExtractorController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        [Route("get-user-repositories/{userName}/{token}")]
        [ResponseType(typeof(IEnumerable<UserGitRepository>))]
        public async Task<IActionResult> GetAllUserRepositories(string userName, string token, [FromBody] AdditionalParameters additionalParameters)
        {
            var results = await _queryDispatcher.DispatchAsync<GetUsersRepositories, IEnumerable<UserGitRepository>>(
                x => x.SetParams(userName, token, additionalParameters));

            //not found

            return Ok(results);
        }

        [HttpPost]
        [Route("get-user-commits/{userName}/{token}")]
        [ResponseType(typeof(IEnumerable<UserCommits>))]
        public async Task<IActionResult> GetUserCommits(string userName, string token, [FromBody] AdditionalParameters additionalParameters, [FromQuery] int limit)
        {
            var results = await _queryDispatcher.DispatchAsync<GetUserCommits, IEnumerable<UserCommits>>(
                x => x.SetParams(userName, token, additionalParameters, limit));

            //not found

            return Ok(results);
        }
    }
}
