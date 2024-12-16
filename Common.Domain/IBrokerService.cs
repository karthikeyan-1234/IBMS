
namespace Common.Domain
{
    public interface IBrokerService
    {
        Task PublishInfo(string key,string message,string topic);
    }
}