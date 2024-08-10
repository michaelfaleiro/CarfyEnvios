using CarfyEnvios.Communication.Request.Pedido;
using CarfyEnvios.Communication.Response;
using CarfyEnvios.Communication.Response.Cliente;
using CarfyEnvios.Communication.Response.Pedido;
using CarfyEnvios.Core.Entidades;
using CarfyEnvios.Core.Interfaces;

namespace CarfyEnvios.Application.UseCase.Pedidos.Create;

public class CreatePedidoUseCase(IPedidoRepository pedidoRepository)
{
    public async Task<Response<ResponsePedidoJson>> ExecuteAsync(CreatePedidoRequest request)
    {
        var pedido = new Pedido
        {
            NumeroPedido = request.NumeroPedido,
            DataPedido = request.DataPedido,
            NumeroNfe = request.NumeroNfe,
            DataEmissaoNfe = request.DataEmissaoNfe,
            LinkNfe = request.LinkNfe,
            Cliente = new Cliente
            {
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone
            },
            Observacao = request.Observacao,
            Status = request.Status
        };

        var result = await pedidoRepository.CreateAsync(pedido);

        return new Response<ResponsePedidoJson>
        {
            Data = new ResponsePedidoJson
            {
                Id = result.Id,
                Cliente = new ResponseClienteJson
                {
                    Id = result.Cliente.Id,
                    Nome = result.Cliente.Nome,
                    Email = result.Cliente.Email,
                    Telefone = result.Cliente.Telefone,
                    CreatedAt = result.Cliente.CreatedAt,
                    UpdatedAt = result.Cliente.UpdatedAt
                },
                NumeroPedido = result.NumeroPedido,
                DataPedido = result.DataPedido,
                NumeroNfe = result.NumeroNfe,
                LinkNfe = pedido.LinkNfe,
                DataEmissaoNfe = result.DataEmissaoNfe,
                Observacao = result.Observacao,
                Status = result.Status,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            }
        };
    }
}