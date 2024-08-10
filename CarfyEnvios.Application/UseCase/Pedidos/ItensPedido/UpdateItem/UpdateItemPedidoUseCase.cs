using CarfyEnvios.Communication.Request.Pedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.ItensPedido.UpdateItem;

public class UpdateItemPedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string id, string itemId, AdicionarItemPedidoRequest item)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id);

        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado");

        var itemPedido = pedido.Itens.FirstOrDefault(i => i.Id == itemId);

        if (itemPedido == null)
            throw new NotFoundException("Item não encontrado");

        itemPedido.Nome = item.Nome;
        itemPedido.Sku = item.Sku;
        itemPedido.Fabricante = item.Fabricante;
        itemPedido.Quantidade = item.Quantidade;
        itemPedido.ValorUnitario = item.ValorUnitario;

        await pedidoRepository.UpdateAsync(pedido);
    }

}