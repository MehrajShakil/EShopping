﻿using Catalog.Core.Entities;
using Catalog.Core.Responses;

namespace Catalog.Application.Responses;

public class ProductResponse : ResponseBase
{

    public  string Name { get; set; }
    public string ProductCode { get; set; }
    public  ProductBrand Brand { get; set; }
    public  ProductType Type { get; set; }
    public decimal Price { get; set; }
}
