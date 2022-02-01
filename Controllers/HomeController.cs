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
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GithubUserSearchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return RedirectToAction("Index", "Results", new { username = viewModel.UserName });
        }
    }
}