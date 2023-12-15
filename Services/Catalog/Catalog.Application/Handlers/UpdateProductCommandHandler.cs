using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductCommandHandler(IProductRepositories repositories, IMapper mapper) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        var product = mapper.Map<Product>(request);

        var productUpdated = await repositories.UpdateProduct(product);
        return productUpdated;
    }
}
