using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sakura.Application.Customers;
using Sakura.Core.Communication;
using Sakura.Data.Configurations;

namespace Sakura.Application.Configurations
{
    public static class RegisterServicesConfigurations
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new NullReferenceException(nameof(services));

            services.RegisterData(configuration);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<CommunicationHandler, CommunicationHandlerImp>();

            services.AddTransient<CustomerService, CustomerServiceImp>();
        }
    }
}