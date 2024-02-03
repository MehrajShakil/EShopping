using AutoMapper;
using Discount.Application.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers;

public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, CouponModel>
{

    private readonly IMapper _mapper;
    private readonly ICouponRepository _couponRepository;

    public UpdateDiscountCommandHandler(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = _mapper.Map<Coupon>(request);
        var savedCoupon = await _couponRepository.UpdateAsync(coupon);
        var mappedCoupon = _mapper.Map<CouponModel>(savedCoupon);
        return mappedCoupon;
    }
}
