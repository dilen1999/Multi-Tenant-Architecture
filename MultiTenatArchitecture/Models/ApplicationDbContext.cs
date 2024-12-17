using Microsoft.EntityFrameworkCore;
using MultiTenatArchitecture.Services;

namespace MultiTenatArchitecture.Models
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentTenantService _currentTenantService;
        public string CurrentTenantId {  get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentTenantService currentTenantService) : base(options) 
        {
            _currentTenantService = currentTenantService;
            CurrentTenantId = _currentTenantService.TenantId;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tenants> Tenants { get; set; }

        // on app startup 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasQueryFilter(a => a.TenantId == CurrentTenantId);
        }


        //every time save something
        //public override int SaveChanges()
        //{
        //    if (string.IsNullOrEmpty(CurrentTenantId))
        //    {
        //        throw new Exception("Current TenantId cannot be null.");
        //    }
        //    foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
        //    {
        //        switch(entry.State)
        //        {

        //            case EntityState.Added:
        //                case EntityState.Modified:
        //                    entry.Entity.TenantId = CurrentTenantId;
        //                break;
        //        }

        //    }
        //    var result = base.SaveChanges();
        //    return result;
        //}
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        // Only set TenantId if it’s not already provided
                        if (string.IsNullOrEmpty(entry.Entity.TenantId))
                        {
                            entry.Entity.TenantId = CurrentTenantId;
                        }
                        break;

                    case EntityState.Modified:
                        // Optionally restrict modifications to TenantId
                        break;
                }
            }
            return base.SaveChanges();
        }

    }
}
