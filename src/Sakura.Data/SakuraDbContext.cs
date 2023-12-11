using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Sakura.Domain.Entities;

namespace Sakura.Data;
public class SakuraDbContext : DbContext
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
}
