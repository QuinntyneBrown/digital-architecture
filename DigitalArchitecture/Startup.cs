using Microsoft.Practices.Unity;
using Owin;
using Serilog;
using System.Web.Http;
using Unity.WebApi;

namespace DigitalArchitecture
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = UnityConfiguration.GetContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);
            ApiConfiguration.Install(config, app);
            app.UseWebApi(config);
        }
        
    }
}
