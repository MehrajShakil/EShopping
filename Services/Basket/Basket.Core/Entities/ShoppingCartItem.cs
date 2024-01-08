namespace Basket.Core.Entities;

public class ShoppingCartItem
{
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public int ProductCount { get; set; }
    public double Price { get; set; }
}
