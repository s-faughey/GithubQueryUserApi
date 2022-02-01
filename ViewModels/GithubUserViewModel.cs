using System.ComponentModel.DataAnnotations;
using TechnicalAssessmentTask.Models;

namespace TechnicalAssessmentTask.ViewModels
{
    public class GithubUserViewModel
    {
        public GithubUserViewModel(GithubUser gazer)
        {
            Username = gazer.login;
            Location = gazer.location;
            AvatarUrl = gazer.avatar_url;
        }

        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
    }
}