using CarfyEnvios.Communication.Request.Pedido;
using CarfyEnvios.Communication.Response;
using CarfyEnvios.Communication.Response.Cliente;
using CarfyEnvios.Communication.Response.Pedido;
using CarfyEnvios.Core.Interfaces;
using CarfyEnvios.Exceptions.ExceptionBase;

namespace CarfyEnvios.Application.UseCase.Pedidos.Update;

public class UpdatePedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task<Response<ResponsePedidoJson>> ExecuteAsync(string id, UpdatePedidoRequest request)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id);
        
        if (pedido is null)
            throw new NotFoundException("Pedido não encontrado");

        pedido.Cliente.Nome = request.Nome;
        pedido.Cliente.Email = request.Email;
        pedido.Cliente.Telefone = request.Telefone;
        pedido.LinkNfe = request.LinkNfe;
        pedido.NumeroNfe = request.NumeroNfe;
        pedido.NumeroPedido = request.NumeroPedido;
        pedido.DataEmissaoNfe = request.DataEmissaoNfe;
        pedido.Observacao = request.Observacao;
        pedido.DataPedido = request.DataPedido;
        pedido.Status = request.Status;
        pedido.UpdatedAt = DateTime.UtcNow;
    
        var result = await pedidoRepository.UpdateAsync(pedido);

        return new Response<ResponsePedidoJson>
        {
            Data = new ResponsePedidoJson
            {
                Id = result.Id,
                NumeroPedido = result.NumeroPedido,
                DataPedido = result.DataPedido,
                NumeroNfe = result.NumeroNfe,
                LinkNfe = result.LinkNfe,
                DataEmissaoNfe = result.DataEmissaoNfe,
                Observacao = result.Observacao,
                Status = result.Status,
                Cliente = new ResponseClienteJson
                {
                    Nome = result.Cliente.Nome,
                    Email = result.Cliente.Email,
                    Telefone = result.Cliente.Telefone,
                },
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            }
        };
    }

}