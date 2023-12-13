using Sakura.Core.Messages;
using Sakura.Core.Messages.CommonMessages.Notifications;

namespace Sakura.Core.Communication
{
    public interface CommunicationHandler
    {
        Task<bool> PublishCommand<T>(T command) where T : Command;
        Task PublishEvent<T>(T @event) where T : Event;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}