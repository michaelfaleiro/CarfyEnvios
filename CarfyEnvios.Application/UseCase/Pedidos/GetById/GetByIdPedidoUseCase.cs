using CarfyEnvios.Communication.Response;
using CarfyEnvios.Communication.Response.Cliente;
using CarfyEnvios.Communication.Response.Envio;
using CarfyEnvios.Communication.Response.ItemPedido;
using CarfyEnvios.Communication.Response.Pedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.GetById;

public class GetByIdPedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task<Response<ResponsePedidoJson>> ExecuteAsync(string id)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id);

        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado");

        return new Response<ResponsePedidoJson>
        {
            Data = new ResponsePedidoJson
            {
                Id = pedido.Id,
                Cliente = new ResponseClienteJson
                {
                    Id = pedido.Cliente.Id,
                    Nome = pedido.Cliente.Nome,
                    Email = pedido.Cliente.Email,
                    Telefone = pedido.Cliente.Telefone,
                    CreatedAt = pedido.Cliente.CreatedAt,
                    UpdatedAt = pedido.Cliente.UpdatedAt
                },
                Itens = pedido.Itens.Select(item => new ResponseItemPedidoJson
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Sku = item.Sku,
                    Fabricante = item.Fabricante,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    
                }).ToList(),
                Coletas = pedido.Coletas.Select(coleta => new ResponseColetaJson
                {
                    Id = coleta.Id,
                    CodigoRastreio = coleta.CodigoRastreio,
                    DataEnvio = coleta.DataEnvio,
                    DataPrevisaoEntrega = coleta.DataPrevisaoEntrega,
                    DataEntregaFinalizada = coleta.DataEntregaFinalizada,
                    LinkAwb = coleta.LinkAwb,
                    LinkRomaneio = coleta.LinkRomaneio,
                    LinkCartaCorrecao = coleta.LinkCartaCorrecao,
                    MedidasEmbalagem = coleta.MedidasEmbalagem,
                    PesoEmbalagem = coleta.PesoEmbalagem,
                    PontoDeColeta = coleta.PontoDeColeta,
                    StatusColeta = coleta.StatusColeta,
                    TipoTransporte = coleta.TipoTransporte,
                    Transportadora = coleta.Transportadora,
                    Itens = coleta.Itens

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
            }
        };
    }

}