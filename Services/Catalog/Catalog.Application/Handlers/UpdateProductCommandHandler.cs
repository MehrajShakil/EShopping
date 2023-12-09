using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductCommandHandler(IProductRepositories repositories) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productUpdated = await repositories.UpdateProduct(new Product()
        {
            Name = "",
            Brand = null,
            Type = null
        });
        return productUpdated;
    }
}
