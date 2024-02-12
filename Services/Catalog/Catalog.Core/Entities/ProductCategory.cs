using System.ComponentModel.DataAnnotations;

namespace Catalog.Core.Entities;  

public class ProductCategory : BaseEntity
{
    public string Name { get; set; }
    public string ParentId { get; set; } 
}