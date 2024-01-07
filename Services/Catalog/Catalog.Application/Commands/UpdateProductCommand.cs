using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands;

public sealed class UpdateProductCommand : CreateProductCommand, IRequest<ProductResponse>
{
    public string Id { get; set; }
}
