using MediatR;

namespace Sakura.Core.Messages.CommonMessages.Notifications
{
  public class DomainNotificationHandler : INotificationHandler<DomainNotification>, INotificationOutputHandler
  {
    private List<DomainNotification> _notifications;
    public DomainNotificationHandler()
    {
      _notifications = new List<DomainNotification>();
    }
    public Task Handle(DomainNotification message, CancellationToken cancellationToken)
    {
      _notifications.Add(message);
      return Task.CompletedTask;
    }

    public virtual List<DomainNotification> GetNotifications()
    {
      return _notifications;
    }
    public virtual bool HasNotifications()
    {
      return GetNotifications().Any();
    }

    public virtual bool HasNotifications(out IEnumerable<string> messages)
    {
      messages = _notifications.Select(_ => _.Value);

      if (!HasNotifications()) return false;

      return true;
    }

    public void Dispose()
    {
      _notifications = new List<DomainNotification>();
    }
  }
}