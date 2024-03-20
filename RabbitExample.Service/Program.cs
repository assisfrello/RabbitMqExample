using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RabbitExample.Domain.Configurations;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5003", "https://localhost:5004");

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{ 
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Messaging", Version = "v1",
            Description = "<h3>Example RabbitMQ</h3><h4><b>Demonstration</b></h4></p>",
            Contact = new OpenApiContact { Name = "Nome contato", Email = "suporte@seuprovedor.com", Url = new Uri("https://seudominio.com/") }
        });
});

var factory = new ConnectionFactory() { HostName = Bus.Hosts.HostName };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

Bus.ConfigureBus(channel);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (_, ea) =>
{
    var queueName = ea.RoutingKey;
            
    var controllerTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => typeof(ControllerBase).IsAssignableFrom(t));

    foreach (var controllerType in controllerTypes)
    {
        var instance = Activator.CreateInstance(controllerType);
        var methods = controllerType.GetMethods().Where(m => m.GetCustomAttributes<MessageQueueSubscriberAttribute>()
            .Any(a => a.Queue == queueName));
                        
        foreach (var method in methods)
        {
            var parameterType = method.GetParameters().FirstOrDefault()?.ParameterType;
            var requestModel = parameterType != null ? Activator.CreateInstance(parameterType) : null;
            method.Invoke(instance, new[] { requestModel });
        }
    }
};

Bus.ConfigureConsumers(channel, consumer);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQExample v1");
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();