using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllProductCategoriesHandler(IProductCategoryRepository repositories, IMapper mapper) : IRequestHandler<GetAllProductCategoriesQuery, IList<ProductCategoryResponse>>
{
    public async Task<IList<ProductCategoryResponse>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        var productTypes = await repositories.GetAllCategoriesAsync();
        var response = mapper.Map<IList<ProductCategoryResponse>>(productTypes);
        return response;
    }
}
