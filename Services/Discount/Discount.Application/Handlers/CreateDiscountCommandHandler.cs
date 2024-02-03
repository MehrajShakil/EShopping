using AutoMapper;
using Discount.Application.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
{

    private readonly IMapper _mapper;
    private readonly ICouponRepository _couponRepository;

    public CreateDiscountCommandHandler(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = _mapper.Map<Coupon>(request);
        await _couponRepository.CreateAsync(coupon);
        var mappedCoupon = _mapper.Map<CouponModel>(coupon);
        return mappedCoupon;
    }
}
