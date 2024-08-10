using CarfyEnvios.Communication.Request.Pedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.ItensPedido.AdicionarItem;

public class AdicionarItemPedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task ExecuteAsync(string pedidoId, AdicionarItemPedidoRequest request)
    {
        var pedido = await pedidoRepository.GetByIdAsync(pedidoId);

        if (pedido is null)
            throw new NotFoundException("Pedido não encotrado");


        var itemPedido = new Core.Entidades.ItemPedido
        {
            Nome = request.Nome,
            Sku = request.Sku,
            Fabricante = request.Fabricante,
            Quantidade = request.Quantidade,
            ValorUnitario = request.ValorUnitario,
        };

        await pedidoRepository.AdicionarItemNoPedidoAsync(pedidoId, itemPedido);
    }

}