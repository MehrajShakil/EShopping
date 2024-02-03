using Discount.Core.Entities;

namespace Discount.Core.Repositories;

public interface ICouponRepository
{

    Task<Coupon> CreateAsync(Coupon coupon);
    Task<Coupon> UpdateAsync(Coupon coupon);
    Task<bool> DeleteByIdAsync(string id);
    Task<Coupon> GetByProductNameAsync(string productName);
}
