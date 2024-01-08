using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sakura.Application.Customers;
using Sakura.Core.Communication;
using Sakura.Core.Messages.CommonMessages.Notifications;
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

            services.AddTransient<CommunicationHandler, CommunicationHandlerImp>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped(provider => (INotificationOutputHandler)provider.GetRequiredService<INotificationHandler<DomainNotification>>());

            services.AddTransient<CustomerService, CustomerServiceImp>();
        }
    }
}