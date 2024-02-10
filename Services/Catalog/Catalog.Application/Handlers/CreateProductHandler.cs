using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Constants;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class CreateProductHandler(IProductRepositories repositories, IMapper mapper) : IRequestHandler<CreateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {   
        var product = mapper.Map<Product>(request);
        product.Id = Guid.NewGuid().ToString();
        await repositories.CreateProduct(product);
        request.Quantity--;
        if(request.Quantity > 0)
        {
            await Handle(request, cancellationToken);
        }
        var response = request.CreateResponse();
        response.StatusCode = StatusCode.Success;
        // response.SuccessfulMessage = $"Product: {response.Name}, of Brand: {response.Brand.Name} Created Successfully!";
        return response;
    }
}
