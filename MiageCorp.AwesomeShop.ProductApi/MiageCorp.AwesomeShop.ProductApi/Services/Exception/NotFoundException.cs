namespace MiageCorp.AwesomeShop.ProductApi.Services.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}