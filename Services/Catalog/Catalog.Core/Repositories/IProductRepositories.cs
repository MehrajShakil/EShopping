using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepositories
{
    public Task<IEnumerable<Product>> GetProductByIdAsync(string id);
    public Task<IEnumerable<Product>> GetProductByBrandNameAsync(string name);
    public Task<IEnumerable<Product>> GetProductByTypeNameAsync(string name);
    public Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProductByIdAsync(string id);
}
