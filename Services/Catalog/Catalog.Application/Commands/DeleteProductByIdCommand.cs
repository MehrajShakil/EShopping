using Catalog.Application.Responses;
using Catalog.Core.Responses;
using MediatR;

namespace Catalog.Application.Commands;

public sealed class DeleteProductByIdCommand(string id) : IRequest<ProductDeleteResponse>
{
    public string Id { get; set; } = id;
}
