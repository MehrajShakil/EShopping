using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Commands;

public class CreateProductCommand : IRequest<ProductResponse>
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "No Product name found!")]
    public string Name { get; set; }
    public ProductBrand Brand { get; set; }
    public ProductType Type { get; set; }

    [Required(ErrorMessage = "No Price found!")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public ProductResponse CreateResponse()
    {
        return new ProductResponse
        {
            Name = Name,
            Brand = Brand,
            Type = Type,
            Price = Price
        };
    }

}
