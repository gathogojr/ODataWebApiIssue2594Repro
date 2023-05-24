using System.Linq;
using ODataWebApiIssue2594Repro.V7x.SqlServer.Data;
using ODataWebApiIssue2594Repro.V7x.SqlServer.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ODataWebApiIssue2594Repro.V7x.SqlServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var contentRoot = Configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            var connectionString = $"Server=(localdb)\\MSSQLLocalDB;AttachDBFilename={contentRoot}\\Data\\V7xDb.mdf;Integrated Security=True;TrustServerCertificate=True;";

            services.AddDbContext<V7xDbContext>(
                options => options.UseSqlServer(connectionString));
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
