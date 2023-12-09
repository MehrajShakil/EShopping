using Catalog.Core.Entities;
using Catalog.Core.Pagination;

namespace Catalog.Core.Repositories;

public interface IProductTypeRepository
{
    Task<PaginatedResponse<ProductType>> GetAllTypesAsync(PageItemRequest request);
}
