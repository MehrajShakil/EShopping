using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, bool>
{
    private readonly IBasketRepository basketRepository;

    public DeleteShoppingCartCommandHandler(IBasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }

    public async Task<bool> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasketAsync(request.Email);
        return true;
    }
}
