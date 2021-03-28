namespace CommBank.Test.Contracts.Response
{
    public class UserCommits
    {
        public string Sha { get; set; }
        public GitHubCommit Commit { get; set; }

        public class GitHubCommit
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
}
