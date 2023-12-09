namespace Catalog.Core.Responses;

public class ResponseBase
{
    public int StatusCode { get; set; }
    public List<string> Messages { get; set; } = new();
}
