using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public sealed class GetProductByBrandQueryHandler(IProductRepositories repository, IMapper mapper) : IRequestHandler<GetProductByBrandQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetProductByBrandNameAsync(request.BrandName);
        var response = mapper.Map<ProductResponse>(product);
        return response;
    }
}
