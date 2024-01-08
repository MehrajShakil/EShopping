namespace Basket.Core.Entities;

public abstract class BaseEntity
{
    public string Id { get; set; }
    public abstract string GetId();
}
