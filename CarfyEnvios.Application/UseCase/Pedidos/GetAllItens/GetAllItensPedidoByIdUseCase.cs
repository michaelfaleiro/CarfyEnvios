using CarfyEnvios.Communication.Response.ItemPedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Core.Models;

namespace CarfyEnvios.Application.UseCase.Pedidos.GetAllItens;

public class GetAllItensPedidoByIdUseCase(IPedidoRepository pedidoRepository)
{
    public async Task<PagedResult<ResponseItemPedidoJson>> ExecuteAsync(string pedidoId)
    {
        var response = await pedidoRepository.GetItensDoPedidoAsync(pedidoId);
        
        return new PagedResult<ResponseItemPedidoJson>
        {
            Data = response.Select(item => new ResponseItemPedidoJson
            {
                Id = item.Id,
                Nome = item.Nome,
                Sku = item.Sku,
                Fabricante = item.Fabricante,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario
            }).ToList()
        };
    }
}