using Kafka.Batch.SilverBack.Batch;

namespace Kafka.Batch.SilverBack
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //// Enable Silverback
            services
                .AddSilverback()
                // Use Apache Kafka as message broker
                .WithConnectionToMessageBroker(
                    options => options
                        .AddKafka()
                        ).AddEndpointsConfigurator<EndPointsConfigurator>()
                        .AddSingletonSubscriber<MessageBatchSubscriber>(); 
            services.AddHostedService<KafkaService>();
             
        }
        public void Configure()
        {

        }
    }
}
