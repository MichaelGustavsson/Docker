using Azure.Messaging.ServiceBus;

namespace subscriber;

class Program
{
    // ConnectionString...
    static readonly string connectionString = "";
    // Name of the queue...
    static readonly string queueName = "new-vehicles";
    // Reference to ServiceBusClient...
    static ServiceBusClient? client;
    // Reference to subscriber...
    static ServiceBusProcessor? subscriber;

    // Define event handlers...
    // Message processing...
    static async Task MessageHandler(ProcessMessageEventArgs args)
    {
        // Get the message body from args...
        string body = args.Message.Body.ToString();

        Console.WriteLine($"Received: {body}");

        // Spara informationen i en databas...

        // Clean up, remove message from queue...
        await args.CompleteMessageAsync(args.Message);
    }

    // Errorhandling...
    static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }


    static async Task Main()
    {
        // Create the client...
        client = new ServiceBusClient(connectionString);
        // Create the subscriber...
        subscriber = client.CreateProcessor(queueName);
        // Connect to messagehandler...
        subscriber.ProcessMessageAsync += MessageHandler;
        // Connect to errorhandler...
        subscriber.ProcessErrorAsync += ErrorHandler;

        // Start the subscriber and read from the queue...
        await subscriber.StartProcessingAsync();

        Console.WriteLine("Wait for a moment and then press any key to end the application");
        Console.ReadKey();

        // Clean up...
        Console.WriteLine("\nStopping the subscriber");
        await subscriber.StopProcessingAsync();
        Console.WriteLine("Stopped subscribing to the queue");

        // Remove used resources...
        await subscriber.DisposeAsync();
        await client.DisposeAsync();
    }
}
