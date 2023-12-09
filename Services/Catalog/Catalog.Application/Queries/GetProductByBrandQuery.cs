using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed class GetProductByBrandQuery(string brandName) : IRequest<ProductResponse>
{
    public string BrandName { get; set; } = brandName;
}
