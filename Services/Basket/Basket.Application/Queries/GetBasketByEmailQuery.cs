using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetBasketByEmailQuery(string email) : IRequest<ShoppingCartResponse>
{
    public string Email { get; set; } = email;
}
