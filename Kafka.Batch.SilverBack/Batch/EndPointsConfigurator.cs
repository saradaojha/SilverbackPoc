﻿using Confluent.Kafka;
using Silverback.Messaging.Configuration;

namespace Kafka.Batch.SilverBack.Batch
{
    public class EndPointsConfigurator : IEndpointsConfigurator
    {        
        public void Configure(IEndpointsConfigurationBuilder builder)
        {
            builder
               .AddKafkaEndpoints(
                   endpoints => endpoints

                       // Configure the properties needed by all consumers/producers
                       .Configure(
                           config =>
                           {
                               // The bootstrap server address is needed to connect
                               config.BootstrapServers =
                                   "localhost:9092";
                           })

                       // Consume the samples-batch topic
                       .AddInbound(
                           endpoint => endpoint
                               .ConsumeFrom("testdata5")
                               .Configure(
                                   config =>
                                   {

                                       // The consumer needs at least the bootstrap
                                       // server address and a group id to be able
                                       // to connect
                                       config.GroupId = "gid-consumers";

                                       // AutoOffsetReset.Earliest means that the
                                       // consumer must start consuming from the
                                       // beginning of the topic, if no offset was
                                       // stored for this consumer group
                                       config.AutoOffsetReset =
                                           AutoOffsetReset.Earliest;
                                   })

                               // Configure processing in batches of 100 messages,
                               // with a max wait time of 5 seconds
                               .EnableBatchProcessing(10, TimeSpan.FromSeconds(10))));
        }

    }
}
