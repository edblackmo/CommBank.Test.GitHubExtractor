using Newtonsoft.Json;

namespace CommBank.Test.GitHubExtractor.GitHub.Contracts.Response
{
    public class GitHubCommits
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }
        public Commit Commit { get; set; }
    }

    public class Commit
    {
        public string Message { get; set; }
        public Author Author { get; set; }
        public Committer Committer { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
    }

    public class Committer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
    }
}
