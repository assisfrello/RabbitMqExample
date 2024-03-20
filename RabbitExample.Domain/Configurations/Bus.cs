using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitExample.Domain.Configurations;

public class Bus
{
    public static class Hosts
    {
        public const string HostName = "localhost";
    }
    
    public static class Exchanges
    {
        public const string SendFileName = "File";
    }
    
    public static class Queues
    {
        public const string SendFileRequestName = "File.Send";
        public const string GetFileRequestName = "File.Get";
    }

    public static void ConfigureBus(IModel channel)
    {
        channel.ExchangeDeclare(Exchanges.SendFileName, ExchangeType.Direct);
        
        channel.QueueDeclare(Queues.SendFileRequestName, true, false, false, new Dictionary<string, object>());
        channel.QueueBind(Queues.SendFileRequestName, Exchanges.SendFileName, "log.info");
        
        channel.QueueDeclare(Queues.GetFileRequestName, true, false, false, new Dictionary<string, object>());
        channel.QueueBind(Queues.GetFileRequestName, Exchanges.SendFileName, "log.info");
    }
    
    public static void ConfigureConsumers(IModel channel, EventingBasicConsumer consumer)
    {
        channel.BasicConsume(queue: Queues.SendFileRequestName, autoAck: true, consumer: consumer);
        channel.BasicConsume(queue: Queues.GetFileRequestName, autoAck: true, consumer: consumer);
    }
}