using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CommBank.Test.GitHubExtractor.DataAccessLayer.GitHub
{
    public class GitHubDataAccessService : IWebDataAccessService
    {
        private readonly IHttpClientFactory _httpClientFactory;
       
        public GitHubDataAccessService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;            
        }

        public async Task<T> FetchAsync<T>(string uri, string token) 
        {
            var httpClient = _httpClientFactory.CreateClient();
            AddRequiredHeaders(httpClient, token);
                       
            var response = await httpClient.GetAsync(uri);

            //TODO: Implement proper exception handling that will translate exceptions/HTTP codes
            //to serializable exceptions to be consumed by the front end
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();        
            return JsonConvert.DeserializeObject<T>(content);                
        }

        private void AddRequiredHeaders(HttpClient httpClient, string token)
        {           
            httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("CommBank.Test.GitHubExtractor", "1.0"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);            
        }      
    }
}
