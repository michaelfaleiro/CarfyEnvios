using CarfyEnvios.Communication.Response;
using CarfyEnvios.Communication.Response.Coleta;
using CarfyEnvios.Communication.Response.ItemPedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.Coleta.GetById;
public class GetColetaByIdUseCase(IPedidoRepository pedidoRepository)
{
    public async Task<Response<ResponseColetaJson>> ExecuteAsync(string pedidoId, string coletaId)
    {
        var pedido = await pedidoRepository.GetByIdAsync(pedidoId);

        if (pedido == null)
            throw new NotFoundException("Pedido não encontrado");

        var coleta = pedido.Coletas.FirstOrDefault(c => c.Id == coletaId);

        if (coleta == null)
            throw new NotFoundException("Coleta não encontrada");

        return new Response<ResponseColetaJson>
        {
            Data = new ResponseColetaJson
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
                Itens = coleta.Itens.Select(item => new ResponseItemPedidoJson
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Sku = item.Sku,
                    Fabricante = item.Fabricante,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario
                }).ToList()
            }
        };
    }
}
