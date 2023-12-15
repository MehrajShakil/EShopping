
namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string ProductCode { get; set; }
    public required ProductBrand Brand { get; set; }
    public required ProductType Type { get; set; }
    public decimal Price { get; set; }
}
