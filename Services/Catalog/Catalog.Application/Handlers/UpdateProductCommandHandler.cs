using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Constants;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductCommandHandler(IProductRepositories repositories, IMapper mapper) : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        var product = mapper.Map<Product>(request);

        var productUpdated = await repositories.UpdateProduct(product);
        var response = request.CreateResponse();
        response.StatusCode = StatusCode.Success;
        response.SuccessfulMessage = $"Product: {response.Name}, of Brand: {response.BrandName} Created Successfully!";
        return response;
    }
}
