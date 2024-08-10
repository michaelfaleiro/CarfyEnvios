using CarfyEnvios.Communication.Request.Pedido.Coleta;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.Coleta.Update;
public class UpdateColetaItemUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string pedidoId, string coletaId, UpdateColetaRequest request)
    {
        var pedido = await pedidoRepository.GetByIdAsync(pedidoId);

        if (pedido is null)
            throw new NotFoundException("Pedido não encontrado");

        var coleta = pedido.Coletas.FirstOrDefault(c => c.Id == coletaId);

        if (coleta is null)
            throw new NotFoundException("Coleta não encontrada");


        coleta.PontoDeColeta = request.PontoDeColeta;
        coleta.Transportadora = request.Transportadora;
        coleta.TipoTransporte = request.TipoTransporte;
        coleta.StatusColeta = request.StatusColeta;
        coleta.LinkAwb = request.LinkAwb;
        coleta.LinkRomaneio = request.LinkRomaneio;
        coleta.LinkCartaCorrecao = request.LinkCartaCorrecao;
        coleta.MedidasEmbalagem = request.MedidasEmbalagem;
        coleta.PesoEmbalagem = request.PesoEmbalagem;
        coleta.CodigoRastreio = request.CodigoRastreio;
        coleta.DataEnvio = request.DataEnvio;
        coleta.DataPrevisaoEntrega = request.DataPrevisaoEntrega ?? null;
        coleta.DataEntregaFinalizada = request.DataEntregaFinalizada ?? null;

        await pedidoRepository.AtualizarColetaAsync(pedidoId, coletaId, coleta);
    }
}
