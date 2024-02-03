using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Basket.Infrastructure.Repository;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        this.redisCache = redisCache;
    }

    public async Task DeleteBasketAsync(string email)
    {
        await redisCache.RemoveAsync(email);
    }

    public async Task<ShoppingCart> GetBasketByEmailAsync(string email)
    {
        var shoppingCartString = await redisCache.GetStringAsync(email);
        if(!string.IsNullOrEmpty(shoppingCartString))
        {
            var shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(shoppingCartString);
            return shoppingCart;
        }
        return null;
    }

    public Task<ShoppingCart> GetBasketByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateBasketAsync(ShoppingCart cart)
    {
        var shoppingCartString = JsonConvert.SerializeObject(cart);

        DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
            .SetSlidingExpiration(TimeSpan.FromMinutes(3));

        await redisCache.SetStringAsync(cart.Email, shoppingCartString, options);
    }
}
