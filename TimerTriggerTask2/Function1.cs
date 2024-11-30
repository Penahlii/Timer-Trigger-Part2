using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TimerTriggerTask2.Services;

namespace TimerTriggerTask2
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IQueueService _queueService;

        public Function1(ILoggerFactory loggerFactory, IQueueService queueService)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _queueService = queueService;
        }

        [Function("Function1")]
        public async Task Run([TimerTrigger("*/7 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            var message = await _queueService.ReceiveMessageAsync();
            Console.WriteLine(message);

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
