using System.Linq;
using ODataWebApiIssue2594Repro.V7x.InMemory.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ODataWebApiIssue2594Repro.V7x.InMemory
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Order>("Orders");

            app.UseRouting();

            app.UseEndpoints(routeBuilder =>
            {
                routeBuilder.MapODataRoute("odata", "odata", modelBuilder.GetEdmModel());
                routeBuilder.Select().Filter().OrderBy().Count().Expand().MaxTop(null);
                routeBuilder.MapControllers();
            });
        }
    }
}
