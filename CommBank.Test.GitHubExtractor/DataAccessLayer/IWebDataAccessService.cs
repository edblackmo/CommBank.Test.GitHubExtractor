using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.DataAccessLayer
{
    public interface IWebDataAccessService
    {
        Task<T> GetAsync<T>(string uri, string token);
    }
}
