using AutoMapper;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public GetDiscountQueryHandler(ICouponRepository discountRepository, IMapper mapper)
    {
        _couponRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _couponRepository.GetByProductNameAsync(request.ProductName);
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with product name = {request.ProductName} not found"));
        }

        var mappedCoupon = _mapper.Map<CouponModel>(coupon);
        return mappedCoupon;
    }
}
