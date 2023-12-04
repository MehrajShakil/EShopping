using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{


    #region Collections

    public IMongoCollection<ProductType> ProductType {  get; set; }
    public IMongoCollection<Product> Product { get; set; }
    public IMongoCollection<ProductBrand> ProductBrand { get; set; }

    #endregion

    public CatalogContext(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Product = database.GetCollection<Product>(nameof(Product));
        ProductType = database.GetCollection<ProductType>(nameof(ProductType));
        ProductBrand = database.GetCollection<ProductBrand>(nameof(ProductBrand));
    }

}
