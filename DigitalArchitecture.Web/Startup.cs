using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using static DigitalArchitecture.Helpers.StartupHelper;

[assembly: OwinStartup(typeof(DigitalArchitecture.Web.Startup))]

namespace DigitalArchitecture.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            GlobalConfiguration.Configure(config =>
            {
                var container = UnityConfiguration.GetContainer();
                InitLogging(container);
                config.DependencyResolver = new UnityDependencyResolver(container);                                
                ApiConfiguration.Install(config, app);
            });
        }
    }
}
