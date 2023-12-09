using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByNameQueryHandler(IProductRepositories repository, IMapper mapper) : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
{
    public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var products  = await repository.GetProductsByNameAsync(request.Name);
        var response = mapper.Map<IList<ProductResponse>>(products);
        return response;
    }
}
