namespace Order.Write.Application.Publishers
{
    public interface IEventPublisher
    {
        Task StartAsync();
    }
}
