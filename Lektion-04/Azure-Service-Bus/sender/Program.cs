using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace sender;

class Program
{
    // ConnectionsString...
    static readonly string connectionString = "";
    // Name of the queue...
    static readonly string queueName = "new-vehicles";
    // ServiceBus reference...
    static ServiceBusClient? client;
    // Publisher reference...
    static ServiceBusSender? publisher;

    static async Task Main()
    {
        // Instantiate the client...
        client = new ServiceBusClient(connectionString);
        // Create the publisher...
        publisher = client.CreateSender(queueName);

        // Create message package...
        using ServiceBusMessageBatch message = await publisher.CreateMessageBatchAsync();

        var vehicle = new Vehicle
        {
            Id = 1,
            RegistrationNumber = "ABC123",
            Manufacturer = "Volvo",
            Model = "XC60",
            ModelYear = 2019
        };

        var json = JsonSerializer.Serialize(vehicle);

        // Add message to batch...
        message.TryAddMessage(new ServiceBusMessage(json));

        // Send the message batch...
        await publisher.SendMessagesAsync(message);

        Console.WriteLine("The message has been published");

        // Clean up...
        await publisher.DisposeAsync();
        await client.DisposeAsync();

        Console.WriteLine("Press any key to end the application...");
        Console.ReadKey();
    }
}
