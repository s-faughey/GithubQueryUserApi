using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TechnicalAssessmentTask.Interfaces;
using TechnicalAssessmentTask.Models;
using TechnicalAssessmentTask.ViewModels;

namespace TechnicalAssessmentTask.Repositories
{
    public class GithubRepository : IGithubRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GithubRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Queries the Github api for a user
        /// </summary>
        /// <param name="user">Id of the user to be queried</param>
        /// <returns>A <see cref="GithubUser"/> found using the API</returns>
        public async Task<GithubUser> GetGithubUser(string user)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"https://api.github.com/users/{user}"));
                client.DefaultRequestHeaders.Add("User-Agent", "Github User app");

                GithubUser model = null;
                var task = client.SendAsync(request)
                  .ContinueWith((taskwithresponse) =>
                  {
                      var response = taskwithresponse.Result;
                      var jsonString = response.Content.ReadAsStringAsync();
                      jsonString.Wait();
                      model = JsonConvert.DeserializeObject<GithubUser>(jsonString.Result);
                  });
                task.Wait();

                return model;
            }
        }

        /// <summary>
        /// Queries the Github api for a set of repositories
        /// </summary>
        /// <param name="repos_url">URL of the users repositories to be queried</param>
        /// <returns>A <see cref="List"/> of <see cref="GithubRepo"/> found using the API</returns>
        public async Task<List<GithubRepo>> GetRepos(string repos_url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(repos_url));
                client.DefaultRequestHeaders.Add("User-Agent", "Github User app");

                List<GithubRepo> model = null;
                var task = client.SendAsync(request)
                  .ContinueWith((taskwithresponse) =>
                  {
                      var response = taskwithresponse.Result;
                      var jsonString = response.Content.ReadAsStringAsync();
                      jsonString.Wait();
                      model = JsonConvert.DeserializeObject<List<GithubRepo>>(jsonString.Result);
                  });
                task.Wait();

                return model;
            }
        }

        /// <summary>
        /// Queries the Github api for a set of users
        /// </summary>
        /// <param name="url">URL of the set of github users</param>
        /// <returns>A <see cref="List"/> of <see cref="GithubUser"/> found using the API</returns>
        public async Task<List<GithubUser>> GetGithubUserList(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
                client.DefaultRequestHeaders.Add("User-Agent", "Github User app");

                List<GithubUser> model = null;
                var task = client.SendAsync(request)
                  .ContinueWith((taskwithresponse) =>
                  {
                      var response = taskwithresponse.Result;
                      var jsonString = response.Content.ReadAsStringAsync();
                      jsonString.Wait();
                      model = JsonConvert.DeserializeObject<List<GithubUser>>(jsonString.Result);
                  });
                task.Wait();

                return model;
            }
        }

        /// <summary>
        /// Creates a set of 5 <see cref="GithubRepo"/> with the highest stargazer_count
        /// </summary>
        /// <param name="repoModels"></param>
        /// <returns>A <see cref="List"/> of <see cref="GithubRepo"/> in ascending order</returns>
        public IEnumerable<GithubRepo> GetReposWithLargestStargazerCount(List<GithubRepo> repoModels)
        {
            return repoModels.OrderByDescending(x => x.stargazers_count).Take(5);
        }
    }
}