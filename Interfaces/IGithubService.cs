using System.Threading.Tasks;
using TechnicalAssessmentTask.ViewModels;

namespace TechnicalAssessmentTask.Interfaces
{
    public interface IGithubService
    {
        Task<ResultsViewModel> GetUserAndRepos(string user);
    }
}