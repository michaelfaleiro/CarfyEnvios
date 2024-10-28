namespace CarfyEnvios.Communication.Response.Rastreio;
public class TrackingEventResponseJson
{
    public DateTime SortDateTime { get; set; }
    public DateTime EventDateTime { get; set; }
    public string EventLocation { get; set; } = string.Empty;
    public string EventDescription { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
    public string EventStatus { get; set; } = string.Empty;
    public string CarrierEvent { get; set; } = string.Empty;
    public string CarrierStatus { get; set; } = string.Empty;
    public string AgencyInfo { get; set; } = string.Empty;  
    public DateTime LimitedDate { get; set; }
}
