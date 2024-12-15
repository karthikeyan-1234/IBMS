
namespace Purchase.Domain
{
    public interface INotificationService
    {
        Task SendNotification(string key,string message,string topic);
    }
}