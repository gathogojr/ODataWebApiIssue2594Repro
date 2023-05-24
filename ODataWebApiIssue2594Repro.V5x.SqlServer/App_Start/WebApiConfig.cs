using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ODataWebApiIssue2594Repro.V5x.App_Start;
using ODataWebApiIssue2594Repro.V5x.SqlServer.Models;
using Unity.WebApi;

namespace ODataWebApiIssue2594Repro.V5x.SqlServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);

            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Order>("Orders");
            
            config.Routes.MapODataServiceRoute("odata", "odata", modelBuilder.GetEdmModel());
            config.EnsureInitialized();
        }
    }
}
