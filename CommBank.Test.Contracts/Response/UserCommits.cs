namespace CommBank.Test.Contracts.Response
{
    public class UserCommits
    {
        public class GitHubCommits
        {           
            public string Sha { get; set; }
            public Commit Commit { get; set; }
        }

        public class Commit
        {
            public string Message { get; set; }
            public Author Author { get; set; }
            public Commiter Commiter { get; set; }
        }

        public class Author
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Date { get; set; }
        }

        public class Commiter
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Date { get; set; }
        }
    }
}
