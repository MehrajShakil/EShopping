using Discount.Application.Interfaces;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MongoDB.Driver;

namespace Discount.Infrastructure.Repositories;

internal class CouponRepository : ICouponRepository
{
    private readonly IDatabaseClient _mongodbClient;

    public CouponRepository(IDatabaseClient databaseClient)
    {
        _mongodbClient = databaseClient;
    }
      
    public async Task<Coupon> CreateAsync(Coupon coupon)
    {
        var savedCoupon = await _mongodbClient.CreateAsync(coupon);
        return savedCoupon;
    }

    public Task<bool> DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Coupon> GetByProductNameAsync(string productName)
    {
        Coupon coupon = null;
        // need to implemented.
        return coupon;
    }

    public Task<Coupon> UpdateAsync(Coupon coupon)
    {
        throw new NotImplementedException();
    }
}
