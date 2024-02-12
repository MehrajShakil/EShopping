using Catalog.Core.Entities;
using MongoDB.Driver;


namespace Catalog.Infrastructure.Data;

public interface ICatalogContext
{
    public IMongoCollection<ProductCategory> ProductCategory { get; set; }
    public IMongoCollection<Product> Product { get; set; }
    public IMongoCollection<ProductBrand> ProductBrand { get; set; }
}
