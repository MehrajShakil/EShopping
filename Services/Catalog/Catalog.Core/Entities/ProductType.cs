using System.ComponentModel.DataAnnotations;

namespace Catalog.Core.Entities;

public class ProductType
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "No Product Type Found")]
    public string Name { get; set; }
    public string SubTypeName { get; set; }
}