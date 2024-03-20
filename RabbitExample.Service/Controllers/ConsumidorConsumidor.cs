using MassTransit;
using RabbitExample.Domain.Models;

namespace RabbitExample.Service.Controllers;

public class ConsumidorConsumidor : IConsumer<SendFileRequestModel>
{
    public Task Consume(ConsumeContext<SendFileRequestModel> context)
    {
        // var id = context.Message.ClientId;
        // var name = context.Message.Name;

        // Console.WriteLine($"New client: [{id}] - {name}");
        return Task.CompletedTask;
    }
}