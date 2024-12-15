using Common.Domain;

using Confluent.Kafka;

using Microsoft.Extensions.Configuration;


namespace Common.Infrastructure
{
    public class NotificationService : INotificationService
    {
        IConfiguration configuration;

        public NotificationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendNotification(string key, string message,string topic)
        {
            var bootstrapServer = configuration.GetSection("Kafka:BootstrapServer").Value;
            var config = new ProducerConfig { BootstrapServers = bootstrapServer };

            using (var producer = new ProducerBuilder<string, string>(config)
                .SetValueSerializer(Serializers.Utf8)
                .SetKeySerializer(Serializers.Utf8)
                .Build())
            {
                await producer.ProduceAsync(topic, new Message<string, string> { Key = key,  Value = message });
                producer.Flush();
            }
        }
    }
}
