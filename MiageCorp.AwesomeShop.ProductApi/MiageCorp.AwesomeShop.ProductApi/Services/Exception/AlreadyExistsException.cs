namespace MiageCorp.AwesomeShop.ProductApi.Services.Exception;

public class AlreadyExistsException : System.Exception
{
    public AlreadyExistsException(string message) : base(message)
    {
    }
}