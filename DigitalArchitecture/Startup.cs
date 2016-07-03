using DigitalArchitecture.Configuration;
using DigitalArchitecture.Trace;
using Microsoft.Practices.Unity;
using Owin;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using SerilogWeb.Classic.Enrichers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
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
