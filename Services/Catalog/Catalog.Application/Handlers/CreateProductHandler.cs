using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class CreateProductHandler(IProductRepositories repositories, IMapper mapper) : IRequestHandler<CreateProductCommand, bool>
{
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);
        await repositories.CreateProduct(product);
        return true;
    }
}
