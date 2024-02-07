﻿using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<OrderResponse>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByEmailAsync(request.Email);

        var mappedOrders = _mapper.Map<List<OrderResponse>>(orders) ?? Enumerable.Empty<OrderResponse>();

        return mappedOrders
            .ToList();
    }
}
