using AutoMapper;
using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Extensions;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderExist = await _orderRepository.GetItemByIdAsync(request.Id);
        if(orderExist is null)
        {
            throw new OrderNotExistException(nameof(Order), request.Id);
        }

        var mappedOrder = _mapper.Map<Order>(request);

        await _orderRepository.UpdateAsync(mappedOrder);

    }
}
