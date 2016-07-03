using Owin;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Owin.Security.OAuth;
using Swashbuckle.Application;
using Microsoft.Owin.Cors;
using System;
using DigitalArchitecture.Utilities;
using DigitalArchitecture.Configuration;
using DigitalArchitecture.Services;
using DigitalArchitecture.Authentication;
using DigitalArchitecture.Filters;
using DigitalArchitecture.Trace;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using SerilogWeb.Classic.Enrichers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;

namespace DigitalArchitecture
{
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            InitLogging();

            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);

            app.MapSignalR();


            config.Filters.Add(new HandleErrorAttribute(UnityConfiguration.GetContainer().Resolve<ILoggerFactory>()));

            app.UseCors(CorsOptions.AllowAll);

            config.SuppressHostPrincipal();

            IIdentityService identityService = UnityConfiguration.GetContainer().Resolve<IIdentityService>();
            Lazy<IAuthConfiguration> lazyAuthConfiguration = UnityConfiguration.GetContainer().Resolve<Lazy<IAuthConfiguration>>();

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "DigitalArchitecture"))
                .EnableSwaggerUi();

            app.UseOAuthAuthorizationServer(new OAuthOptions(lazyAuthConfiguration, identityService));

            app.UseJwtBearerAuthentication(new JwtOptions(lazyAuthConfiguration));

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            var jSettings = new JsonSerializerSettings();
            jSettings.Formatting = Formatting.Indented;
            jSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute( name: "DefaultApi", routeTemplate: "api/{controller}" );
        }

        public static void InitLogging()
        {
            var settings = UnityConfiguration.GetContainer().Resolve<Lazy<ITraceConfiguration>>();

            TraceService.Performance = CreateLogger(settings.Value, "digitial-architecture-performance-{Date}.txt", "Performance", new Collection<DataColumn>
            {
                new DataColumn {DataType = typeof(string), ColumnName = "OperationName" },
                new DataColumn {DataType = typeof(int), ColumnName = "TimeTakenMsec" },
                new DataColumn {DataType = typeof(string), ColumnName = "OperationResult" },
                new DataColumn {DataType = typeof(DateTime), ColumnName = "StartedTime" }
            });

        }

        public static Serilog.ILogger CreateLogger(ITraceConfiguration settings, string fileName = null, string tableName = null, ICollection<DataColumn> additionalColumns = null, bool? logToFile = null, bool? logToSql = null)
        {
            var logsPath = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME"))
                ? Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                : Path.Combine(Environment.GetEnvironmentVariable("HOME"), "LogFiles");

            var logger = new LoggerConfiguration()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<UserNameEnricher>()
                .Enrich.With<EventIdEnricher>();

            if (logToFile ?? settings.LogToFile && !string.IsNullOrEmpty(fileName))
            {
                logger = logger.WriteTo.RollingFile(Path.Combine(logsPath, fileName), fileSizeLimitBytes: null);
            }

            if (logToSql ?? Convert.ToBoolean(settings.LogToSql) &&
                !string.IsNullOrEmpty(settings.LoggingSqlServerConnectionString) &&
                !string.IsNullOrEmpty(tableName))
            {
                var columnOptions = new ColumnOptions
                {
                    AdditionalDataColumns = new Collection<DataColumn>
                    {
                        new DataColumn {DataType = typeof(string), ColumnName = "UserName"},
                        new DataColumn {DataType = typeof(string), ColumnName = "HttpRequestId"},
                        new DataColumn {DataType = typeof(int), ColumnName = "EventId"}
                    }
                    .Union(additionalColumns ?? Enumerable.Empty<DataColumn>())
                    .ToList()
                };
                logger = logger.WriteTo
                    .MSSqlServer(settings.LoggingSqlServerConnectionString, tableName, columnOptions: columnOptions);
            }
            return logger.CreateLogger();
        }

    }
}
