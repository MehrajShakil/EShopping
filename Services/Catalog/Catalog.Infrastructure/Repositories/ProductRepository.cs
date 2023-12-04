using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System.Collections;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepositories, IProductBrandRepository, IProductTypeRepository
{
    private readonly ICatalogContext context;

    public ProductRepository(ICatalogContext Context)
    {
        context = Context;
    }

    public async Task<bool> DeleteProductByIdAsync(string id)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Eq<string>(p => p.Id, id);
        var deleteResult = await context.Product.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrandsAsync()
    {
        var brands = await context
            .ProductBrand
            .Find(brand => true)
            .ToListAsync();

        if(brands is null) return Enumerable.Empty<ProductBrand>().ToList();
        return brands;
    }

    public Task<ProductType> GetAllTypes()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByBrandNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByTypeNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
