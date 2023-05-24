using ODataWebApiIssue2594Repro.V7x.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ODataWebApiIssue2594Repro.V7x.SqlServer.Data
{
    public class V7xDbContext : DbContext
    {
        public V7xDbContext(DbContextOptions<V7xDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
    }
}
