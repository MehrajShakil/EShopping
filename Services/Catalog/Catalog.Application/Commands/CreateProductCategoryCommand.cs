using Catalog.Application.Responses;
using MediatR;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.Application.Commands;

public class CreateProductCategoryCommand : IRequest<ProductCategoryResponse>
{
    public string Name { get; set; }
    public string ParentId { get; set; }

    public CreateProductCategoryCommand(string name, string parentId)
    {
        Name = name;
        ParentId = parentId;
    }
}
