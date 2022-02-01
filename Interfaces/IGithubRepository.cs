using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalAssessmentTask.Models;
using TechnicalAssessmentTask.Repositories;

namespace TechnicalAssessmentTask.Interfaces
{
    public interface IGithubRepository
    {
        Task<GithubUser> GetGithubUser(string user);
        Task<List<GithubRepo>> GetRepos(string reposUrl);
        IEnumerable<GithubRepo> GetReposWithLargestStargazerCount(List<GithubRepo> repoModels);
        Task<List<GithubUser>> GetGithubUserList(string url);
    }
}