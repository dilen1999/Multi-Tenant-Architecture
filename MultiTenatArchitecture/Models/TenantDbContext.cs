using Microsoft.EntityFrameworkCore;

namespace MultiTenatArchitecture.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) 
        {

        }
        public DbSet<Tenants> Tenants { get; set; }
    }
}
