using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries;

public class GetOrderListQuery : IRequest<List<OrderResponse>>
{
    public string Email { get; set; }
    public GetOrderListQuery(string email)
    {
        Email = email;
    }
}
