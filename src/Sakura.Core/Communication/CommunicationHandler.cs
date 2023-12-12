using MediatR;
using Sakura.Core.Messages;
using Sakura.Core.Messages.CommonMessages.Notifications;

namespace Sakura.Core.Communication;

public class CommunicationHandler
{
    readonly IMediator _mediator;

    public CommunicationHandler(IMediator mediator)
    {
        _mediator = mediator ?? throw new NullReferenceException(nameof(mediator));
    }

    public async Task<bool> PublishCommand<T>(T command) where T : Command
        => await _mediator.Send(command);

    public async Task PublishEvent<T>(T @event) where T : Event
        => await _mediator.Publish(@event);

    public async Task PublishNotification<T>(T notification) where T : DomainNotification
        => await _mediator.Publish(notification);
}
