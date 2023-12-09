using Catalog.Application.Responses;
using Catalog.Core.Pagination;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllProductsQuery(PageItemRequest request) : IRequest<PaginatedResponse<ProductResponse>>
{
    public PageItemRequest request { get; set; } = request;
}
