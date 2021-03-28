using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.DataAccessLayer
{
    public interface IWebDataAccessService
    {
        Task<T> FetchAsync<T>(string uri, string token);
    }
}
