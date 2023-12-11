using Microsoft.Extensions.DependencyInjection;

namespace Sakura.Application.Configurations
{
    public static class AutoMapperRegisterConfigurations
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            if (services == null) throw new NullReferenceException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperRegisterConfigurations).GetType().Assembly);
        }
    }
}