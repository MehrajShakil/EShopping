namespace Catalog.Core.Pagination;

public sealed class PageItemRequest
{
    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}
