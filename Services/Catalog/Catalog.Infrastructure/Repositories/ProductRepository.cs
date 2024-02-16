using Catalog.Core.Entities;
using Catalog.Core.Pagination;
using Catalog.Core.Repositories;
using Catalog.Core.Responses;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepositories, IProductBrandRepository, IProductCategoryRepository
{
    private readonly ICatalogContext context;

    public ProductRepository(ICatalogContext Context)
    {
        context = Context;
    }

    public async Task<ProductDeleteResponse> DeleteProductByIdAsync(string id)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Eq<string>(p => p.Id, id);
        var deleteResult = await context.Product.DeleteOneAsync(filter);

        ProductDeleteResponse productDeleteResponse = new();

        return productDeleteResponse;
    }
    public async Task<PaginatedResponse<Product>> GetProductsAsync(PageItemRequest request)
    {
        var items = await context
            .Product
            .Find(product => true)
            .Skip(request.PageSize * (request.PageIndex-1))
            .Limit(request.PageSize)
            .ToListAsync();

        var totalItems = await context.Product.EstimatedDocumentCountAsync();

        var pageResponse = new PaginatedResponse<Product>()
        {
            PageIndex = request.PageIndex,
            Items = items,
            TotalCount = totalItems
        };

        return pageResponse;
    }
    public async Task<PaginatedResponse<ProductBrand>> GetAllBrandsAsync(PageItemRequest request)
    {
        var items = await context
            .ProductBrand
            .Find(brand => true)
            .Skip(request.PageSize * (request.PageIndex - 1))
            .Limit(request.PageSize)
            .ToListAsync();

        var pageResponse = new PaginatedResponse<ProductBrand>()
        {
            PageIndex = request.PageIndex,
            Items = items
        };

        return pageResponse;
    }
    public async Task<PaginatedResponse<ProductCategory>> GetAllCategoriesAsync(PageItemRequest request)
    {
        var items = await context
            .ProductCategory
            .Find(brand => true)
            .Skip(request.PageSize * (request.PageIndex - 1))
            .Limit(request.PageSize)
            .ToListAsync();

        var pageResponse = new PaginatedResponse<ProductCategory>()
        {
            PageIndex = request.PageIndex,
            Items = items
        };

        return pageResponse;
    }

    public async Task<ProductCategory> GetProductCategoryByIdAsync(string id)
    {
        var item = await context.ProductCategory.FindAsync(category => category.Id == id);
        return item.FirstOrDefault();
    }

    public async Task<ProductCategory> GetProductCategoryByNameAsync(string name)
    {
        var item = await context.ProductCategory.FindAsync(category => category.Name == $"$regex: /{name}/i");
        return item.FirstOrDefault();
    }

    public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategory category)
    {
        await context.ProductCategory.InsertOneAsync(category);
        return category;
    }

    public async Task UpdateProductCategoryAsync(ProductCategory category)
    {
        await context.ProductCategory
            .ReplaceOneAsync(category => category.Id == category.Id, category);
    }

    public async Task<IList<ProductCategory>> GetAllCategoriesAsync()
    {
        var items = await context.ProductCategory.Find(category => true).ToListAsync();
        return items;
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Eq(product => product.Id, id);
        var item = await context
            .Product
            .Find(filter)
            .FirstOrDefaultAsync();
        return item;
    }
    public Task<bool> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> UpdateProduct(string id, Dictionary<string, object> fields)
    {

        var updateFields = new List<UpdateDefinition<Product>>();

        var builder = Builders<Product>.Filter;
        var filter = builder.Eq(product => product.Id, id);

        var updateBuilder = Builders<Product>.Update;

        foreach(var field in fields)
        {
            updateFields.Add(updateBuilder.Set(field.Key, field.Value));
        }

        var updateDefinition = updateBuilder.Combine(updateFields);


        var updatedResponse = await context
            .Product
            .UpdateOneAsync(filter, updateDefinition);

        return updatedResponse.IsAcknowledged && updatedResponse.IsModifiedCountAvailable;
    }

    public async Task CreateProduct(Product product)
    {
        await context.Product.InsertOneAsync(product);
    }
}
