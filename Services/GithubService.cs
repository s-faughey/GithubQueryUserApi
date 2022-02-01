using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using TechnicalAssessmentTask.Interfaces;
using TechnicalAssessmentTask.Repositories;
using TechnicalAssessmentTask.ViewModels;
using System.Linq;

namespace TechnicalAssessmentTask.Services
{
    public class GithubService : IGithubService
    {
        private readonly IGithubRepository _githubRepository;
        public GithubService(IGithubRepository githubRepository)
        {
            _githubRepository = githubRepository;
        }

        /// <summary>
        /// Queries the Github api for users and repository information
        /// </summary>
        /// <param name="user">Id of the user to be queried.</param>
        /// <returns>A <see cref="ResultsViewModel"/> containing the user found from github, the 5 repos with the highest
        /// stargazer count, and the Stargazers.</returns>
        public async Task<ResultsViewModel> GetUserAndRepos(string user)
        {
            var model = await _githubRepository.GetGithubUser(user).ConfigureAwait(false);
            if(model.id == null || model.repos_url == null)
            {
                return null;
            }
            var repoModels = await _githubRepository.GetRepos(model.repos_url);
            if (repoModels.Count == 0)
            {
                return new ResultsViewModel(model, new List<GithubRepoViewModel>());
            }
            var reposLargestStargazers = _githubRepository.GetReposWithLargestStargazerCount(repoModels);
            var reposLargestStargazersViewModels = new List<GithubRepoViewModel>();
            foreach(var repo in reposLargestStargazers)
            {
                var stargazers = await _githubRepository.GetGithubUserList(repo.stargazers_url);
                reposLargestStargazersViewModels.Add(new GithubRepoViewModel(repo, stargazers));
            }
            return new ResultsViewModel(model, reposLargestStargazersViewModels);
        }
    }
}