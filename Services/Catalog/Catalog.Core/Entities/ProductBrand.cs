using System.ComponentModel.DataAnnotations;

namespace Catalog.Core.Entities;

public class ProductBrand
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "No Brand Found")]
    public string Name { get; set; }
}