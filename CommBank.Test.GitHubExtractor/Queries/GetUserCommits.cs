using AutoMapper;
using CommBank.Test.Contracts.Request;
using CommBank.Test.Contracts.Response;
using CommBank.Test.CQRS.Queries;
using CommBank.Test.GitHubExtractor.DataAccessLayer;
using CommBank.Test.GitHubExtractor.GitHub.Contracts.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.Queries
{
    public class GetUserCommits : IQuery<IEnumerable<UserCommits>>
    {
        private readonly IWebDataAccessService _dataAccessService;
        private readonly IMapper _mapper;
        private string _userName;
        private string _token;
        private int _limit;
        private AdditionalParameters _additionalParameters;

        public GetUserCommits(
            IWebDataAccessService dataAccessService,
            IMapper mapper
            )
        {
            _dataAccessService = dataAccessService;
            _mapper = mapper;
        }

        public void SetParams(string userName, string token, AdditionalParameters additionalParameters, int limit = 10)
        {
            _userName = userName;
            _token = token;
            _additionalParameters = additionalParameters;
            _limit = limit;
        }      

        public async Task<IEnumerable<UserCommits>> Dispatch()
        {
            //TODO: Server side validation of parameters perhaps using a Fluent Validator https://fluentvalidation.net/
            //Any validation errors will then be returned to the client as Json for display
            var userRepositories = await _dataAccessService.FetchAsync<IEnumerable<GitHubCommits>>($"{_additionalParameters.Uri}/repos/{_userName}/{_additionalParameters.Repository}/commits?per_page={_limit}", _token);
            return _mapper.Map<IEnumerable<UserCommits>>(userRepositories);            
        }
    }
}
