using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Sakura.Domain.Entities;

namespace Sakura.Data;

public class SakuraDbReadOnlyContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public SakuraDbReadOnlyContext(DbContextOptions<SakuraDbReadOnlyContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SakuraDbReadOnlyContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
