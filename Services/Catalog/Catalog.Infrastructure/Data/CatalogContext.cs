using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{


    #region Collections

    public IMongoCollection<ProductCategory> ProductCategory {  get; set; }
    public IMongoCollection<Product> Product { get; set; }
    public IMongoCollection<ProductBrand> ProductBrand { get; set; }

    #endregion

    public CatalogContext(IConfiguration configuration)
    {

        var mongoClient = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Product = database.GetCollection<Product>(nameof(Product));
        ProductCategory = database.GetCollection<ProductCategory>(nameof(ProductCategory));
        ProductBrand = database.GetCollection<ProductBrand>(nameof(ProductBrand));
    }

}
