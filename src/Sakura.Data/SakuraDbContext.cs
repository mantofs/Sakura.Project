using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Sakura.Core;
using Sakura.Core.Data;
using Sakura.Domain.Entities;

namespace Sakura.Data;
public class SakuraDbContext : DbContext, UnitOfWork
{
    public DbSet<Customer> Customers { get; set; }

    public SakuraDbContext(DbContextOptions<SakuraDbContext> options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
          e => e.GetProperties().Where(p => p.ClrType == typeof(string))
        ))
            property.SetColumnType("varchar(100)");

        modelBuilder.Ignore<ValidationResult>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SakuraDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => typeof(Entity).IsAssignableFrom(entry.Entity.GetType())))
        {
            if (entry.State == EntityState.Added)
            {
                ((Entity)entry.Entity).SetCreated();
            }

            if (entry.State == EntityState.Modified)
            {
                ((Entity)entry.Entity).SetUpdated();
            }

        }

        return await base.SaveChangesAsync() > 0;
    }
}
