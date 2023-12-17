using MediatR;
using Sakura.Core.Messages;
using Sakura.Core.Messages.CommonMessages.Notifications;

namespace Sakura.Core.Communication;

public class CommunicationHandlerImp : CommunicationHandler
{
    readonly IMediator _mediator;

    public CommunicationHandlerImp(IMediator mediator)
    {
        _mediator = mediator ?? throw new NullReferenceException(nameof(mediator));
    }

    public async Task<bool> PublishCommandAsync<T>(T command) where T : Command
        => await _mediator.Send(command);

    public async Task PublishEventAsync<T>(T @event) where T : Event
        => await _mediator.Publish(@event);

    public async Task PublishNotificationAsync<T>(T notification) where T : DomainNotification
        => await _mediator.Publish(notification);
}
