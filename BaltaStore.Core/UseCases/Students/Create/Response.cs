using Flunt.Notifications;

namespace BaltaStore.Core.UseCases.Students.Create;

public class Response : Notifiable<Notification>
{
    public Response(string message = "")
        => Message = message;

    public Response(string message, IReadOnlyCollection<Notification> notifications)
    {
        Message = message;
        AddNotifications(notifications);
    }

    public Response(string message, Notification notification)
    {
        Message = message;
        AddNotification(notification);
    }

    public string Message { get; }
}