using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessmentTask.ViewModels
{
    public class GithubUserSearchViewModel
    {
        [Required(ErrorMessage = "You must enter a username")]
        public string UserName { get; set; }
    }
}