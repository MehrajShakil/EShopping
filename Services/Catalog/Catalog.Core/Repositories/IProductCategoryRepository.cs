using Catalog.Core.Entities;
using Catalog.Core.Pagination;

namespace Catalog.Core.Repositories;

public interface IProductCategoryRepository
{
    Task<ProductCategory> CreateProductCategoryAsync(ProductCategory category);
    Task<IList<ProductCategory>> GetAllCategoriesAsync();
    Task<PaginatedResponse<ProductCategory>> GetAllCategoriesAsync(PageItemRequest request);
    Task<ProductCategory> GetProductCategoryByIdAsync(string id);
    Task<ProductCategory> GetProductCategoryByNameAsync(string name);
}
