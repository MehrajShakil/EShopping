using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByIdQueryHandler(IProductRepositories productRepositories, IMapper mapper) :
    IRequestHandler<GetProductByIdQuery, ProductResponse>
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

        ProductResponse productResponse = new();
        var product = await productRepositories.GetProductByIdAsync(request.Id);

        
        if (product is null)
        {
            productResponse.StatusCode = 404; /// Status Code for not found.
            productResponse.Messages.Add("Product is not found");
            return productResponse;
        }

        var response = mapper.Map<ProductResponse>(product);
        return response;
    }
}
