using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TechnicalAssessmentTask.Controllers;
using TechnicalAssessmentTask.Interfaces;
using TechnicalAssessmentTask.Repositories;
using TechnicalAssessmentTask.Services;

namespace TechnicalAssessmentTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Register<IGithubService, GithubService>();
            container.Register<IGithubRepository, GithubRepository>();
            container.RegisterMvcControllers();
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            container.RegisterInstance(serviceProvider.GetService<IHttpClientFactory>());
            container.ContainerScope.RegisterForDisposal(serviceProvider);
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
