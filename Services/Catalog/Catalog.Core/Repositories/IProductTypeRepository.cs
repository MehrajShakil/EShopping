using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductTypeRepository
{
    public Task<ProductType> GetAllTypesAsync();
}
