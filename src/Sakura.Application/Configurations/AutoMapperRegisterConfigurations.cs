using Microsoft.Extensions.DependencyInjection;
using Sakura.Application.Profiles;

namespace Sakura.Application.Configurations
{
    public static class AutoMapperRegisterConfigurations
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            if (services == null) throw new NullReferenceException(nameof(services));

            services.AddAutoMapper(typeof(CustomerMappingProfile));
        }
    }
}