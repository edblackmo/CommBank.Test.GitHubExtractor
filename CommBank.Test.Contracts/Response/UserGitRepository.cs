namespace CommBank.Test.Contracts.Response
{
    public class UserGitRepository
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public RepoOwner Owner { get; set; }
        public string CommitsUrl { get; set; }

        public class RepoOwner
        {
            public string Id { get; set; }
            public string login { get; set; }
            public string Url { get; set; }
            public string OrganizationsUrl { get; set; }
        }
    }
}
