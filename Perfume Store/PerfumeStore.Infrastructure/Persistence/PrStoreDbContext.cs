using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using PerfumeStore.Domain.Common;
using PerfumeStore.Domain.Entities;
using PerfumeStore.Infrastructure.Identity;

namespace PerfumeStore.Infrastructure.Persistence
{
    public class PrStoreDbContext : IdentityDbContext<AppUser>
    {
        public PrStoreDbContext(DbContextOptions<PrStoreDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedAt = DateTime.UtcNow;

            return await base.SaveChangesAsync(ct);
        }
    }
}
