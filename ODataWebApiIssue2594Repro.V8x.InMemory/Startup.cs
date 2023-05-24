using ODataWebApiIssue2594Repro.V8x.InMemory.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;

namespace ODataWebApiIssue2594Repro.V8x.InMemory
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Order>("Orders");

            services.AddControllers()
                .AddOData(options => options.Select().Filter().OrderBy().Count().Expand().SetMaxTop(null)
                .AddRouteComponents("odata", modelBuilder.GetEdmModel()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(routeBuilder =>
            {
                routeBuilder.MapControllers();
            });
        }
    }
}
