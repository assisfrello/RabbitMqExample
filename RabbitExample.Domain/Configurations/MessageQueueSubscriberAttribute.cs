namespace RabbitExample.Domain.Configurations;

[AttributeUsage(AttributeTargets.Method)]
public class MessageQueueSubscriberAttribute : Attribute
{
    public MessageQueueSubscriberAttribute(string queue)
    {
        Queue = queue;
    }

    public string Queue { get; set; }
}