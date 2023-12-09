using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using Catalog.Core.Responses;
using MediatR;

namespace Catalog.Application.Handlers;

public sealed class DeleteProductByIdCommandHandler(IProductRepositories repositories) : IRequestHandler<DeleteProductByIdCommand, ProductDeleteResponse>
{
    public async Task<ProductDeleteResponse> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var deleteResponse = await repositories.DeleteProductByIdAsync(request.Id);
        return deleteResponse;
    }
}
