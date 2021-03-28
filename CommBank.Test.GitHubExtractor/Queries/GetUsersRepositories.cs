using AutoMapper;
using CommBank.Test.Contracts.Request;
using CommBank.Test.Contracts.Response;
using CommBank.Test.CQRS.Queries;
using CommBank.Test.GitHubExtractor.DataAccessLayer;
using CommBank.Test.GitHubExtractor.GitHub.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.Queries
{
    public class GetUsersRepositories : IQuery<IEnumerable<UserGitRepository>>
    {
        private readonly IWebDataAccessService _dataAccessService;
        private readonly IMapper _mapper;
        private string _userName;
        private string _token;
        private string _uri;

        public GetUsersRepositories(
            IWebDataAccessService dataAccessService, 
            IMapper mapper
            )
        {
            _dataAccessService = dataAccessService;
            _mapper = mapper;
        }

        public void SetParams(string userName, string token, AdditionalParameters additionalParameters)
        {
            _userName = userName;
            _token = token;
            _uri = additionalParameters.Uri;
        }

        public async Task<IEnumerable<UserGitRepository>> Dispatch()
        {         
            var userRepositories = await _dataAccessService.GetAsync<IEnumerable<GitHubRepositories>>($"{_uri}/users/{_userName}/repos", _token);         
            return _mapper.Map<IEnumerable<UserGitRepository>>(userRepositories);
        }
    }
}
