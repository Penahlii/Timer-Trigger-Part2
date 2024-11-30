namespace TimerTriggerTask2.Services;

public interface IQueueService
{
    Task SendMessageAsync(string message);
    Task<string> ReceiveMessageAsync();
}
