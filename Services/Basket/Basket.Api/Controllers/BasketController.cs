using System.Runtime.InteropServices;
using Basket.Application.Commands;
using Basket.Application.GrpcServices;
using Basket.Application.Queries;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repository;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

public class BasketController : BaseController
{
    private readonly IMediator mediator;
    private readonly IServiceProvider services;
    private readonly DiscountGrpcService _discountGrpcService;
    private readonly IPublishEndpoint publishEndpoint;

    public BasketController(IMediator mediator, IServiceProvider services, DiscountGrpcService discountGrpcService, IPublishEndpoint publishEndpoint)
    {
        this.mediator = mediator;
        this.services = services;
        _discountGrpcService = discountGrpcService;
        this.publishEndpoint = publishEndpoint;
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

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout(BasketCheckout checkout)
    {
        var query = new GetBasketByEmailQuery(checkout.Email);
        var basket = await mediator.Send(query);
        
        if(basket is null)
        {
            return BadRequest();
        }

        var basketCheckoutEvent = new BasketCheckoutEvent();
        basketCheckoutEvent.TotalPrice = (decimal)basket.TotalPrice;

        /// event publish to broker.
        
        await publishEndpoint.Publish(basketCheckoutEvent);

        /// now need to remove the basket from redis.
        
        var deleteQuery = new DeleteShoppingCartCommand(checkout.Email);
        await mediator.Send(deleteQuery);

        return Accepted();
    }

}
