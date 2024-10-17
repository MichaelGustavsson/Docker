using System.Text.Json;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace publisher;

class Program
{
    static string connectionString = "";
    static string queueName = "vehicles";

    static async Task Main()
    {
        QueueClient client = new(connectionString, queueName);

        var vehicle = new Vehicle
        {
            Id = 2,
            RegistrationNumber = "JKL555",
            Manufacturer = "KIA",
            Model = "EV6",
            ModelYear = 2021
        };

        var json = JsonSerializer.Serialize(vehicle);

        var response = await client.SendMessageAsync(json);

        Console.WriteLine($"Response: {response} - {response.Value.MessageId} - {response.Value.PopReceipt}");

        // Take a peek on whats added to the queue...
        PeekedMessage[] messages = await client.PeekMessagesAsync(maxMessages: 5);

        foreach (var message in messages)
        {
            Console.WriteLine($"Message: {message.MessageText}");
        }

    }
}
