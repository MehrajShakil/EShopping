namespace Catalog.Core.Entities;
public class BaseEntity
{
    public required string Id { get; set; }
    public virtual string GetId() => Id;
}
