using Confluent.Kafka;
using Purchase.Domain.Models;
using Purchase.Services;
using System.Text.Json;


namespace InventoryProject.Services
{
    public class PurchaseBackgroundService : BackgroundService
    {
        IServiceProvider _serviceProvider;

        public PurchaseBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Console.WriteLine("PurchaseBackgroundService started");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();

            //Get Inventory service instance
            var inventoryService = scope.ServiceProvider.GetRequiredService<IPurchaseService>();

            var config = new ConsumerConfig
            {
                BootstrapServers = "192.168.1.20:9092",

                GroupId = "purchase-consumer-group", // Unique group ID
                AutoOffsetReset = AutoOffsetReset.Latest // Start consuming from the beginning

            };

            string[] topics = { "new-material", "new-material-group" };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe(topics);

                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(stoppingToken);

                        Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");

                        switch (consumeResult.Topic)
                        {
                            case "new-material":
                                Console.WriteLine("New material received");
                                var newMaterial = JsonSerializer.Deserialize<Material>(consumeResult.Message.Value);
                                await inventoryService.AddMaterialAsync(newMaterial!);
                                break;

                            case "new-material-group":
                                Console.WriteLine("New material category received");
                                var newMaterialGroup = JsonSerializer.Deserialize<MaterialCategory>(consumeResult.Message.Value);
                                await inventoryService.AddMaterialCategoryAsync(newMaterialGroup!);
                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Error occured: {e.Message}");
                    }

                    await Task.Delay(1000, stoppingToken);

                }

            }

        }
    }
}
