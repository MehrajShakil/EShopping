using MediatR;

namespace Catalog.Application.Commands;

public sealed class UpdateProductCommand : CreateProductCommand, IRequest<bool>
{
    public string Id { get; set; }
}
