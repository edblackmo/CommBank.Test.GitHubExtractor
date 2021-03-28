using Newtonsoft.Json;

namespace CommBank.Test.GitHubExtractor.GitHub.Contracts.Response
{
    public class GitHubRepositories
    {
        public string Id { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }     
        public Owner Owner { get; set; }
        public string CommitsUrl { get; set; }     
    }

    public class Owner
    {
        public string Id { get; set; }
        public string login { get; set; }
        public string Url { get; set; }
        [JsonProperty("organizations_url")]
        public string OrganizationsUrl { get; set; }
    }
}
