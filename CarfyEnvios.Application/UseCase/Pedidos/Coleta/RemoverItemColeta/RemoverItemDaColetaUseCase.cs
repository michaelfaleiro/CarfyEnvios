using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.Coleta.RemoverItemColeta;
public class RemoverItemDaColetaUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string pedidoId, string coletaId, string itemId)
    {
        var pedido = await pedidoRepository.GetByIdAsync(pedidoId);

        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado");

        var item = pedido.Coletas.FirstOrDefault(i => i.Id == coletaId);

        if (item == null)
            throw new NotFoundException("Coleta não encontrada");

        if (!item.Itens.Any(i => i.Id == itemId))
            throw new NotFoundException("Item não encontrado na coleta");

        await pedidoRepository.RemoverItemDaColetaAsync(pedidoId, coletaId, itemId);
    }
}
