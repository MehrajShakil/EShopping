using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Constants;
using Catalog.Core.Pagination;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllProductsQueryHandler(IProductRepositories repositories, IMapper mapper) : IRequestHandler<GetAllProductsQuery, PaginatedResponse<ProductResponse>>
{
    public async Task<PaginatedResponse<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await repositories.GetProductsAsync(request.request);

        var products = new PaginatedResponse<ProductResponse>
        {
            Items = mapper.Map<List<ProductResponse>>(response.Items),
        };

        products.StatusCode = StatusCode.Success;

        return products;
    }
}
