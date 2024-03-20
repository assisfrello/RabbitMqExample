using Microsoft.OpenApi.Models;
using RabbitExample.Domain.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5001");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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

builder.Services.AddSingleton(RabbitMqConfig.AddConfigurationPublish());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQExample v1");
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();