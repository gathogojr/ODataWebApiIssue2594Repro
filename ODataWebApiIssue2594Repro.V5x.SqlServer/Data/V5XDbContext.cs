using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using ODataWebApiIssue2594Repro.V5x.SqlServer.Models;

namespace ODataWebApiIssue2594Repro.V5x.Data
{
    public partial class V5XDbContext : DbContext
    {
        public V5XDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);
        }
    }
}
