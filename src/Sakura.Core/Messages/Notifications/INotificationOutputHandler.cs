namespace Sakura.Core.Messages.CommonMessages.Notifications
{
    public interface INotificationOutputHandler
    {
        bool HasNotifications();
        bool HasNotifications(out IEnumerable<string> messages);
    }
}