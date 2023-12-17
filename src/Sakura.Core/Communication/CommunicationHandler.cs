using Sakura.Core.Messages;
using Sakura.Core.Messages.CommonMessages.Notifications;

namespace Sakura.Core.Communication
{
    public interface CommunicationHandler
    {
        Task<bool> PublishCommandAsync<T>(T command) where T : Command;
        Task PublishEventAsync<T>(T @event) where T : Event;
        Task PublishNotificationAsync<T>(T notification) where T : DomainNotification;
    }
}