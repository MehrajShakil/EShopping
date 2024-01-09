using MediatR;

namespace Basket.Application.Commands;

public class DeleteShoppingCartCommand : IRequest<bool>
{
    public DeleteShoppingCartCommand(string email)
    {
        Email = email;
    }
    public string Email { get; set; }
}
