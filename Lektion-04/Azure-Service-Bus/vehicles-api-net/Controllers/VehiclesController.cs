using Microsoft.AspNetCore.Mvc;
using vehicles_api_net.Models;
using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace vehicles_api_net.Controllers;

[ApiController]
[Route("api/v1/vehicles")]
public class VehiclesController : ControllerBase
{
  [HttpPost()]
  public async Task<ActionResult<Vehicle>> AddVehicle(Vehicle vehicle)
  {
    // Store to database...
    await SendMessage(vehicle);
    return vehicle;
  }

  private static async Task SendMessage(Vehicle vehicle)
  {
    // Fetch the connectionstring...
    var connectionString = "";
    // Connect to the queue...
    var queueName = "new-vehicles";
    // Instantiate the ServiceBusClient
    var client = new ServiceBusClient(connectionString);
    var publisher = client.CreateSender(queueName);

    // Create the batch packet for messages
    using ServiceBusMessageBatch message = await publisher.CreateMessageBatchAsync();

    // Serialize the vehicle object..
    var json = JsonSerializer.Serialize(vehicle);
    // Add message to the message batch...
    message.TryAddMessage(new ServiceBusMessage(json));

    // Send the message...
    await publisher.SendMessagesAsync(message);

    // Cleanup, take down the resources used...
    await publisher.DisposeAsync();
    await client.DisposeAsync();
  }
}