using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand>
{
    private readonly IBasketRepository basketRepository;
    private readonly IMapper mapper;

    public CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper)
    {
        this.basketRepository = basketRepository;
        this.mapper = mapper;
    }
    public async Task Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {

        var shoppingCart = new ShoppingCart
        {
            Email = request.Email,
            Items = request.Items,
        };

        await basketRepository.UpdateBasketAsync(shoppingCart);
    }
}
