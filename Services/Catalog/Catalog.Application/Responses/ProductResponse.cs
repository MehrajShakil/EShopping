using Catalog.Core.Responses;

namespace Catalog.Application.Responses;

public class ProductResponse : ResponseBase
{
    public string Name { get; set; }
    public string BrandName { get; set; }
}
