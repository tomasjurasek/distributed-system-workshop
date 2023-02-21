namespace Payment.Write.Application.Publishers
{
    public interface IEventPublisher
    {
        Task StartAsync();
    }
}
