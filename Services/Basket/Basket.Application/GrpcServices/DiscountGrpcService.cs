﻿using Discount.Grpc.Protos;

namespace Basket.Application.GrpcServices;

public class DiscountGrpcService
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

    public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
    {
        _discountProtoServiceClient = discountProtoServiceClient;
    }

    public async Task<CouponModel> GetDiscountAsync(string productName)
    {
        var request = new GetDiscountRequest()
        {
            ProductName = productName
        };
        var coupon = await _discountProtoServiceClient.GetDiscountAsync(request);
        return coupon;
    }

}
