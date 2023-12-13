using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sakura.Core.Data;
using Sakura.Data.Repositories;
using Sakura.Domain.DomainServices;

namespace Sakura.Data.Configurations
{
    public static class DataConfigurations
    {
        public static void RegisterData(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new NullReferenceException(nameof(services));
            if (configuration == null) throw new NullReferenceException(nameof(configuration));

            services.AddDbContext<SakuraDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SakuraProjectDB")));

            services.AddDbContext<SakuraDbReadOnlyContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SakuraProjectDBRO")));


            services.AddScoped<UnitOfWork, SakuraDbContext>();
            services.AddScoped<CustomerRepository, CustomerRepositoryImp>();
        }
    }
}