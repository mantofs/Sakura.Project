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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(SakuraDbReadOnlyContext).Assembly);
    }
}
