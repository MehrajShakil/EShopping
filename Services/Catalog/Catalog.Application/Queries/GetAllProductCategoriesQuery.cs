using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllProductCategoriesQuery : IRequest<IList<ProductCategoryResponse>>
{
}
