using Catalog.Core.Responses;

namespace Catalog.Core.Pagination;

public sealed class PaginatedResponse<T> : ResponseBase
{
    public int PageIndex { get; set; }
    public int TotalCount { get; set; }
    public required List<T> Items { get; set; }
}
