namespace RabbitExample.Domain.Models;

public partial class GetFileResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}

public partial class GetFileResponseModel
{
    public static GetFileResponseModel SuccessReturn()
    {
        return new GetFileResponseModel { Success = true, Message = "Get File Successfully!"};
    }
}