using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace subscriber;

class Program
{
    static readonly string connectionString = "";
    static readonly string queueName = "vehicles";

    static async Task Main()
    {
        QueueClient client = new(connectionString, queueName);
        // Create the client...
        await client.CreateAsync();

        // Get the message from the queue...
        QueueMessage[] messages = await client.ReceiveMessagesAsync(maxMessages: 20);

        // Iterate through the list of message
        foreach (var message in messages)
        {
            Console.WriteLine($"Message: {message.MessageText}");

            // Remove the message from the queue...
            await client.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }
    }
}
