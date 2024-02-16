
using MediatR;

namespace Catalog.Application.Commands;

public class UpdateProductCategoryCommand : CreateProductCategoryCommand, IRequest
{
    public string Id { get; set; }
    public UpdateProductCategoryCommand(string name, string parentId) : base(name, parentId)
    {
    }
}
