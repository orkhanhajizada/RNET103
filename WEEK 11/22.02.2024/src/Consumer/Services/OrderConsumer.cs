using System.Text.Json;
using MassTransit;
using SimpleMicroService.Configurations.Models;

namespace Consumer.Services;

public class OrderConsumer : IConsumer<Order>
{
    private readonly ILogger<OrderConsumer> _logger;

    public OrderConsumer(ILogger<OrderConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Order> context)
    {
        _logger.LogInformation(JsonSerializer.Serialize(context.Message));
        return Task.CompletedTask;
    }
}