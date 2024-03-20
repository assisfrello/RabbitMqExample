using RabbitMQ.Client;

namespace RabbitExample.Domain.Configurations;

public class ModelContext
{
    public IModel Model { get; set; }
}