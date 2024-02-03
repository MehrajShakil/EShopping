
namespace Discount.Core.Entities;

public class Coupon : ARepositoryItem
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
}
