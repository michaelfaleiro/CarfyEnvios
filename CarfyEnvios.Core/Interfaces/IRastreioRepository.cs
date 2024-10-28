using CarfyEnvios.Core.Response;

namespace CarfyEnvios.Core.Interfaces;
public interface IRastreioRepository
{
    Task<TrackingResponse> GetTrackingInfoAsync(string shippingServiceCode, string trackingNumber);
}
