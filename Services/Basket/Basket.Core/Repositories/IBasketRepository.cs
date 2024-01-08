using Basket.Core.Entities;

namespace Basket.Core.Repositories;

public interface IBasketRepository
{
    Task UpdateBasketAsync(ShoppingCart cart);
    Task<ShoppingCart> GetBasketByUserNameAsync(string userName);
    Task<ShoppingCart> GetBasketByEmailAsync(string email); 
    Task DeleteBasketAsync(string email);
}
