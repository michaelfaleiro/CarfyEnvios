using CarfyEnvios.Communication.Request.Pedido.Rastreio;
using CarfyEnvios.Communication.Response.Rastreio;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Core.Response;

namespace CarfyEnvios.Application.UseCase.Pedidos.Rastreio;
public class RastreioFrenetUseCase(IRastreioRepository repository)
{
    private readonly IRastreioRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));


    public async Task<TrackingResponse> GetTrackingInfoAsync(RastreioRequest request)
    {
        var shippingServiceCode = "03220";

        try
        {
            var result = await _repository.GetTrackingInfoAsync(shippingServiceCode, request.TrackingNumber);


            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter informações de rastreamento da Frenet", ex);
        }
        // Chama o repositório para obter as informações de rastreamento da Frenet

        // Mapeia os dados recebidos para a classe de resposta

    }

}
