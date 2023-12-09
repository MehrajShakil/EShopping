using Catalog.Core.Entities;
using Catalog.Core.Pagination;

namespace Catalog.Core.Repositories;

public interface IProductBrandRepository
{
    Task<PaginatedResponse<ProductBrand>> GetAllBrandsAsync(PageItemRequest request);
}
