using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.ItensPedido.DeleteItem;

public class DeleteItemPedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string id, string itemId)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id);

        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado");

        var itemPedido = pedido.Itens.FirstOrDefault(i => i.Id == itemId);

        if (itemPedido == null)
            throw new NotFoundException("Item não encontrado");

        var itemColeta = pedido.Coletas.Any(c => c.Itens.Any(i => i.Id == itemId));

        if (itemColeta)
            throw new BusinessException("Remova o item da coleta antes de excluir");
        

        pedido.Itens.Remove(itemPedido);

        await pedidoRepository.UpdateAsync(pedido);
    }

}