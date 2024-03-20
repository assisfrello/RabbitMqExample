namespace RabbitExample.Domain.Models;

public partial class SendFileResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}

public partial class SendFileResponseModel
{
    public static SendFileResponseModel SuccessReturn()
    {
        return new SendFileResponseModel { Success = true, Message = "Send File Successfully!"};
    }
}