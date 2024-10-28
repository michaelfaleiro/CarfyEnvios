namespace CarfyEnvios.Communication.Response.Rastreio;
public class TrackingResponseJson
{
    public DateTime ExpectedDate { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public string ServiceDescription { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public List<TrackingEventResponseJson> TrackingEvents { get; set; } = [];
    public string Carrier { get; set; } = string.Empty;
    public string CarrierCode { get; set; } = string.Empty;
    public DateTime ShippingDate { get; set; }
    public int MaxDeliveryTime { get; set; }
    public DateTime? EstimatedDate { get; set; }
    public int? Attempt { get; set; }
    public string Destination { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public string PackageInfo { get; set; } = string.Empty;
    public string TrackingUrl { get; set; } = string.Empty;
}
