using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities.Identity;
using MyShop.Domain.Entities.Jwt;

namespace MyShop.Infrastructure;

public class MyShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
    {
    }

    #region Tables

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<RevokedToken> RevokedTokens { get; set; }

    #endregion

    #region CreatedAt & ModifiedAt Set

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var now = DateTime.UtcNow;

        var baseEntityEntries = ChangeTracker.Entries()
            .Where(e =>
                e.Entity.GetType().BaseType?.IsGenericType == true &&
                e.Entity.GetType().BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in baseEntityEntries)
        {
            var entity = entry.Entity;
            var createdAtProp = entity.GetType().GetProperty("CreatedAt");
            var modifiedAtProp = entity.GetType().GetProperty("ModifiedAt");

            if (entry.State == EntityState.Added && createdAtProp != null)
                createdAtProp.SetValue(entity, now);

            if (entry.State == EntityState.Modified && modifiedAtProp != null)
                modifiedAtProp.SetValue(entity, now);
        }

        var userEntries = ChangeTracker.Entries<ApplicationUser>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);


        foreach (var entry in userEntries)
        {
            var user = entry.Entity;

            if (entry.State == EntityState.Added)
            {
                user.CreatedAt = now;
                user.ModifiedAt = null;
            }
            else if (entry.State == EntityState.Modified)
            {
                user.ModifiedAt = now;
            }
        }
    }

    #endregion
}