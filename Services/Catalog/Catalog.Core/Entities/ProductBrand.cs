using System.ComponentModel.DataAnnotations;

namespace Catalog.Core.Entities;

public class ProductBrand  :  BaseEntity
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "No Brand Found")]
    public string Name { get; set; }
    public List<string> ParentCategoryIds { get; set; }
}