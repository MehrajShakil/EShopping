namespace Common.Core.Interfaces;
public interface IAppStartupEvent
{
    Task HandleAsync();
}
