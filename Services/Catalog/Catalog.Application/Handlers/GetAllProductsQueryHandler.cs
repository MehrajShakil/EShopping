using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllProductsQueryHandler(IProductRepositories repositories, IMapper mapper) : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
{
    public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repositories.GetProductsAsync();
        var response = mapper.Map<IList<ProductResponse>>(products);
        return response;
    }
}
