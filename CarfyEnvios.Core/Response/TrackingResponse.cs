namespace CarfyEnvios.Core.Response;
public class TrackingResponse
{
    public string TrackingNumber { get; set; }
    public string ServiceDescription { get; set; }
    public string TrackingUrl { get; set; }
    public List<TrackingEvent> TrackingEvents { get; set; }
    public DateTime ExpectedDate { get; set; }
}
