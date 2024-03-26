namespace Common.Core.Logger;

public interface ILogger
{
    public void Info(Type type, string message);
    public void Warn(Type type, string message);
    public void Error(Type type, string message);
}
