using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ODataWebApiIssue2594Repro.V5x.InMemory.Models;

namespace ODataWebApiIssue2594Repro.V5x.InMemory
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Order>("Orders");

            config.Routes.MapODataServiceRoute("odata", "odata", modelBuilder.GetEdmModel());
            config.EnsureInitialized();
        }
    }
}
