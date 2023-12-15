namespace Catalog.Core.Responses;

public class ResponseBase
{
    public int StatusCode { get; set; }
    public string SuccessfulMessage { get; set; }
    public List<string> ErrorMessages { get; set; } = new();
}
