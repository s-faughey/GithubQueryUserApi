using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechnicalAssessmentTask.Interfaces;
using TechnicalAssessmentTask.Services;
using TechnicalAssessmentTask.ViewModels;

namespace TechnicalAssessmentTask.Controllers
{
    public class ResultsController : Controller
    {
        private readonly IGithubService _githubService;
        public ResultsController(IGithubService githubService)
        {
            _githubService = githubService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string username)
        {
            var resultViewModel = await _githubService.GetUserAndRepos(username);
            if (resultViewModel == null)
            {
                ModelState.AddModelError("username", "Could not find username");
                return RedirectToAction("Index", "Home");
            }
            return View(resultViewModel);
        }
    }
}