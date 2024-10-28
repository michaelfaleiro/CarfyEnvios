using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Core.Response;
using System.Text;
using System.Text.Json;

namespace CarfyEnvios.Infra.ApiFrenet;

public class FrenetApiClient : IRastreioRepository
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public FrenetApiClient()
    {
        var baseAddress = new Uri("https://api.frenet.com.br/");
        _httpClient = new HttpClient { BaseAddress = baseAddress };
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("token", "F628E70DR82E1R437ARA1CDRC59C4DF4C55A");

        _jsonOptions = new JsonSerializerOptions();
        _jsonOptions.Converters.Add(new CustomDateTimeConverterExtension());
    }

    public async Task<TrackingResponse> GetTrackingInfoAsync(string shippingServiceCode, string trackingNumber)
    {
        var requestBody = new
        {
            ShippingServiceCode = shippingServiceCode,
            TrackingNumber = trackingNumber,
            InvoiceNumber = "",
            InvoiceSerie = "",
            RecipientDocument = "",
            OrderNumber = ""
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        using var response = await _httpClient.PostAsync("tracking/trackinginfo", content);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TrackingResponse>(responseContent, _jsonOptions) ?? new TrackingResponse();
    }
}
