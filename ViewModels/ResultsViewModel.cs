using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using TechnicalAssessmentTask.Models;

namespace TechnicalAssessmentTask.ViewModels
{
    public class ResultsViewModel
    {
        public GithubUserViewModel GithubUser { get; set; }
        public List<GithubRepoViewModel> Repos { get; set; }
        public ResultsViewModel()
        {

        }
        public ResultsViewModel(GithubUser user, List<GithubRepoViewModel> repos)
        {
            GithubUser = new GithubUserViewModel(user);
            Repos = repos;
        }
    }
}