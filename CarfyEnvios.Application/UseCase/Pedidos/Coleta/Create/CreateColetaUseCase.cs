using CarfyEnvios.Communication.Request.Pedido.Coleta;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.Coleta.Create;
public class CreateColetaUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string pedidoId, CreateColetaRequest request)
    {
        var pedido = await pedidoRepository.GetByIdAsync(pedidoId);

        if (pedido is null)
            throw new NotFoundException("Pedido não encontrado");

        request.DataEnvio = string.IsNullOrEmpty(request.DataEnvio?.ToString())
            ? null : request.DataEnvio;
        request.DataPrevisaoEntrega = string.IsNullOrEmpty(request.DataPrevisaoEntrega?.ToString())
            ? null : request.DataPrevisaoEntrega;
        request.DataEntregaFinalizada = string.IsNullOrEmpty(request.DataEntregaFinalizada?.ToString())
            ? null : request.DataEntregaFinalizada;

        var coleta = new Core.Entidades.Coleta
        {
            PontoDeColeta = request.PontoDeColeta,
            Transportadora = request.Transportadora,
            TipoTransporte = request.TipoTransporte,
            StatusColeta = request.StatusColeta,
            LinkAwb = request.LinkAwb,
            LinkRomaneio = request.LinkRomaneio,
            LinkCartaCorrecao = request.LinkCartaCorrecao,
            MedidasEmbalagem = request.MedidasEmbalagem,
            PesoEmbalagem = request.PesoEmbalagem,
            CodigoRastreio = request.CodigoRastreio,
            DataEnvio = request.DataEnvio ?? null,
            DataPrevisaoEntrega = request.DataPrevisaoEntrega ?? null,
            DataEntregaFinalizada = request.DataEntregaFinalizada ?? null
        };

        await pedidoRepository.AdicionarColetaAsync(pedidoId, coleta);

    }

}
