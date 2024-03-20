using RabbitMQ.Client;

namespace RabbitExample.Domain.Configurations;

public class RabbitMqConfig
{
    public static ModelContext AddConfigurationPublish()
    {
        var factory = new ConnectionFactory() { HostName = Bus.Hosts.HostName };
        var connection = factory.CreateConnection();
        var model = connection.CreateModel();
        
        model.ExchangeDeclare(Bus.Exchanges.SendFileName, ExchangeType.Direct);
        
        model.QueueDeclare(Bus.Queues.SendFileRequestName, true, false, false, new Dictionary<string, object>());
        model.QueueBind(Bus.Queues.SendFileRequestName, Bus.Exchanges.SendFileName, "log.info");
        
        model.QueueDeclare(Bus.Queues.GetFileRequestName, true, false, false, new Dictionary<string, object>());
        model.QueueBind(Bus.Queues.GetFileRequestName, Bus.Exchanges.SendFileName, "log.info");
        
        return new ModelContext { Model = model };
    }
}