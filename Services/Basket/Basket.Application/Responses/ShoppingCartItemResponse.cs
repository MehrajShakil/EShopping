namespace Basket.Application.Responses;

public class ShoppingCartItemResponse
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductCount { get; set; }
    public double Price { get; set; }
}
