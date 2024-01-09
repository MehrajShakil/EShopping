using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands;

public class CreateShoppingCartCommand : IRequest
{
    public CreateShoppingCartCommand(string email)
    {
        Email = email;
        Items = [];
    }

    public List<ShoppingCartItem> Items { get; set; }

    public string Email { get; set; }
}
