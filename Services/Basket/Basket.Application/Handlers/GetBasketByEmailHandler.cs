using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class GetBasketByEmailHandler : IRequestHandler<GetBasketByEmailQuery, ShoppingCartResponse>
{
    private readonly IBasketRepository basketRepository;
    private readonly IMapper mapper;

    public GetBasketByEmailHandler(IBasketRepository basketRepository, IMapper mapper)
    {
        this.basketRepository = basketRepository;
        this.mapper = mapper;
    }

    public async Task<ShoppingCartResponse> Handle(GetBasketByEmailQuery request, CancellationToken cancellationToken)
    {
        var shoppingcart =  await basketRepository.GetBasketByEmailAsync(request.Email);
        var response = mapper.Map<ShoppingCartResponse>(shoppingcart);
        return response;
    }
}
