using AutoMapper;
using CommBank.Test.Contracts.Response;
using CommBank.Test.GitHubExtractor.GitHub.Contracts.Response;

namespace CommBank.Test.GitHubExtractor.Profiles
{
    public class GitHubAutoMapperProfile : Profile
    {
        public GitHubAutoMapperProfile()
        {
            CreateMap<GitHubRepositories, UserGitRepository>();
            CreateMap<Owner, UserGitRepository.RepoOwner>();
            CreateMap<GitHubCommits, UserCommits>();
            CreateMap<Commit, UserCommits.GitHubCommit>();
            CreateMap<Author, UserCommits.Author>();
            CreateMap<Committer, UserCommits.Committer>();            
        }
    }
}
