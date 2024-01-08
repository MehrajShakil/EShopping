namespace Basket.Core.Entities;

public class ShoppingCart
{
    public ShoppingCart()
    {
        Items = [];
    }

    public required string Email { get; set; }
    public List<ShoppingCartItem> Items { get; set; }
}
