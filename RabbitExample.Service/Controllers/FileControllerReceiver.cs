using Microsoft.AspNetCore.Mvc;
using RabbitExample.Domain.Configurations;
using RabbitExample.Domain.Models;

namespace RabbitExample.Service.Controllers;

[Route("[controller]")]
[ApiController]
public class FileControllerReceiver : ControllerBase
{
    [HttpPost]
    [MessageQueueSubscriber(Bus.Queues.SendFileRequestName)]
    public SendFileResponseModel Post([FromBody] SendFileRequestModel request)
    {
        Console.WriteLine($"Mensagem recebida: {request.Arquivo}");
        
        return SendFileResponseModel.SuccessReturn();
    }

    [HttpGet]
    [MessageQueueSubscriber(Bus.Queues.GetFileRequestName)]
    public GetFileResponseModel Get(GetFileRequestModel request)
    {
        Console.WriteLine($"Mensagem recebida: {request.FileId}");
        
        return GetFileResponseModel.SuccessReturn();
    }
}