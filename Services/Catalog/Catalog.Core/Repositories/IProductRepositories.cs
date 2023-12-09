using Catalog.Core.Entities;
using Catalog.Core.Pagination;
using Catalog.Core.Responses;

namespace Catalog.Core.Repositories;

public interface IProductRepositories
{
    public Task<Product> GetProductByIdAsync(string id);
    public Task<bool> UpdateProduct(Product product);
    Task<ProductDeleteResponse> DeleteProductByIdAsync(string id);
    Task<PaginatedResponse<Product>> GetProductsAsync(PageItemRequest request);

    /// <summary>
    /// This method is bit faster. Why?
    /// we use update builder to update the particular fileds.
    /// In, this approach we won't need to get the existings document and then update the document.
    /// we apply a filter to to get those document and apply update definitions that is those particular field that has to be updated.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fields"></param>
    /// <returns></returns>
    Task<bool> UpdateProduct(string id, Dictionary<string, object> fields);

    Task CreateProduct(Product product);
}
