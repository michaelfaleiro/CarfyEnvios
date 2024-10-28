namespace CarfyEnvios.Core.Response;
public class TrackingEvent
{
    public DateTime EventDateTime { get; set; }
    public string EventLocation { get; set; }
    public string EventDescription { get; set; }
    public string EventType { get; set; }
    public DateTime LimitedDate { get; set; }
}
