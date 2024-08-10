using CarfyEnvios.Communication.Response;
using CarfyEnvios.Communication.Response.Cliente;
using CarfyEnvios.Communication.Response.ItemPedido;
using CarfyEnvios.Communication.Response.Pedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Core.Models;

namespace CarfyEnvios.Application.UseCase.Pedidos.GetAll;

public class GetAllPedidosUseCase(IPedidoRepository pedidoRepository)
{
    public async Task<PagedResponse<ResponsePedidoJson>> ExecuteAsync(int pageNumber, int pageSize)
    {
        var result = await pedidoRepository.GetAllAsync(pageNumber, pageSize);

        var pedidos = result.Data.Select(pedido => new ResponsePedidoJson
        {
            Id = pedido.Id,
            Cliente = new ResponseClienteJson
            {
                Id = pedido.Cliente.Id,
                Nome = pedido.Cliente.Nome,
                Email = pedido.Cliente.Email,
                Telefone = pedido.Cliente.Telefone,
            },
            Itens = pedido.Itens.Select(item => new ResponseItemPedidoJson
            {
                Id = item.Id,
                Nome = item.Nome,
                Sku = item.Sku,
                Fabricante = item.Fabricante,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario
            }).ToList(),
            NumeroPedido = pedido.NumeroPedido,
            DataPedido = pedido.DataPedido,
            NumeroNfe = pedido.NumeroNfe,
            LinkNfe = pedido.LinkNfe,
            DataEmissaoNfe = pedido.DataEmissaoNfe,
            Observacao = pedido.Observacao,
            Status = pedido.Status,
            CreatedAt = pedido.CreatedAt,
            UpdatedAt = pedido.UpdatedAt
        }).ToList();

        return new PagedResponse<ResponsePedidoJson>
        {
            TotalCount = result.TotalCount,
            CurrentPage = pageNumber,
            PageSize = pageSize,
            Data = pedidos
        };
    }
}