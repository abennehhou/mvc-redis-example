using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace MvcRedisDemo
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Configure Unity Container

            var unityContainer = UnityConfig.GetConfiguredContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));

            //TODO ABE Add logging
        }
    }
}
