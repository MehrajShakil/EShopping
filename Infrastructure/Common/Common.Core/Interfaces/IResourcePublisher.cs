namespace Common.Core.Interfaces;

public interface IResourcePublisher
{
    public bool Enabled { get; }
    Task PublishAsync();
}
