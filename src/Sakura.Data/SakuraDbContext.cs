using Microsoft.EntityFrameworkCore;

namespace Sakura.Data;
public class SakuraDbContext : DbContext
{
    public SakuraDbContext(DbContextOptions<SakuraDbContext> options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(SakuraDbContext).Assembly);
    }
}
