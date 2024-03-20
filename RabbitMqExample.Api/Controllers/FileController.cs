using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitExample.Domain.Configurations;
using RabbitExample.Domain.Models;
using RabbitMQ.Client;

namespace RabbitMqExample.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly ModelContext _modelContext;
    
    public FileController(ModelContext modelContext)
    {
        _modelContext = modelContext;
    }

    [HttpPost]
    public SendFileResponseModel Post([FromBody] SendFileRequestModel request)
    {
        var body = Encoding.UTF8.GetBytes(request.Arquivo!);
        
        _modelContext.Model.BasicPublish(exchange: "", routingKey: _modelContext.Model.CurrentQueue, body: body);

        return SendFileResponseModel.SuccessReturn();
    }

    [HttpGet]
    public GetFileResponseModel Get([FromQuery] GetFileRequestModel request)
    {
        var body = Encoding.UTF8.GetBytes(request.FileId);
        
        _modelContext.Model.BasicPublish(exchange: "", routingKey: _modelContext.Model.CurrentQueue, body: body);

        return GetFileResponseModel.SuccessReturn();
    }
}