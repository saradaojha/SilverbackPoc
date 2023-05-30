using Kafka.Batch.SilverBack.Model;
using Newtonsoft.Json;

namespace Kafka.Batch.SilverBack.Batch
{
    public class MessageBatchSubscriber
    {
        private readonly ILogger<MessageBatchSubscriber> _logger;

        public MessageBatchSubscriber(
            ILogger<MessageBatchSubscriber> logger)
        {
            _logger = logger;
        }

        public async Task OnBatchReceivedAsync(IAsyncEnumerable<CarMessage> batch)
        {
            if (batch == null)
            {
                return;
            }
            int sum = 0;
            int count = 0;

            string filePath = @"C:\Temp\BatchOutput_" + DateTime.Now.Ticks.ToString() + ".txt";
            File.WriteAllText(filePath, JsonConvert.SerializeObject(batch));

            //await foreach (var message in batch)
            //{

            //    sum += message.CarId;
            //    count++;
            //    //Console.WriteLine($"message received : {message.CarId} : {message.CarName}{message.BookingStatus}");
            //}

            //Console.WriteLine(
            //      "Received batch of {Count} message -> sum: {Sum}",
            //      count,
            //      sum);

            //_logger.LogInformation(
            //    "Received batch of {Count} message -> sum: {Sum}",
            //    count,
            //    sum);

            await Task.Delay(2000);
        }
    }
}
