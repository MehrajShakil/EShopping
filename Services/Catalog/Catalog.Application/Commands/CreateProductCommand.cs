using MediatR;

namespace Catalog.Application.Commands;

public sealed class CreateProductCommand : IRequest<bool>
{
    public CreateProductCommand()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Name { get; set; }
}
