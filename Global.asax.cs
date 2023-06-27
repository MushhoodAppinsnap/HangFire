using Hangfire;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace hangfireTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        private IEnumerable<IDisposable> GetHangfireServers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HangFireTest"].ConnectionString;
            Hangfire.GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionString);

            yield return new BackgroundJobServer();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            HangfireAspNet.Use(GetHangfireServers);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
        }
    }
}
