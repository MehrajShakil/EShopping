using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByIdQueryHandler(IProductRepositories productRepositories, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        /*        var product = productRepositories
                    .GetProductByIdAsync(request.Id)
                    .GetAwaiter()
                    .GetResult()
                    .FirstOrDefault();
            This works synchronously, GetAwaiter blocking the current thread.    
         */

        var product = await productRepositories.GetProductByIdAsync(request.Id);
        var response = mapper.Map<ProductResponse>(product.FirstOrDefault());
        return response;
    }
}
