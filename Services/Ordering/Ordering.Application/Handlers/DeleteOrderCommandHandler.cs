using MediatR;
using Ordering.Application.Commands;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetItemByIdAsync(request.Id);
        if(existingOrder is not null)
        {
            await _orderRepository.DeleteAsync(existingOrder);
        }
    }
}
