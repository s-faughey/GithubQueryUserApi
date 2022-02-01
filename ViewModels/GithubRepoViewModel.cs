using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechnicalAssessmentTask.Models;

namespace TechnicalAssessmentTask.ViewModels
{
    public class GithubRepoViewModel
    {
        [Display(Name = "Repository name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Url { get; set; }
        public List<GithubUserViewModel> Stargazers { get; set; }
        public GithubRepoViewModel(GithubRepo repo, List<GithubUser> stargazers)
        {
            Name = repo.name;
            Description = repo.description;
            Stargazers = new List<GithubUserViewModel>();
            Url = repo.html_url;
            foreach (var gazer in stargazers)
            {
                Stargazers.Add(new GithubUserViewModel(gazer));
            }
        }
    }
}