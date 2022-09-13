namespace EventBus.Abstractions
{
    public interface IIntegrationEventHandler
    {
        (string, string) GetTopicAndSubscription();
        Task Handle(string body);
    }
}
