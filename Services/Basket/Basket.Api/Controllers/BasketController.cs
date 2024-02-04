using Basket.Application.Commands;
using Basket.Application.GrpcServices;
using Basket.Application.Queries;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

public class BasketController : BaseController
{
    private readonly IMediator mediator;
    private readonly IServiceProvider services;
    private readonly DiscountGrpcService _discountGrpcService;

    public BasketController(IMediator mediator, IServiceProvider services, DiscountGrpcService discountGrpcService)
    {
        this.mediator = mediator;
        this.services = services;
        _discountGrpcService = discountGrpcService;
    }

    [HttpPost("CreateBasket")]
    public async Task<IActionResult> CreateBasket(CreateShoppingCartCommand command)
    {
        foreach (var item in command.Items)
        {
            var coupon = await _discountGrpcService.GetDiscountAsync(item.ProductName);
            item.Price -= coupon.Amount;
        }

        await mediator.Send(command);
        return Ok();
    }

    [HttpPost("GetBasket")]
    public async Task<IActionResult> GetBasket(string email)
    {
        var query = new GetBasketByEmailQuery(email);
        var response =  await mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("DeleteBasket")]
    public async Task<IActionResult> DeleteBasket(string email)
    {
        var command = new DeleteShoppingCartCommand(email);
        await mediator.Send(command);
        return Ok();
    }

}
