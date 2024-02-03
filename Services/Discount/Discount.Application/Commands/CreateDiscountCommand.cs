﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Commands;

public class CreateDiscountCommand : IRequest<CouponModel>
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }

    public CreateDiscountCommand(string productName, string description, int amount)
    {
        ProductName = productName;
        Description = description;
        Amount = amount;
    }

}
