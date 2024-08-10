using CarfyEnvios.Communication.Request.Pedido.Coleta;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.Coleta.AdicionarItemColeta;
public class AdicionarItemNaColetaUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string pedidoId, string coletaId, AdicionarItemNaColetaRequest request)
    {
        var pedido = await pedidoRepository.GetByIdAsync(pedidoId);

        if (pedido is null)
            throw new NotFoundException("Pedido não encontrado");

        var coleta = pedido.Coletas.FirstOrDefault(c => c.Id == coletaId);

        if (coleta is null)
            throw new NotFoundException("Coleta não encontrada");

        if (pedido.Coletas.Any(c => c.Itens.Contains(request.ItemId)))
            throw new BusinessException("Item já existe em outra coleta");

        await pedidoRepository.AdicionarItemNaColetaAsync(pedido.Id, coleta.Id, request.ItemId);
    }

}
