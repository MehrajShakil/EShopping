namespace Basket.Application.Responses;

public class ShoppingCartResponse
{

    public ShoppingCartResponse()
    {
        Items = [];
    }

    public required string Email { get; set; }
    List<ShoppingCartItemResponse> Items { get; set; }
    public double TotalPrice
    {
        get
        {
            double totalPrice = 0;
            Items.ForEach(item => {
                totalPrice += item.Price;
            });
            return totalPrice;
        }
    }
}
