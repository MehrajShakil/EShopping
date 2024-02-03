using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Api.GrpcServices;

public class DiscountGrpcService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IMediator _mediator;
    public DiscountGrpcService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {

        var command = new CreateDiscountCommand(request.Coupon.Productname, request.Coupon.Description, request.Coupon.Amount);
        var coupon = await _mediator.Send(command);
        return coupon;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var command = new UpdateDiscountCommand(request.Coupon.Id, request.Coupon.Productname, request.Coupon.Description, request.Coupon.Amount);
        var coupon = await _mediator.Send(command);
        return coupon;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var command = new DeleteDiscountCommand(request.Id);
        var deleted = await _mediator.Send(command);
        var response = new DeleteDiscountResponse
        {
            Success = deleted,
        };
        return response;
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var query = new GetDiscountQuery(request.ProductName);
        var couponModel = await _mediator.Send(query);
        return couponModel;
    }

}
