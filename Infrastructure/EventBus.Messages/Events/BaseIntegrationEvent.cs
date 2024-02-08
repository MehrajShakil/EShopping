namespace EventBus.Messages.Events;

public class BaseIntegrationEvent
{
    public string CorelationId { get; set; }
    public DateTime CreateDate { get; set; }

    public BaseIntegrationEvent()
    {
        CorelationId = Guid.NewGuid().ToString();
        CreateDate = DateTime.UtcNow;
    }

    public BaseIntegrationEvent(string corelationId, DateTime createDate)
    {
        CorelationId = corelationId;
        CreateDate = createDate;
    }
}
